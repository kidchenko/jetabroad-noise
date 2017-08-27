using System.Collections.Generic;
using DocoptNet;
using JetabroadNoise.Cli.Extensions;

namespace JetabroadNoise.Cli.Options
{
    public class DocoptOptions : IOptions
    {
        public int Width { get; }
        public int Height { get; }
        public double Increment { get; }
        public bool IsTerrain { get; }
        
        public DocoptOptions(IDictionary<string, ValueObject> arguments)
        {
			Width = arguments["--width"].AsInt;
			Height = arguments["--height"].AsInt;
            Increment = arguments["--inc"].AsDouble();
			IsTerrain = arguments["--terrain"].IsTrue;
        }        
    }
}
