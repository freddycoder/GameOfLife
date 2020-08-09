using GameOfLife.Lib;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using Xunit;

namespace GameOfLife.Test
{
    public class CelluleTest
    {
        [Fact]
        public void CelluleAuCentreDEvraitÊtreVivante()
        {
            var cellule = new Cellule(new Point(1, 1), new Carte(new Size(3, 3), "000AAA000"));

            cellule.Etat.ShouldBe('A');
        }

        [Fact]
        public void CellulePossede8Voisins()
        {
            var cellule = new Cellule(new Point(1, 1), new Carte(new Size(3, 3), "000AAA000"));

            cellule.Voisins().Count().ShouldBe(8);
        }
    }
}
