using GameOfLife.Lib;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using Xunit;

namespace GameOfLife.Test
{
    public class TemplateTest
    {
        [Fact]
        public void PossibleOuvrirToutLesTemplateSansException()
        {
            var templates = GameOfLifeFile.ObtenirTemplates();

            templates.Length.ShouldBeGreaterThan(0);

            foreach (var template in templates)
            {
                var gof = GameOfLifeFile.OuvrirTemplate(template);

                var carte = new Carte(new Size(gof.X, gof.Y), gof.CarteAsSingleString());
            }
        }

        [Fact]
        public void OuvrirPuffer2ALaCoordonnee0_5DevraitEtrePresent()
        {
            var template = GameOfLifeFile.OuvrirTemplate(Path.Combine("Puffeur2"));

            var carte = new Carte(new Size(template.X, template.Y), template.CarteAsSingleString());

            var p = new Point(0, 5);

            var cell = carte[p];

            cell.Etat.ShouldBe('0');
            cell.Point.ShouldBe(p);

            carte.ExecuterTour();
        }
    }
}
