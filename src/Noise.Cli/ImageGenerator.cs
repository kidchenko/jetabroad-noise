using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class ImageGenerator
    {
        private ImageGeneratorOptions _options;
        private Image<Rgba32> _image;
        private Random _seed = new Random();

        public ImageGenerator(ImageGeneratorOptions options)
        {
            _options = options;
        }

		public Image<Rgba32> Generate()
		{
			if (_options.IsTerrain)
			{
				return CreateTerrain(_options.Width, _options.Height, _options.Increment);

			}
			return CreateImage(_options.Width, _options.Height, _options.Increment);
		}

        private Image<Rgba32> CreateImage(int width, int height, double inc)
        {
			var xinit = RandomDouble();
			var yinit = RandomDouble();

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


        private double RandomDouble()
        {
            return _seed.NextDouble() * _seed.Next();
        }


        private Image<Rgba32> CreateTerrain(int width, int height, double inc)
        {
            var xinit1 = RandomDouble();
            var yinit1 = RandomDouble();
            var xinit2 = RandomDouble();
            var yinit2 = RandomDouble();
			var yoff = yinit1;
			var yoff2 = yinit2;

            using (_image = new Image<Rgba32>(width, height))
            {
                for (var y = 0; y < height; y++)
                {
                    var xoff1 = xinit1;
                    var xoff2 = xinit2;
                    for (var x = 0; x < width; x++)
                    {
                        var e = (1.00 * ImprovedPerlin.Noise(xoff1, yoff)
                                + 0.50 * ImprovedPerlin.Noise(xoff1, yoff)
                                + 0.25 * ImprovedPerlin.Noise(xoff1, yoff)
                                + 0.13 * ImprovedPerlin.Noise(xoff1, yoff)
                                + 0.06 * ImprovedPerlin.Noise(xoff1, yoff));

                        e /= (1.00 + 0.50 + 0.25 + 0.13 + 0.06);
                        e = Math.Pow(e, 2.2);

                        var m = (1.00 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.75 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.50 * ImprovedPerlin.Noise(xoff2, yoff2));
                        m /= (1.00 + 0.75 + 0.33 + 0.33 + 0.33 + 0.50);

                        _image.GetPixelReference(x, y) = MotherNature.Create(e, m);
                        xoff1 += inc;
                        xoff2 += inc;
                    }
                    Console.WriteLine("\n");
                    yoff += inc;
                    yoff2 += inc;
                }

				Console.WriteLine($"ocean: {MotherNature.ocean}");
				Console.WriteLine($"water: {MotherNature.water}");
				Console.WriteLine($"beach {MotherNature.beach}");
				Console.WriteLine($"grass {MotherNature.grass}");
				Console.WriteLine($"forest {MotherNature.forest}");
				Console.WriteLine($"medium {MotherNature.medium}");
				Console.WriteLine($"snow {MotherNature.snow}");
				return new Image<Rgba32>(_image);
            }
        }
    }
}
