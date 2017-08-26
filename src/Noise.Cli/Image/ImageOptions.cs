using System.Collections.Generic;
using DocoptNet;
using JetabroadNoise.Cli.Extensions;

namespace JetabroadNoise.Cli
{
    public class ImageOptions
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public double Increment { get; private set; }

        public bool IsTerrain { get; private set; }

        public ImageOptions(IDictionary<string, ValueObject> arguments)
        {
			Width = arguments["--width"].AsInt;
			Height = arguments["--height"].AsInt;
            Increment = arguments["--inc"].AsDouble();
			IsTerrain = arguments["--terrain"].IsTrue;
        }
    }
}
