using System;
using ImageSharp;
using JetabroadNoise.Cli.Pixels;

namespace JetabroadNoise.Cli.Images
{
    /// <summary>
    /// A class to generate images based on Perlin Noise
    /// </summary>
    public abstract class PerlinImage
    {
        public int Width { get; }
        public int Height { get; }
        
        /// <summary>
        /// The increment of perlin noise space.
        /// </summary>
        public double Increment { get; }
        
        /// <summary>
        /// The initial point of Perlin Noise in X axis.
        /// </summary>
        public double InititalSpaceX { get; }
        
        /// <summary>
        /// The initial point of Perlin Noise in Y axis.
        /// </summary>
        public double InititalSpaceY { get; }
        
        /// <summary>
        /// The actual Perlin Noise point in X axis, that is incremented each pixel generation.
        /// </summary>
        public double PerlinSpaceX { get; private set; }

        /// <summary>
        /// The actual Perlin Noise point in Y axis, that is incremented each pixel generation.
        /// </summary>
        public double PerlinSpaceY { get; private set; }
        
        
        protected Image<Rgba32> BaseImage;

        private readonly Random _seed = new Random();

        protected PerlinImage(int width, int height, double increment)
        {
            Width = width;
            Height = height;
            Increment = increment;
            InititalSpaceX = GenerateRandom();
            InititalSpaceY = GenerateRandom();
            PerlinSpaceX = InititalSpaceX;
            PerlinSpaceY = InititalSpaceY;
        }

        public Image<Rgba32> CreateImage()
        {
            using (BaseImage = new Image<Rgba32>(Width, Height))
            {
                for (var y = 0; y < Height; y++)
                {
                    MoveXSpaceToOrigin(); // each row we need reset the X value
                    for (var x = 0; x < Width; x++)
                    {
                        BaseImage.GetPixelReference(x, y) = CreatePixel();
                        IncrementXSpace();
                    }
                    IncrementYSpace();
                }
                return new Image<Rgba32>(BaseImage);
            }
        }

        public double GenerateRandom()
        {
            return _seed.NextDouble() * _seed.Next();
        }
        
        public virtual void MoveXSpaceToOrigin()
        {
            PerlinSpaceX = InititalSpaceX;
        }

        public virtual void MoveYSpaceToOrigin()
        {
            PerlinSpaceY = InititalSpaceY;
        }
	    
        /// <summary>
        /// Add the <code>Increment</code> to <code>PerlinSpaceX</code>
        /// </summary>
        public virtual void IncrementXSpace()
        {
            PerlinSpaceX += Increment;
        }

        /// <summary>
        /// Add the <code>Increment</code> to <code>PerlinSpaceY</code>
        /// </summary>
        public virtual void IncrementYSpace()
        {
            PerlinSpaceY += Increment;
        }
        
        protected abstract Rgba32 CreatePixel();

        public abstract IPixelCreator PixelCreator { get; set; }
	}
}
