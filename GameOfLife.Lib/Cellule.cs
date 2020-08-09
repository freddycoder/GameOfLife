using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameOfLife.Lib
{
    public class Cellule
    {
        public Cellule(Point p, Carte carte)
        {
            Point = p;
            Carte = carte;
        }

        public Point Point { get; }
        public char Etat
        {
            get
            {
                if (Point.X >= 0 && Point.X < Carte.Dimession.Width &&
                    Point.Y >= 0 && Point.Y < Carte.Dimession.Height)
                {
                    return Carte.ToString()[(Point.X * Carte.Dimession.Height) + Point.Y];
                }
                return '0';
            }
        }
        public Carte Carte { get; }

        public Cellule[] Voisins()
        {
            return _voisins ?? InitVoisins();
        }

        private Cellule[] _voisins;

        private Cellule[] InitVoisins()
        {
            _voisins = new Cellule[8];

            var v = 0;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var size = new Size(i - 1, j - 1);

                    if (!size.IsEmpty)
                    {
                        var coordonneeVoisin = Point.Subtract(Point, size);

                        _voisins[v++] = Carte[coordonneeVoisin];
                    }
                }
            }

            return _voisins;
        }
    }
}
