using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class GrayScaleImage : IPerlinImage
    {
        private ImageGenerator _generator;

        public GrayScaleImage(ImageGenerator generator)
        {
            _generator = generator;
        }

        public Image<Rgba32> CreateImage()
        {
            var xinit = _generator.RandomDouble();
            var yinit = _generator.RandomDouble();
            var width = _generator._options.Width;
            var height = _generator._options.Height;
            var inc = _generator._options.Increment;

            using (var _image = new Image<Rgba32>(width, height))
            {
                var yoff = yinit;
                for (var y = 0; y < height; y++)
                {
                    var xoff = xinit;
                    for (var x = 0; x < width; x++)
                    {
                        var noise = ImprovedPerlin.Noise(xoff, yoff);

                        _image.GetPixelReference(x, y) = GrayScale.Create(noise);
                        xoff += inc;
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    yoff += inc;
                }
			return new Image<Rgba32>(_image);
            }
        }
    }


}
