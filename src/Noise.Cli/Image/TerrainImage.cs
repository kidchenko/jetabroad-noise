using System;
using ImageSharp;
using JetabroadNoise.Cli.Pixel;

namespace JetabroadNoise.Cli.Image
{
    public class TerrainImage : PerlinImage
    {
        public TerrainImage(int width, int height, double increment) : base(width, height, increment)
        {
     
        }

        protected override IPixelCreator PixelCreator { get; set; } = new MotherNature();

        protected override Rgba32 CreatePixel()
        {
            var e = CalculateElevation();
            return PixelCreator.Create(e);
        }
            
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
