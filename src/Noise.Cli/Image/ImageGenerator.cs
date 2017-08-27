using ImageSharp;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli.Image
{
    public class ImageGenerator
    {
        public IOptions Options;
        private readonly PerlinImage _image;

        public ImageGenerator(IOptions options)
        {
            Options = options;
            if (options.IsTerrain) 
            {
                _image = new TerrainImage(options);
            }
            else
            {
                _image = new GrayScaleImage(options);
            }
        }

		public Image<Rgba32> Generate()
		{
            return _image.CreateImage();
		}
    }
}
