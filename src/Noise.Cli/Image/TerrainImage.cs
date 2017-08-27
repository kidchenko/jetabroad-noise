using System;
using ImageSharp;
using JetabroadNoise.Cli.Pixel;

namespace JetabroadNoise.Cli.Image
{
    public class TerrainImage : RandomImage
    {
        private double _yoff2;
        private double _xoff2;
        private readonly MotherNature _nature = new MotherNature();
        private readonly double _xinit2;
        private readonly double _yinit2;

        public TerrainImage(int width, int height, double increment) : base(width, height, increment)
        {
            _xinit2 = GenerateRandomValue();
            _yinit2 = GenerateRandomValue();
        }

        protected override Rgba32 CreatePixel()
        {
            var e = CalculateElevation();
            var m = CalculateClimate();

            return _nature.Create(e, m);
         
        }
            
        private double CalculateElevation()
        {
            var e = (1.00 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.50 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.25 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.13 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY)
                                + 0.06 * ImprovedPerlin.Noise(PerlinSpaceX, PerlinSpaceY));
            e /= (1.00 + 0.50 + 0.25 + 0.13 + 0.06);
            e = Math.Pow(e, 2.2);
            return e;
        }

        public double CalculateClimate()
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

        protected override void MoveSpaceXToInitialValue()
        {
            base.MoveSpaceXToInitialValue();
            _xoff2 = _xinit2;
        }

        protected override void MoveSpaceYToInititalValue()
        {
            base.MoveSpaceYToInititalValue();
            _yoff2 = _yinit2;
        }

        protected override void MoveXSpace()
        {
            base.MoveXSpace();
            _xoff2 += Increment;
        }

        protected override void MoveYSpace()
        {
            base.MoveYSpace();
            _yoff2 += Increment;
        }
    }
}
