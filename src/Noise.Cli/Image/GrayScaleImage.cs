using ImageSharp;
using JetabroadNoise.Cli.Pixel;

namespace JetabroadNoise.Cli.Image
{
    public class GrayScaleImage : RandomImage
    {
	    public GrayScaleImage(int width, int height, double increment) : base(width, height, increment)
        {
        }

        protected override Rgba32 CreatePixel()
	    {
		    var noise = ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY);

		    return GrayScale.Create(noise);
	    }	    
    }
}
