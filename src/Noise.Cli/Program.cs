using System;
using DocoptNet;
using JetabroadNoise.Cli.Images;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli
{
    public class Program
    {
        public const string Usage = @"Jetabroad Noise.

    Usage:
      jetabroadNoise [--height=<h>] [--width=<w>] [--inc=<inc>] [--terrain] 
      jetabroadNoise (-h | --help)
      jetabroadNoise --version

    Options:
      -h --help       Show this screen.
      --version       Show version.
      --height=<h>    Size of the picture [default: 128].
      --width=<w>     Size of the picture [default: 128].
      --inc=<inc>     Set the increment of Perlin Noise, small numbers generate smooth pattern, big numbers generate rough pattern [default: 0.05].
      --terrain       Output a Perlin noise terrain map.

    ";

        public static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(Usage, args, version: $"{nameof(JetabroadNoise)} 0.0.1", exit: true);
            var options = new DocoptOption(arguments);

            Console.WriteLine("Welcome, I'am generating your image.\n");
            var generator = new ImageGenerator(options);
            var image = generator.Generate();

            var imageName = $"{DateTime.Now.Ticks}.png"; 
            image.Save(imageName);
            Console.WriteLine($"Done. Image generated at local folder: {imageName}\n");
            Console.WriteLine($"Created with <3 by @kidchenko - {DateTime.Now.Year}");
        }
    }
}
