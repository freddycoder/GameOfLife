using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GameOfLife.Lib;
using GameOfLife.Lib.Extension;
using Newtonsoft.Json;

namespace GameOfLife
{
    public partial class Form1 : Form
    {
        private Carte _carte;

        private BitMapGenerator _generator;

        public Form1()
        {
            InitializeComponent();

            LabelMessageError.Text = "";

            SleepTime.Text = "750";

            listTemplate.Text = GameOfLifeFile.ObtenirTemplates().First();

            listTemplate.Items.AddRange(GameOfLifeFile.ObtenirTemplates());

            listTemplate.TextChanged += (sender, eventargs) => TrySetImageFromParameter();

            NouvelleCarteAleatoire.Text = "Nouvelle carte aléatoire";

            NouvelleCarteAleatoire.Click += (sender, eventArgs) => NewRandomMap();

            TrySetImageFromParameter();
        }

        private void NewRandomMap()
        {
            var dim = int.Parse(TextboxHauteur.Text) * int.Parse(TextboxLongeur.Text);
            var sb = new StringBuilder();
            var random = new Random();

            for (int i = 0; i < dim; i++)
            {
                sb.Append(random.NextDouble() > 0.33 ? '0' : 'A');
            }

            _carte = new Carte(new Size(int.Parse(TextboxLongeur.Text), int.Parse(TextboxHauteur.Text)), sb.ToString());
            _generator = new BitMapGenerator(_carte);

            UpdateImage();
        }

        private void TrySetImageFromParameter()
        {
            try
            {
                var gaemoflifeTemplate = GameOfLifeFile.OuvrirTemplate(listTemplate.Text);

                TextboxLongeur.Text = gaemoflifeTemplate.X.ToString();
                TextboxHauteur.Text = gaemoflifeTemplate.Y.ToString();

                _carte = new Carte(new Size(gaemoflifeTemplate.X, gaemoflifeTemplate.Y), gaemoflifeTemplate.CarteAsSingleString());
                _generator = new BitMapGenerator(_carte);

                UpdateImage();

                LabelMessageError.Text = "";
            }
            catch (Exception e)
            {
                LabelMessageError.Text = e.Message;
            }
        }

        private CancellationTokenSource _tokenSource = new CancellationTokenSource();
        private Task _task;
        private async void UpdateImage()
        {
            try
            {
                CancelPreviousTask();

                _task = Task.Run(() =>
                {
                    var chrono = new Stopwatch();

                    var directBitmap = _generator.ObtenirProchaineImage();

                    int t = 0;

                    while (true)
                    {
                        chrono.Reset();
                        chrono.Start();

                        _tokenSource.Token.ThrowIfCancellationRequested();

                        _generator.UpdateBitmap(directBitmap);

                        gameOfLifeImage.Image = directBitmap.Bitmap.Redimessionner(gameOfLifeImage.Bounds.Width, gameOfLifeImage.Bounds.Height);

                        UpdateTime(t++);

                        chrono.Stop();

                        var timeLeft = int.Parse(SleepTime.Text) - (int)chrono.ElapsedMilliseconds;

                        if (timeLeft >= 0)
                        {
                            Thread.Sleep(timeLeft);
                        }
                    }
                }, _tokenSource.Token);

                await _task;
            }
            catch (Exception e)
            {
                LabelMessageError.Text = e.Message;
            }
        }

        private void CancelPreviousTask()
        {
            if (_task != null)
            {
                _tokenSource.Cancel();

                try
                {
                    if (_task.IsCompleted == false)
                    {
                        _task.Wait(2000);
                    }
                }
                catch { }

                _tokenSource.Dispose();

                _tokenSource = new CancellationTokenSource();
            }
        }

        private void UpdateTime(int t)
        {
            MethodInvoker methodInvokerDelegate = delegate () { LabelT.Text = $"t: {t}"; };

            if (this.InvokeRequired)
            {
                Invoke(methodInvokerDelegate);
            }
            else
            {
                methodInvokerDelegate();
            }
        }
    }
}
