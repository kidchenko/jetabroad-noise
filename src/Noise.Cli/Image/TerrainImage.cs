using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class TerrainImage : PerlinImage
    {
        private ImageGenerator _generator;

        public TerrainImage(ImageGenerator generator)
        {
            _generator = generator;
        }


        public override Image<Rgba32> CreateImage()
        {
			var xinit1 = _generator.RandomDouble();
			var yinit1 = _generator.RandomDouble();
			var xinit2 = _generator.RandomDouble();
			var yinit2 = _generator.RandomDouble();
			var yoff = yinit1;
			var yoff2 = yinit2;
			var width = _generator._options.Width;
			var height = _generator._options.Height;
			var inc = _generator._options.Increment;

			using (var _image = new Image<Rgba32>(width, height))
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
