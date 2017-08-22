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

            var inc = 0.005;
            var width = 128;
            var height = 128;
            var random = new Random();
            var xinit = (double) random.Next();
            var yinit = (double) random.Next();

            using (Image<Rgba32> image = new Image<Rgba32>(width, height))
            {
                var yoff = yinit;
                for (var y = 0; y < height; y++)
                {
                    var xoff = xinit;
					for (var x = 0; x < width; x++)
                    {
                        var noise = (float) (ImprovedNoise.Perlin(xoff, yoff, 0) * 255);
                        var r = noise;
                        var g = noise;
                        var b = noise;
                        var a = 255;

                        image.GetPixelReference(x, y) = new Rgba32((byte)r, (byte)g, (byte)b, (byte)a);
                        xoff += inc;
                    }
                    yoff += inc;
                }
                image.Save($"{DateTime.Now.Ticks}.png");
            }
        }
    }
}
