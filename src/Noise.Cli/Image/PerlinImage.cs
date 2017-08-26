using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public abstract class PerlinImage
    {
        public int Width { get; set; }

        public Random Seed = new Random();

        public abstract Image<Rgba32> CreateImage();

        public double GenerateSeedValue()
        {
            return Seed.NextDouble() * Seed.Next();
        }
	}
}
