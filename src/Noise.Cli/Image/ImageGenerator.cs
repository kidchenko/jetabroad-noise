using ImageSharp;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli.Image
{
    public class ImageGenerator
    {
        public IOptions Options;
        private readonly RandomImage _image;
        

        public ImageGenerator(IOptions options)
        {
            Options = options;
            if (options.IsTerrain) 
            {
                _image = new TerrainImage(options.Width, options.Height, options.Increment);
            }
            else
            {
                _image = new GrayScaleImage(options.Width, options.Height, options.Increment);
            }
        }

		public Image<Rgba32> Generate()
		{
            return _image.CreateImage();
		}
    }
}
