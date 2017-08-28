using ImageSharp;
using JetabroadNoise.Cli.Pixels;

namespace JetabroadNoise.Cli.Images
{

	/// <summary>
	/// A class that represent a graysacle Perlin Image 
	/// </summary> 	
    public class GrayScaleImage : PerlinImage
    {
	    /// <summary>
	    /// Construct a GrayScale image using width, height and the increment of perlin used in each pixel. 
	    /// A lower increment: e.g. 0.01, 0.001 will create a smooth effect.
	    /// A bigger increment: e.g. 1, 0.9 will create a rough.
	    /// </summary>
	    /// <param name="width"></param>
	    /// <param name="height"></param>
	    /// <param name="increment"></param>
	    public GrayScaleImage(int width, int height, double increment) : base(width, height, increment)
        {
        }
	    
	    public override IPixelCreator PixelCreator { get; set; } = new Monochrome();

	    protected override Rgba32 CreatePixel()
	    {
		    var noise = ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY);

		    return PixelCreator.Create(noise);
	    }	    
    }
}
