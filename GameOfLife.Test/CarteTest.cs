using GameOfLife.Lib;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using Xunit;

namespace GameOfLife.Test
{
    public class CarteTest
    {
        [Fact]
        public void DemanderUneCelluleHorsCarte_DonneUneCelluleMorte()
        {
            var carte = new Carte(new Size(3, 3), "000AAA000");

            carte[new Point(5, 5)].Etat.ShouldBe('0');
        }

        [Fact]
        public void ConstrucreUneCarteInvalideLeveOperationException()
        {
            ShouldThrowExtensions.ShouldThrow<ArgumentException>(() => new Carte(new Size(3, 3), "0AAA000"));
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData("\t")]
        public void NullCommeCarteLeveNullArgumentException(string carte)
        {
            ShouldThrowExtensions.ShouldThrow<ArgumentNullException>(() => new Carte(default, carte));
        }

        [Fact]
        public void UneCarteDiteHorizontaleDevraitBienFonctionner()
        {
            var carte = new Carte(new Size(6, 2), "0A0000\n0A0000");

            var p = new Point(1, 0);

            var cell = carte[p];

            cell.Etat.ShouldBe('A');
            cell.Point.ShouldBe(p);

            var p2 = new Point(1, 1);

            var cell2 = carte[p2];

            cell2.Etat.ShouldBe('A');

            cell2.Point.ShouldBe(p2);
        }

        [Fact]
        public void UneCarteDiteVerticaleDevraitBienFonctionner()
        {
            var carte = new Carte(new Size(2, 6), "0A\n00\n00\n0A\n00\n00");

            var p = new Point(1, 0);

            var cell = carte[p];

            cell.Etat.ShouldBe('A');
            cell.Point.ShouldBe(p);

            var p2 = new Point(1, 3);

            var cell2 = carte[p2];

            cell2.Etat.ShouldBe('A');

            cell2.Point.ShouldBe(p2);
        }
    }
}
