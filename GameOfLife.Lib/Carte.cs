using GameOfLife.Lib.Extension;
using System;
using System.Buffers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameOfLife.Lib
{
    public class Carte
    {
        private readonly Dictionary<Point, Cellule> _cells;

        public Carte(Size dimenssion, string carte)
        {
            carte = SkipSpace(carte);

            Valider(dimenssion, carte);

            Dimession = dimenssion;
            _cells = new Dictionary<Point, Cellule>(Dimession.Width * Dimession.Height);
            _cellules = new Cellule[Dimession.Width * Dimession.Height];
            String = carte;

            for (int y = 0; y < Dimession.Height; y++)
            {
                for (int x = 0; x < Dimession.Width; x++)
                {
                    var key = new Point(x, y);

                    _cells.Add(key, new Cellule(key, this, carte[(y * Dimession.Width) + x]));

                    _cellules[(y * Dimession.Width) + x] = _cells[new Point(x, y)];
                }
            }
        }

        private string SkipSpace(string carte)
        {
            var sb = new StringBuilder();

            foreach (var c in carte ?? "")
            {
                if (char.IsWhiteSpace(c) == false)
                {
                    sb.Append(c);
                }
            }

            return sb.ToString();
        }

        public Size Dimession { get; }

        public string String { get; private set; }

        public Cellule this[Point p]
        {
            get
            {
                if (_cells.TryGetValue(p, out var cell))
                {
                    return cell;
                }
                return new Cellule(p, this, '0');
            }
        }

        private readonly StringBuilder _sb = new StringBuilder();
        public void ExecuterTour()
        {
            _sb.Clear();

            foreach (var cellule in Cellules())
            {
                var voisinEnVie = NbCellulesEnVie(cellule.Voisins());

                var c = '0';

                if (voisinEnVie == 3)
                {
                    c = 'A';
                }
                else if (voisinEnVie == 2 && cellule.Etat == 'A')
                {
                    c = 'A';
                }

                _sb.Append(c);
            }

            Debug.Assert(_sb.ToString().Length == String.ToString().Length);

            String = _sb.ToString();

            for (int i = 0; i < _cellules.Length; i++)
            {
                _cellules[i].Etat = String[(_cellules[i].Point.Y * Dimession.Width) + _cellules[i].Point.X];
            }
        }


        private static int NbCellulesEnVie(Cellule[] cellules, int count = 0, int i = 0)
        {
            Debug.Assert(cellules.Length == 8);

            for (; i < 8; i++)
            {
                if (cellules[i].Etat == 'A')
                {
                    count++;
                }
            }

            return count;
        }

        public override string ToString()
        {
            return String;
        }

        private Cellule[] _cellules;
        public Cellule[] Cellules()
        {
            return _cellules;
        }

        private void Valider(Size dimenssion, string carte)
        {
            if (string.IsNullOrWhiteSpace(carte))
            {
                throw new ArgumentNullException(nameof(carte));
            }

            if (dimenssion.Width * dimenssion.Height != carte.Length)
            {
                throw new ArgumentException($"La longeur de la carte ({carte.Length}) doit être égal au produit de la dimenssion ({dimenssion.Width}, {dimenssion.Height}) = ({dimenssion.Width * dimenssion.Width}");
            }
        }
    }
}
