using System;
using DocoptNet;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    internal class Program
    {
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

            GenerateImage(width, height, inc, isTerrain);
        }

        private static void GenerateImage(int width, int height, double inc, bool isTerrain)
        {
			var random = new Random();
			var xinit = (double)random.Next();
			var yinit = (double)random.Next();
			var zinit = 0d;

			using (Image<Rgba32> image = new Image<Rgba32>(width, height))
			{
				var yoff = yinit;
				for (var y = 0; y < height; y++)
				{
					var xoff = xinit;
					var zoff = zinit;
					for (var x = 0; x < width; x++)
					{
						zoff += inc;
                        var noise = ImprovedPerlin.Noise(xoff, yoff, zoff);

						image.GetPixelReference(x, y) = isTerrain ? Biome(noise) : Pixel(noise);
						xoff += inc;
					}
					Console.WriteLine("\n");
					Console.WriteLine("\n");
					yoff += inc;
				}
				image.Save($"{DateTime.Now.Ticks}.png");
			}
        }

        private static Rgba32 Pixel(double n)
        {
			var color = n * 255;
			var r = color;
			var g = color;
			var b = color;
			var a = 255;
            Console.Write($"r: {r}, g: {g}, b: {b}, a: {a}");
            return new Rgba32((byte)r, (byte)g, (byte)b, (byte)a);
		}

        private static Rgba32 Biome(double n) 
        {
            if (n < 0.1)
            {
                Console.Write("w ");
                return new Rgba32(68, 68, 122, 255);
            }
            if (n < 0.2)
            {
                Console.Write("b ");
                return new Rgba32(210, 185, 139, 255);
            }
            if (n < 0.3)
            {
                Console.Write("f ");
                return new Rgba32(136, 170, 85, 255);
            }
            if (n < 0.5)
            {
				Console.Write("j ");
                return new Rgba32(85, 153, 68, 255);
            }

			if (n < 0.7)
			{
				Console.Write("s ");
                return new Rgba32(51, 119, 85, 255);
			}
            if (n < 0.9)
            {
                Console.Write("d ");
                return new Rgba32(208, 208, 158, 255);
            }
            Console.Write("i ");
            return new Rgba32(221, 221, 228, 255);
        }
    }
}
