using System;
using ImageSharp;
using JetabroadNoise.Cli.Pixels;

namespace JetabroadNoise.Cli.Images
{
    /// <summary>
    /// A class that represent a terrain created using Perlin Image 
    /// </summary>
    public class TerrainImage : PerlinImage
    {
        /// <summary>
        /// Construct a TerrainImage using width, height and the increment of perlin noise used in each pixel. 
        /// A lower increment: e.g. 0.01, 0.001 will create a smooth biomes.
        /// A bigger increment: e.g. 1, 0.9 will create a rough biomes.
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="increment"></param>
        public TerrainImage(int width, int height, double increment) : base(width, height, increment)
        {
     
        }

        public override IPixelCreator PixelCreator { get; set; } = new MotherNature();

        protected override Rgba32 CreatePixel()
        {
            var e = CalculateElevation();
            return PixelCreator.Create(e);
        }
        
        /// <summary>
        /// Generate the elevation of the terrain based in multiples perlin noise numbers. 
        /// Multiple based perlin numbers is generated to create a terrain effect 
        /// </summary>
        /// <returns></returns>
        private double CalculateElevation()
        {
            var e = (1.00 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.50 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.25 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.13 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.06 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY));
            e /= (1.00 + 0.50 + 0.25 + 0.13 + 0.06);
            e = Math.Pow(e, 2.2);
            return e;
        }
    }
}
