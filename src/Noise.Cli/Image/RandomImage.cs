using System;
using ImageSharp;

namespace JetabroadNoise.Cli.Image
{
    public abstract class RandomImage
    {
        protected int Width { get; }
        
        protected int Height { get; }
        
        protected double Increment { get; }
        
        protected readonly double InititalXValue;
        protected readonly double InititalYValue;

        protected double PerlinSpaceY;
        protected double PerlinSpaceX;
        
        protected Image<Rgba32> BaseImage;

        private readonly Random _seed = new Random();

        protected RandomImage(int width, int height, double increment)
        {
            Width = width;
            Height = height;
            Increment = increment;
            InititalXValue = GenerateRandomValue();
            InititalYValue = GenerateRandomValue();
        }

        public Image<Rgba32> CreateImage()
        {
            MoveSpaceXToInitialValue();
            MoveSpaceYToInititalValue();
            
            using (BaseImage = new Image<Rgba32>(Width, Height))
            {
                for (var y = 0; y < Height; y++)
                {
                    MoveSpaceXToInitialValue();
                    for (var x = 0; x < Width; x++)
                    {
                        BaseImage.GetPixelReference(x, y) = CreatePixel();
                        MoveXSpace();
                    }
                    MoveYSpace();
                }
                return new Image<Rgba32>(BaseImage);
            }
        }


        protected abstract Rgba32 CreatePixel();

        public double GenerateRandomValue()
        {
            return _seed.NextDouble() * _seed.Next();
        }
        
        protected virtual void MoveSpaceXToInitialValue()
        {
            PerlinSpaceX = InititalXValue;
        }

        protected virtual void MoveSpaceYToInititalValue()
        {
            PerlinSpaceY = InititalYValue;
        }
	    
        protected virtual void MoveXSpace()
        {
            PerlinSpaceX += Increment;
        }

        protected virtual void MoveYSpace()
        {
            PerlinSpaceY += Increment;
        }
	}
}
