using System;
using ImageSharp;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli.Image
{
    public class TerrainImage : PerlinImage
    {
        private double _yoff;
        private double _yoff2;
        private double _xoff;
        private double _xoff2;
        
        private readonly int _width;
        private readonly int _height;        
        
        private readonly double _inc;


        private readonly double _xinit;

        private readonly double _xinit2;

        private readonly double _yinit;

        private readonly double _yinit2;

        private Image<Rgba32> _image;

        public TerrainImage(IOptions options)
        {
            _height = options.Height;
            _width = options.Width;
            _inc = options.Increment;
            _xinit = GenerateSeedValue();
            _yinit = GenerateSeedValue();
            _xinit2 = GenerateSeedValue();
            _yinit2 = GenerateSeedValue();
        }

        public override Image<Rgba32> CreateImage()
        {
            CreateYOff();

            using (_image = new Image<Rgba32>(_width, _height))
            {
                for (var y = 0; y < _height; y++)
                {
                    CreateXOff();
                    for (var x = 0; x < _width; x++)
                    {
                        FillImage(x, y);
                    }
                    IncrementYOff();
                }
                return new Image<Rgba32>(_image);
            }
        }

        private void FillImage(int x, int y)
        {
            var e = GetPerlinNumber();
            var m = GetMNumber();

            _image.GetPixelReference(x, y) = MotherNature.Create(e, m);
            IncrementXOff();
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
            m /= 1.00 + 0.75 + 0.33 + 0.33 + 0.33 + 0.50;
			return m;
        }

        private void CreateXOff()
        {
            _xoff = _xinit;
            _xoff2 = _xinit2;
        }

        private void CreateYOff()
        {
            _yoff = _yinit;
            _yoff2 = _yinit2;
        }


        private void IncrementXOff()
        {
            _xoff += _inc;
            _xoff2 += _inc;
        }

        private void IncrementYOff()
        {
            _yoff += _inc;
            _yoff2 += _inc;
        }
    }
}
