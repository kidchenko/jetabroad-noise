using ImageSharp;

namespace JetabroadNoise.Cli.Pixels
{
    public class Monochrome : IPixelCreator
    {
        public Rgba32 Create(double noise)
		{
			var color = (byte) (noise * 255);
			var r = color;
			var g = color;
			var b = color;
			const byte alpha = 255;
			return new Rgba32(r, g, b, alpha);
		}
    }
}
