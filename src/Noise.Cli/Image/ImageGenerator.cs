using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class ImageGenerator
    {
        public ImageOptions _options;
        private PerlinImage _image;
        private Random _seed = new Random();

        public ImageGenerator(ImageOptions options)
        {
            _options = options;
            if (options.IsTerrain) 
            {
                _image = new TerrainImage(this);
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

        public double RandomDouble()
        {
            return _seed.NextDouble() * _seed.Next();
        }
    }
}
