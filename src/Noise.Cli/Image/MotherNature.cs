using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public static class MotherNature
    {
        public static int snow;
        public static int medium;
        public static int forest;
        public static int ocean;
        public static int water;
        public static int beach;
        public static int grass;

		public static Rgba32 OCEAN = new Rgba32(4, 74, 175, 255);

		public static Rgba32 WATER = new Rgba32(93, 128, 253, 255);

		public static Rgba32 SAND = new Rgba32(228, 229, 172, 255);

		public static Rgba32 GRASS = new Rgba32(136, 170, 85, 255);

		public static Rgba32 FOREST = new Rgba32(51, 119, 85, 255);

		public static Rgba32 MOUNTAIN = new Rgba32(85, 85, 85, 255);

		public static Rgba32 SNOW = new Rgba32(221, 221, 221, 255);

        private const double OCEAN_LEVEL = 0.07;

        private const double WATER_LEVEL = 0.11;

        private const double SAND_LEVEL = 0.15;

		private const double ICE_LEVEL = 0.7;

		private const double MOUNTAIN_LEVEL = 0.5;

		private const double FOREST_LEVEL = 0.3;

        public static Rgba32 Create(double e, double m)
        {
            if (e < OCEAN_LEVEL)
			{
				Console.Write("o");
				ocean++;
				return OCEAN;
			}
            if (e < WATER_LEVEL)
			{
				Console.Write("w");
				water++;
				return WATER;
			}

            if (e < SAND_LEVEL)
			{
				Console.Write("b");
				beach++;
				return SAND;
			}

            if (e > ICE_LEVEL)
			{
				Console.Write("s");
				snow++;
				//if (m < 0.1) return new Rgba32(85, 85, 85, 255);
				//            if (m < 0.2) return new Rgba32(136, 136, 136, 255);
				//if (m < 0.5) return new Rgba32(187, 187, 170, 255);
				return SNOW;
			}

			if (e > MOUNTAIN_LEVEL)
			{
				Console.Write("m");
				medium++;
				//            if (m < 0.33) return new Rgba32(201, 210, 155, 255);
				//if (m < 0.66) return new Rgba32(136, 153, 119, 255);
				return MOUNTAIN;
			}

            if (e > FOREST_LEVEL)
			{
				Console.Write("f");
				forest++;
				//if (m < 0.16) return new Rgba32(201, 210, 155, 255);
				//if (m < 0.50) return new Rgba32(136, 170, 85, 255); ;
				//if (m < 0.83) return new Rgba32(103, 148, 89, 1);
				return FOREST;
			}
			Console.Write("g");
			grass++;
			//if (m < 0.16) return new Rgba32(230, 230, 70, 255);
			//if (m < 0.33) return new Rgba32(136, 170, 85, 255);
			//if (m < 0.66) return new Rgba32(85, 153, 68, 255);
			return MotherNature.GRASS;
            
        }
	}
}
