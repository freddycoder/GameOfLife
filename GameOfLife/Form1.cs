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
        private Carte? _carte;

        private BitMapGenerator? _generator;

        public Form1()
        {
            InitializeComponent();

            _chrono = new Stopwatch();

            LabelMessageError.Text = "";

            SleepTime.Text = "750";

            listTemplate.Text = GameOfLifeFile.ObtenirTemplates().First();

            listTemplate.Items.AddRange(GameOfLifeFile.ObtenirTemplates());

            listTemplate.TextChanged += (sender, eventargs) => TrySetImageFromParameter();

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
        private Task? _task;
        private readonly Stopwatch _chrono;

        private async void UpdateImage()
        {
            try
            {
                CancelPreviousTask();

                _task = Task.Run(() =>
                {
                    if (_generator == null)
                    {
                        throw new MemberAccessException(nameof(_generator));
                    }
                    if (_carte == null)
                    {
                        throw new MemberAccessException(nameof(_carte));
                    }

                    var directBitmap = _generator.ObtenirProchaineImage();

                    int t = 0;

                    while (true)
                    {
                        _chrono.Reset();
                        _chrono.Start();

                        _tokenSource.Token.ThrowIfCancellationRequested();

                        _generator.UpdateBitmap(directBitmap, _carte.String);

                        gameOfLifeImage.Image = directBitmap.Bitmap.Redimessionner(gameOfLifeImage.Bounds.Width, gameOfLifeImage.Bounds.Height);

                        UpdateTime(t++, _chrono.ElapsedMilliseconds);

                        _chrono.Stop();

                        var timeLeft = int.Parse(SleepTime.Text) - (int)_chrono.ElapsedMilliseconds;

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

        private void UpdateTime(int t, long deltaT)
        {
            MethodInvoker methodInvokerDelegate = delegate ()
            {
                LabelT.Text = $"t: {t}";
                LabelDeltaT.Text = $"Δt: {deltaT}ms";
            };

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
