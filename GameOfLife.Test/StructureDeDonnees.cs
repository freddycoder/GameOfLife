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
    public class StructureDeDonnees
    {
        [Fact]
        public void CarteHorizontaleSauvegarde_StockageCorrect()
        {
            var carte = new Carte(new Size(6, 2), "0A0000\n0A0000");

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    var p = new Point(x, y);

                    carte[p].Point.ShouldBe(p);
                }
            }
        }

        [Fact]
        public void CarteVerticaleSauvegarde_StockageCorrect()
        {
            var carte = new Carte(new Size(2, 6), "0A\n00\n00\n0A\n00\n00");

            for (int y = 0; y < 6; y++)
            {
                for (int x = 0; x < 2; x++)
                {
                    var p = new Point(x, y);

                    carte[p].Point.ShouldBe(p);
                }
            }
        }

        [Fact]
        public void CarteHorizontaleSauvegarde_ConsultationCorrect()
        {
            var carte = new Carte(new Size(6, 2), "0A0000\n0A0000");

            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 6; x++)
                {
                    var p = new Point(x, y);

                    if (x == 1)
                    {
                        carte[p].Etat.ShouldBe('A', $"x: {x}, y: {y}");
                    }
                    else
                    {
                        carte[p].Etat.ShouldBe('0', $"x: {x}, y: {y}");
                    }
                }
            }
        }

        [Fact]
        public void CarteVerticaleSauvegarde_ConsultationCorrect()
        {
            var carte = new Carte(new Size(2, 6), "0A\n00\n00\n0A\n00\n00");

            for (int x = 0; x < 2; x++)
            {
                for (int y = 0; y < 6; y++)
                {
                    var p = new Point(x, y);

                    if (x == 1 && (y == 0 || y == 3))
                    {
                        carte[p].Etat.ShouldBe('A', $"x: {x}, y: {y}");
                    }
                    else
                    {
                        carte[p].Etat.ShouldBe('0', $"x: {x}, y: {y}");
                    }
                }
            }
        }

        [Fact]
        public void Carte_ConsultationDesVoisinsCorrect1()
        {
            var carte = new Carte(new Size(3, 3), "000AAA000");

            var voisins = carte[new Point(1, 1)].Voisins();

            voisins.Count(v => v.Point.Y == 0 && v.Etat == '0').ShouldBe(3);
            voisins.Count(v => v.Point.Y == 1 && v.Etat == 'A').ShouldBe(2);
            voisins.Count(v => v.Point.Y == 2 && v.Etat == '0').ShouldBe(3);
        }

        [Fact]
        public void Carte_ConsultationDesVoisinsCorrect2()
        {
            var carte = new Carte(new Size(3, 3), "000AAA000");

            var cell = carte[new Point(1, 0)];

            cell.Etat.ShouldBe('0');

            var voisins = cell.Voisins();

            voisins.Count(v => v.Point.Y == -1 && v.Etat == '0').ShouldBe(3);
            voisins.Count(v => v.Point.Y ==  0 && v.Etat == '0').ShouldBe(2);
            voisins.Count(v => v.Point.Y ==  1 && v.Etat == 'A').ShouldBe(3);
        }
    }
}
