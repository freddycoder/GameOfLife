using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace GameOfLife.Lib
{
    public class BitMapGenerator
    {
        public BitMapGenerator(Carte carte)
        {
            Carte = carte;
        }
        public Carte Carte { get; }

        public Bitmap ObtenirProchaineImage()
        {
            var carteActuel = Carte.String;

            var bitmap = new Bitmap(Carte.Dimession.Width, Carte.Dimession.Height);

            Carte.ExecuterTour();

            foreach (var cellule in Carte.Cellules())
            {
                bitmap.SetPixel(cellule.Point.X, cellule.Point.Y, DeterminerCouleur(carteActuel, cellule));
            }

            return bitmap;
        }

        public void UpdateBitmap(Bitmap bitmap)
        {
            var carteActuel = Carte.String;

            Carte.ExecuterTour();

            foreach (var cellule in Carte.Cellules())
            {
                bitmap.SetPixel(cellule.Point.X, cellule.Point.Y, DeterminerCouleur(carteActuel, cellule));
            }
        }

        private Color DeterminerCouleur(string carteActuel, Cellule celluleProchainTour)
        {
            var cellActuel = carteActuel[(celluleProchainTour.Point.X * celluleProchainTour.Carte.Dimession.Height) + celluleProchainTour.Point.Y];

            if (cellActuel == 'A') 
            {
                if (celluleProchainTour.Etat == 'A')
                {
                    return Color.Blue;
                }
                return Color.Red;
            }
            else
            {
                return Color.White;
            }
        }
    }
}
