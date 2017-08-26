using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class ImageGenerator
    {
        public ImageOptions _options;
        private PerlinImage _image;

        public ImageGenerator(ImageOptions options)
        {
            _options = options;
            if (options.IsTerrain) 
            {
                _image = new TerrainImage(options);
            }
            else
            {
                _image = new GrayScaleImage(this);
            }
        }

		public Image<Rgba32> Generate()
		{
            return _image.CreateImage();
		}
    }
}
