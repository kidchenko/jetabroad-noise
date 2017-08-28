using System.Collections.Generic;
using DocoptNet;
using JetabroadNoise.Cli.Extensions;

namespace JetabroadNoise.Cli.Options
{
    /// <summary>
    /// Class to parse arguments from docopt.
    /// </summary>
    public class DocoptOption : IOption
    {
        public int Width { get; }
        public int Height { get; }
        public double Increment { get; }
        public bool IsTerrain { get; }
        
        public DocoptOption(IDictionary<string, ValueObject> arguments)
        {
			Width = arguments["--width"].AsInt;
			Height = arguments["--height"].AsInt;
            Increment = arguments["--inc"].AsDouble();
			IsTerrain = arguments["--terrain"].IsTrue;
        }        
    }
}
