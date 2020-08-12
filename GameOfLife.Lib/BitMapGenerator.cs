using System;
using System.Collections.Generic;
using System.Diagnostics;
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

        public DirectBitmap ObtenirProchaineImage()
        {
            var carteActuel = Carte.String;

            var bitmap = new DirectBitmap(Carte.Dimession.Width, Carte.Dimession.Height);

            Carte.ExecuterTour();

            foreach (var cellule in Carte.Cellules())
            {
                bitmap.SetPixel(cellule.Point.X, cellule.Point.Y, DeterminerCouleur(carteActuel, cellule));
            }

            return bitmap;
        }

        public void UpdateBitmap(DirectBitmap bitmap, string cartePrecedente)
        {
            Debug.Assert(cartePrecedente == Carte.String);

            Carte.ExecuterTour();

            foreach (var cellule in Carte.Cellules())
            {
                bitmap.SetPixel(cellule.Point.X, cellule.Point.Y, DeterminerCouleur(cartePrecedente, cellule));
            }
        }

        private Color DeterminerCouleur(string cartePrecedente, Cellule celluleActuel)
        {
            var cellActuel = cartePrecedente[(celluleActuel.Point.Y * celluleActuel.Carte.Dimession.Width) + celluleActuel.Point.X];

            if (cellActuel == 'A') 
            {
                if (celluleActuel.Etat == 'A')
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
