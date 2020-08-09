using GameOfLife.Lib.Extension;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;

namespace GameOfLife.Lib
{
    public class Carte
    {
        private string _carte;
        private readonly Dictionary<Point, Cellule> _cells;

        public Carte(Size dimenssion, string carte)
        {
            carte = SkipSpace(carte);

            Valider(dimenssion, carte);

            Dimession = dimenssion;
            _cells = new Dictionary<Point, Cellule>(Dimession.Width * Dimession.Height);
            _carte = carte;

            for (int y = 0; y < Dimession.Height; y++)
            {
                for (int x = 0; x < Dimession.Width; x++)
                {
                    var key = new Point(x, y);

                    _cells.Add(key, new Cellule(key, this));
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

        public string String => _carte;

        public Cellule this[Point p]
        {
            get
            {
                if (_cells.TryGetValue(p, out var cell))
                {
                    return cell;
                }
                return new Cellule(p, this);
            }
        }

        public void ExecuterTour()
        {
            var sb = new StringBuilder();

            foreach (var cellule in Cellules())
            {
                var voisinEnVie = cellule.Voisins().Count(v => v?.Etat == 'A');

                var c = '0';

                if (voisinEnVie == 3)
                {
                    c = 'A';
                }
                else if (voisinEnVie == 2 && cellule.Etat == 'A')
                {
                    c = 'A';
                }

                sb.Append(c);
            }

            Debug.Assert(sb.ToString().Length == _carte.ToString().Length);

            _carte = sb.ToString();
        }

        public override string ToString()
        {
            return _carte;
        }

        private List<Cellule> _cellules;
        public IEnumerable<Cellule> Cellules()
        {
            return _cellules ?? InitCellules();
        }

        private List<Cellule> InitCellules()
        {
            _cellules = new List<Cellule>(Dimession.Width * Dimession.Height);

            for (int j = 0; j < Dimession.Height; j++)
            {
                for (int i = 0; i < Dimession.Width; i++)
                {
                    _cellules.Add(_cells[new Point(i, j)]);
                }
            }

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
