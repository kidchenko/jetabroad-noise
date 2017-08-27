using System;
using ImageSharp;

namespace JetabroadNoise.Cli.Image
{
    public abstract class RandomImage
    {
        public int Width { get; }
        
        public int Height { get; }
        
        public double Increment { get; }
        
        protected Image<Rgba32> BaseImage;

        public Random Seed = new Random();

        protected RandomImage(int width, int height, double increment)
        {
            Width = width;
            Height = height;
            Increment = increment;
        }

        public abstract Image<Rgba32> CreateImage();

        public double GenerateSeedValue()
        {
            return Seed.NextDouble() * Seed.Next();
        }
	}
}
