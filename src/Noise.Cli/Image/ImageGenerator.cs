using ImageSharp;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli.Image
{
    public class ImageGenerator
    {
        public readonly RandomImage Image;
        
        public ImageGenerator(IOptions options)
        {
            if (options.IsTerrain) 
            {
                Image = new TerrainImage(options.Width, options.Height, options.Increment);
            }
            else
            {
                Image = new GrayScaleImage(options.Width, options.Height, options.Increment);
            }
        }

		public Image<Rgba32> Generate()
		{
            return Image.CreateImage();
		}
    }
}
