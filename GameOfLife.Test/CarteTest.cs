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
    }
}
