using System;
using ImageSharp;

namespace JetabroadNoise.Cli.Pixel
{
    public class MotherNature
    {
	    private const double OceanLevel = 0.07;

	    private const double WaterLevel = 0.11;

	    private const double SandLevel = 0.15;

	    private const double IceLevel = 0.7;

	    private const double MountainLevel = 0.5;

	    private const double ForestLevel = 0.3;
	    
        public int Snow 	{ get; set; }
        public int Medium 	{ get; set; }
        public int Forest 	{ get; set; }
        public int Ocean 	{ get; set; }
        public int Water 	{ get; set; }
        public int Beach 	{ get; set; }
        public int Grass 	{ get; set; }

		public static Rgba32 OCEAN = new Rgba32(4, 74, 175, 255);

		public static Rgba32 WATER = new Rgba32(93, 128, 253, 255);

		public static Rgba32 SAND = new Rgba32(228, 229, 172, 255);

		public static Rgba32 GRASS = new Rgba32(136, 170, 85, 255);

		public static Rgba32 FOREST = new Rgba32(51, 119, 85, 255);

		public static Rgba32 MOUNTAIN = new Rgba32(85, 85, 85, 255);

		public static Rgba32 SNOW = new Rgba32(221, 221, 221, 255);

        public Rgba32 Create(double e, double m)
        {
            if (e < OceanLevel)
			{
				Console.Write("o");
				Ocean++;
				return OCEAN;
			}
            if (e < WaterLevel)
			{
				Console.Write("w");
				Water++;
				return WATER;
			}

            if (e < SandLevel)
			{
				Console.Write("b");
				Beach++;
				return SAND;
			}

            if (e > IceLevel)
			{
				Console.Write("s");
				Snow++;
				//if (m < 0.1) return new Rgba32(85, 85, 85, 255);
				//            if (m < 0.2) return new Rgba32(136, 136, 136, 255);
				//if (m < 0.5) return new Rgba32(187, 187, 170, 255);
				return SNOW;
			}

			if (e > MountainLevel)
			{
				Console.Write("m");
				Medium++;
				//            if (m < 0.33) return new Rgba32(201, 210, 155, 255);
				//if (m < 0.66) return new Rgba32(136, 153, 119, 255);
				return MOUNTAIN;
			}

            if (e > ForestLevel)
			{
				Console.Write("f");
				Forest++;
				//if (m < 0.16) return new Rgba32(201, 210, 155, 255);
				//if (m < 0.50) return new Rgba32(136, 170, 85, 255); ;
				//if (m < 0.83) return new Rgba32(103, 148, 89, 1);
				return FOREST;
			}
			Console.Write("g");
			Grass++;
			//if (m < 0.16) return new Rgba32(230, 230, 70, 255);
			//if (m < 0.33) return new Rgba32(136, 170, 85, 255);
			//if (m < 0.66) return new Rgba32(85, 153, 68, 255);
			return GRASS;
            
        }
	}
}
