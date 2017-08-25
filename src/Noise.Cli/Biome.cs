using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public static class Biome
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

        public static Rgba32 Create(double e, double m)
        {
			if (e < 0.07)
			{
				Console.Write("o");
				ocean++;
				return OCEAN;
			}
			if (e < 0.12)
			{
				Console.Write("w");
				water++;
				return WATER;
			}

			if (e < 0.15)
			{
				Console.Write("b");
				beach++;
				return SAND;
			}

			if (e > 0.7)
			{
				Console.Write("s");
				snow++;
				//if (m < 0.1) return new Rgba32(85, 85, 85, 255);
				//            if (m < 0.2) return new Rgba32(136, 136, 136, 255);
				//if (m < 0.5) return new Rgba32(187, 187, 170, 255);
				return SNOW;
			}

			if (e > 0.5)
			{
				Console.Write("m");
				medium++;
				//            if (m < 0.33) return new Rgba32(201, 210, 155, 255);
				//if (m < 0.66) return new Rgba32(136, 153, 119, 255);
				return MOUNTAIN;
			}

			if (e > 0.3)
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
			return Biome.GRASS;
            
        }
	}
}
