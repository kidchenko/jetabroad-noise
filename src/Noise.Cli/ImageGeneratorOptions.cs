using System;
using System.Collections.Generic;
using DocoptNet;

namespace JetabroadNoise.Cli
{
    public class ImageGeneratorOptions
    {
        public int Width { get; set; }

        public int Height { get; set; }

        public double Increment { get; set; }

        public bool IsTerrain { get; set; }

        public ImageGeneratorOptions(IDictionary<string, ValueObject> arguments)
        {
			Width = arguments["--height"].AsInt;
			Height = arguments["--width"].AsInt;
			Increment = Convert.ToDouble(arguments["--inc"].Value);
			IsTerrain = arguments["--terrain"].IsTrue;
        }
    }
}
