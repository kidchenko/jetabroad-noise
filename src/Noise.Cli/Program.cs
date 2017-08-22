using System;
using DocoptNet;
using ImageSharp;


namespace Noise.Cli
{
    internal class Program
    {
        private const string usage = @"Naval Fate.

    Usage:
      noise.cli.exe ship new <name>...
      noise.cli.exe ship <name> move <x> <y> [--speed=<kn>]
      noise.cli.exe ship shoot <x> <y>
      noise.cli.exe mine (set|remove) <x> <y> [--moored | --drifting]
      noise.cli.exe (-h | --help)
      noise.cli.exe --version

    Options:
      -h --help     Show this screen.
      --version     Show version.
      --speed=<kn>  Speed in knots [default: 10].
      --moored      Moored (anchored) mine.
      --drifting    Drifting mine.

    ";

        private static void Main(string[] args)
        {
            //var arguments = new Docopt().Apply(usage, args, version: "Naval Fate 2.0", exit: true);
            var width = 128;
            var height = 128;
            var random = new Random();

            using (Image<Rgba32> image = new Image<Rgba32>(width, height))
            {
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var a = (byte) random.Next(256);
                        var r = (byte) random.Next(256);
                        var g = (byte) random.Next(256);
                        var b = (byte) random.Next(256);

                        //image.GetRowSpan();
                        image.GetRowSpan(x, y).Fill(new Rgba32(r, g, b, a));
                        Console.Write($"{y}x{x}p{ImprovedNoise.Perlin(x, y, 1)}");
                    }
                    Console.WriteLine();
                }
                image.Save("image.png");
            }
        }
    }
}
