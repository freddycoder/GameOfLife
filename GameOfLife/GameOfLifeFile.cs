using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class GameOfLifeFile
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string[] Carte { get; set; }

        public string CarteAsSingleString() => Carte.Aggregate((current, next) => string.Concat(current, next));

        public static string[] ObtenirTemplates()
        {
            return Directory.EnumerateFiles("Template").Select(f => Path.GetFileNameWithoutExtension(f)).ToArray();
        }

        public static GameOfLifeFile OuvrirTemplate(string name)
        {
            return JsonConvert.DeserializeObject<GameOfLifeFile>(File.ReadAllText(Path.Combine("Template", $"{name}.json")));
        }
    }
}
