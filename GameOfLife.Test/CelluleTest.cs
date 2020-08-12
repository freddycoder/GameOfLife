using GameOfLife.Lib;
using Shouldly;
using System.Drawing;
using Xunit;

namespace GameOfLife.Test
{
    public class CelluleTest
    {
        [Fact]
        public void CelluleAuCentreDEvraitÊtreVivante()
        {
            var cellule = new Cellule(new Point(1, 1), new Carte(new Size(3, 3), "000AAA000"), 'A');

            cellule.Etat.ShouldBe('A');
        }

        [Fact]
        public void CellulePossede8Voisins()
        {
            var cellule = new Cellule(new Point(1, 1), new Carte(new Size(3, 3), "000AAA000"), 'A');

            cellule.Voisins().Length.ShouldBe(8);
        }
    }
}
