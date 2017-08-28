using System;
using ImageSharp;

namespace JetabroadNoise.Cli.Pixel
{
    public class MotherNature : IPixelCreator
    {
	    private const double OceanLevel = 0.07;

	    private const double WaterLevel = 0.11;

	    private const double SandLevel = 0.15;

	    private const double IceLevel = 0.7;

	    private const double MountainLevel = 0.5;

	    private const double ForestLevel = 0.3;
	    
	    // ReSharper disable InconsistentNaming
	    
		public static Rgba32 OCEAN = new Rgba32(4, 74, 175, 255);

		public static Rgba32 WATER = new Rgba32(93, 128, 253, 255);

		public static Rgba32 SAND = new Rgba32(228, 229, 172, 255);

		public static Rgba32 GRASS = new Rgba32(136, 170, 85, 255);

		public static Rgba32 FOREST = new Rgba32(51, 119, 85, 255);

		public static Rgba32 MOUNTAIN = new Rgba32(85, 85, 85, 255);

		public static Rgba32 SNOW = new Rgba32(221, 221, 221, 255);
	    
	    // ReSharper enable InconsistentNaming

        public Rgba32 Create(double e)
        {
            if (e < OceanLevel)
			{
				Console.Write("o");
				return OCEAN;
			}
            if (e < WaterLevel)
			{
				Console.Write("w");
				return WATER;
			}

            if (e < SandLevel)
			{
				Console.Write("b");
				return SAND;
			}

            if (e > IceLevel)
			{
				Console.Write("s");
				return SNOW;
			}

			if (e > MountainLevel)
			{
				Console.Write("m");
				return MOUNTAIN;
			}

            if (e > ForestLevel)
			{
				Console.Write("f");
				return FOREST;
			}
			Console.Write("g");
			return GRASS;
            
        }
	}
}
