using ImageSharp;
using JetabroadNoise.Cli.Pixel;

namespace JetabroadNoise.Cli.Image
{
    public class GrayScaleImage : PerlinImage
    {
	    public GrayScaleImage(int width, int height, double increment) : base(width, height, increment)
        {
        }

	    protected override IPixelCreator PixelCreator { get; set; } = new GrayScale();

	    protected override Rgba32 CreatePixel()
	    {
		    var noise = ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY);

		    return PixelCreator.Create(noise);
	    }	    
    }
}
