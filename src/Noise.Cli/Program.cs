using System;
using DocoptNet;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    class Program
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

        public static void Main(string[] args)
        {
            var arguments = new Docopt().Apply(usage, args, version: $"{nameof(JetabroadNoise)} 0.0.1", exit: true);
            var options = new ImageGeneratorOptions(arguments);

            var generator = new ImageGenerator(options);
            var image = generator.Generate();
            image.Save($"{DateTime.Now.Ticks}.png");
        }
    }
}
