using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class ImageGenerator
    {
        public ImageGeneratorOptions _options;
        private IPerlinImage _image;
        private Random _seed = new Random();

        public ImageGenerator(ImageGeneratorOptions options)
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
