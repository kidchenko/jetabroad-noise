using System;
using DocoptNet;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    internal class Program
    {
        private static int moutain = 0;
        private static int medium = 0;
        private static int small = 0;
        private static int floor = 0;
		private static int waterBeach = 0;
        private const string usage = @"Naval Fate.

    Usage:
      noise.cli.exe [--height=<h>] [--width=<w>] [--inc=<inc>] [--terrain] 
      noise.cli.exe (-h | --help)
      noise.cli.exe --version

    Options:
      -h --help       Show this screen.
      --version       Show version.
      --height=<h>    Size of the picture [default: 128].
      --width=<w>     Size of the picture [default: 128].
      --inc=<inc>     Set the increment of Perlin Noise [default: 0.05].
      --terrain       Output a Perlin noise terrain map.

    ";

        private static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: "Naval Fate 2.0", exit: true);

            var width = arguments["--height"].AsInt;
            var height = arguments["--width"].AsInt;
            var inc = Convert.ToDouble(arguments["--inc"].Value);
            var isTerrain = arguments["--terrain"].IsTrue;
            var scl = 20;
            var terrain = new float[width / scl, height / scl];

            GenerateImage(width, height, inc, isTerrain);
        }

        private static void GenerateImage(int width, int height, double inc, bool isTerrain)
        {
            var random = new Random();
            var xinit = (double)random.Next();
            var yinit = (double)random.Next();

            if (isTerrain)
            {
                CreateTerrain(width, height, inc, xinit, yinit);
                return;
            }
            CreateImage(width, height, inc, xinit, yinit);
        }

        private static void CreateImage(int width, int height, double inc, double xinit, double yinit)
        {
            using (Image<Rgba32> image = new Image<Rgba32>(width, height))
            {
                var yoff = yinit;
                for (var y = 0; y < height; y++)
                {
                    var xoff = xinit;
                    for (var x = 0; x < width; x++)
                    {
                        var noise = ImprovedPerlin.Noise(xoff, yoff);

                        image.GetPixelReference(x, y) = Pixel(noise);
                        xoff += inc;
                    }
                    Console.WriteLine("\n");
                    Console.WriteLine("\n");
                    yoff += inc;
                }
                image.Save($"{DateTime.Now.Ticks}.png");
            }

        }

        private static void CreateTerrain(int width, int height, double inc, double xinit, double yinit)
        {
            var random = new Random();
            var xinit2 = (double)random.Next();
            var yinit2 = (double)random.Next();


            using (Image<Rgba32> image = new Image<Rgba32>(width, height))
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
								+ 0.06 * ImprovedPerlin.Noise(xoff, yoff)
								+ 0.03 * ImprovedPerlin.Noise(xoff, yoff));
                        
						e /= (1.00 + 0.50 + 0.25 + 0.13 + 0.06 + 0.03);
                        e = Math.Pow(e, 3);

                        var m = (1.00 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.75 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.33 * ImprovedPerlin.Noise(xoff2, yoff2)
                               + 0.50 * ImprovedPerlin.Noise(xoff2, yoff2));
                        m /= (1.00 + 0.75 + 0.33 + 0.33 + 0.33 + 0.50);

                        image.GetPixelReference(x, y) = Biome(e, m);
                        xoff += inc;
                        xoff2 += inc;
                    }
                    Console.WriteLine("\n");
                    yoff += inc;
                    yoff2 += inc;
                }
                image.Save($"{DateTime.Now.Ticks}.png");
            }
            Console.WriteLine($"water and beach {waterBeach}");
			Console.WriteLine($"floor {floor}");
            Console.WriteLine($"small {small}");
            Console.WriteLine($"medium {medium}");
            Console.WriteLine($"mountain {moutain}");
        }


        private static Rgba32 Pixel(double n)
        {
            var color = n * 255;
            var r = color;
            var g = color;
            var b = color;
            var a = 255;
            Console.Write($"r: {r}, g: {g}, b:xoffa: {n}");
            return new Rgba32((byte)r, (byte)g, (byte)b, (byte)a);
        }

        private static Rgba32 Biome(double e, double m)
        {
            if (e < 15) 
            {
                Console.Write("w");
                waterBeach++;
				if (e < 0.07) return new Rgba32(10, 30, 120, 255);
				if (e < 0.12) return new Rgba32(93, 128, 253, 255);
				if (e < 0.15) return new Rgba32(210, 185, 139, 255);
            }

			if (e > 0.7)
			{
				Console.Write("i");
                moutain++;
				if (m < 0.1) return new Rgba32(85, 85, 85, 255);
                if (m < 0.2) return new Rgba32(136, 136, 136, 255);
				if (m < 0.5) return new Rgba32(187, 187, 170, 255);
                return new Rgba32(221, 221, 221, 255);
			}

			if (e > 0.5)
			{
				Console.Write("m");
                medium++;
                if (m < 0.33) return new Rgba32(201, 210, 155, 255);
				if (m < 0.66) return new Rgba32(136, 153, 119, 255);
                return new Rgba32(153, 170, 119, 255);
			}

			if (e > 0.3)
			{
				Console.Write("s");
                small++;
				if (m < 0.16) return new Rgba32(201, 210, 155, 255);
				if (m < 0.50) return new Rgba32(136, 170, 85, 255); ;
                if (m < 0.83) return new Rgba32(103, 148, 89, 1);
                return new Rgba32(68, 136, 85, 1);
			}
			Console.Write("f");
            floor++;
			if (m < 0.16) return new Rgba32(230, 230, 70, 255);
			if (m < 0.33) return new Rgba32(136, 170, 85, 255);
            if (m < 0.66) return new Rgba32(85, 153, 68, 255);
            return new Rgba32(51, 120, 85, 255);
		}
    }
}
