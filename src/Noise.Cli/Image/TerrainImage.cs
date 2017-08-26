using System;
using System.Runtime.CompilerServices;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class TerrainImage : PerlinImage
    {
        private readonly ImageOptions _options;
        private double _yoff;
        private double _yoff2;
        private double _xoff;
        private double _xoff2;

        private double xinit;

        private double xinit2;

        private double yinit;

        private double yinit2;

        public TerrainImage(ImageOptions options)
        {
            _options = options;
            xinit = GenerateSeedValue();
            yinit = GenerateSeedValue();
            xinit2 = GenerateSeedValue();
            yinit2 = GenerateSeedValue();
        }

        public override Image<Rgba32> CreateImage()
        {
            CreateYOff();
            var width = _options.Width;
            var height = _options.Height;

            using (var _image = new Image<Rgba32>(width, height))
            {
                for (var y = 0; y < height; y++)
                {
                    CreateXOff();
                    for (var x = 0; x < width; x++)
                    {
                        var e = GetPerlinNumber();
						var m = GetMNumber();

                        _image.GetPixelReference(x, y) = MotherNature.Create(e, m);
                        IncrementXOff();
                    }
                    Console.WriteLine("\n");
                    IncrementYOff();
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

        private double GetPerlinNumber()
        {
            var e = (1.00 * ImprovedPerlin.Noise(_xoff, _yoff)
                                + 0.50 * ImprovedPerlin.Noise(_xoff, _yoff)
                                + 0.25 * ImprovedPerlin.Noise(_xoff, _yoff)
                                + 0.13 * ImprovedPerlin.Noise(_xoff, _yoff)
                                + 0.06 * ImprovedPerlin.Noise(_xoff, _yoff));
            e /= (1.00 + 0.50 + 0.25 + 0.13 + 0.06);
            e = Math.Pow(e, 2.2);
            return e;
        }

        public double GetMNumber()
        {
            var m = (1.00 * ImprovedPerlin.Noise(_xoff2, _yoff2)
        		 + 0.75 * ImprovedPerlin.Noise(_xoff2, _yoff2)
         		+ 0.33 * ImprovedPerlin.Noise(_xoff2, _yoff2)
         		+ 0.33 * ImprovedPerlin.Noise(_xoff2, _yoff2)
         		+ 0.33 * ImprovedPerlin.Noise(_xoff2, _yoff2)
         		+ 0.50 * ImprovedPerlin.Noise(_xoff2, _yoff2));
            m /= (1.00 + 0.75 + 0.33 + 0.33 + 0.33 + 0.50);
			return m;
        }

        private void CreateXOff()
        {
            _xoff = xinit;
            _xoff2 = xinit2;
        }

        private void CreateYOff()
        {
            _yoff = yinit;
            _yoff2 = yinit2;
        }


        private void IncrementXOff()
        {
            _xoff += _options.Increment;
            _xoff2 += _options.Increment;
        }

        private void IncrementYOff()
        {
            _yoff += _options.Increment;
            _yoff2 += _options.Increment;
        }
    }
}
