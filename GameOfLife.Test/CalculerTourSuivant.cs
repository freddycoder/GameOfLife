using GameOfLife.Lib;
using System;
using Xunit;
using Shouldly;
using System.Drawing;
using System.Data;
using System.Linq;

namespace GameOfLife.Test
{
    public class CalculerTourSuivant
    {
        [Fact]
        public void LigneHorizontale_DonneLigneVerticale()
        {
            var carte = new Carte(new Size(3, 3), "000AAA000");

            carte.ExecuterTour();

            carte.ToString().ShouldBe("0A00A00A0");
        }

        [Fact]
        public void LigneHorizontale_DonneLigneVerticale_TourSuivant_RedonneHorizontale()
        {
            var carte = new Carte(new Size(3, 3), "000AAA000");

            carte.ExecuterTour();
            carte.ExecuterTour();

            carte.ToString().ShouldBe("000AAA000");
        }

        [Fact]
        public void StrictementPlusDeTroisCelluleVoisinesVivante_TourSuivant_CelluleMorte()
        {
            var carte = new Carte(new Size(3, 3), "AAAAA0000");

            carte.ExecuterTour();

            carte[new Point(1, 1)].Etat.ShouldBe('0');
        }

        [Fact]
        public void PourChaqueCellule()
        {
            var carte = new Carte(new Size(3, 3), "000AAA000");

            var cells = carte.Cellules().ToArray();

            cells.Length.ShouldBe(9);

            cells[0].Etat.ShouldBe('0');
            cells[0].Point.ShouldBe(new Point(0, 0));

            //...

            cells[8].Etat.ShouldBe('0');
            cells[8].Point.ShouldBe(new Point(2, 2));
        }

        [Fact]
        public void QuandLaLongeurEstPlusGrandeQueLaHauteur()
        {
            var carte = new Carte(new Size(6, 2), "00AA0000AA00");

            carte.ExecuterTour();
        }
    }
}
