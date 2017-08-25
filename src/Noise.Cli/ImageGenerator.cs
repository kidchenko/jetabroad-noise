using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class ImageGenerator
    {
        private ImageGeneratorOptions _options;
        private Image<Rgba32> _image;

        public ImageGenerator(ImageGeneratorOptions options)
        {
            _options = options;
        }

        private Image<Rgba32> GenerateImage(int width, int height, double inc, bool isTerrain)
        {
            var random = new Random();
            var xinit = (double)random.Next();
            var yinit = (double)random.Next();

            if (isTerrain)
            {
                return CreateTerrain(width, height, inc, xinit, yinit);

            }
            return CreateImage(width, height, inc, xinit, yinit);
        }

        private Image<Rgba32> CreateImage(int width, int height, double inc, double xinit, double yinit)
        {
            using (_image = new Image<Rgba32>(width, height))
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
			}
            return new Image<Rgba32>(_image);
        }

        public Image<Rgba32> Generate()
        {
            return GenerateImage(_options.Width, _options.Height, _options.Increment, _options.IsTerrain);
        }

        private Image<Rgba32> CreateTerrain(int width, int height, double inc, double xinit, double yinit)
        {
            var random = new Random();
            var xinit2 = (double)random.Next();
            var yinit2 = (double)random.Next();

            using (_image = new Image<Rgba32>(width, height))
            {
                var yoff = yinit;
                var yoff2 = yinit2;
                for (var y = 0; y < height; y++)
                {
                    var xoff = xinit;
                    var xoff2 = xinit2;
                    for (var x = 0; x < width; x++)
                    {
                        var e = (1.00 * ImprovedPerlin.Noise(xoff, yoff)
                                + 0.50 * ImprovedPerlin.Noise(xoff, yoff)
                                + 0.25 * ImprovedPerlin.Noise(xoff, yoff)
                                + 0.13 * ImprovedPerlin.Noise(xoff, yoff)
                                 + 0.06 * ImprovedPerlin.Noise(xoff, yoff));

                        e /= (1.00 + 0.50 + 0.25 + 0.13 + 0.06);
                        e = Math.Pow(e, 2.2);

                        var m = (1.00 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.75 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.50 * ImprovedPerlin.Noise(xoff2, yoff2));
                        m /= (1.00 + 0.75 + 0.33 + 0.33 + 0.33 + 0.50);

                        _image.GetPixelReference(x, y) = Biome.Create(e, m);
                        xoff += inc;
                        xoff2 += inc;
                    }
                    Console.WriteLine("\n");
                    yoff += inc;
                    yoff2 += inc;
                }

            }
            Console.WriteLine($"ocean: {Biome.ocean}");
            Console.WriteLine($"water: {Biome.water}");
            Console.WriteLine($"beach {Biome.beach}");
            Console.WriteLine($"grass {Biome.grass}");
            Console.WriteLine($"forest {Biome.forest}");
            Console.WriteLine($"medium {Biome.medium}");
            Console.WriteLine($"snow {Biome.snow}");
            return new Image<Rgba32>(_image);
        }
    }
}
