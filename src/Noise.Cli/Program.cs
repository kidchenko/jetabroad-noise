using System;
using DocoptNet;

namespace Noise.Cli
{
    class Program
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
			var arguments = new Docopt().Apply(usage, args, version: "Naval Fate 2.0", exit: true);
			foreach (var argument in arguments)
			{
				Console.WriteLine("{0} = {1}", argument.Key, argument.Value);
			}
		}
    }
}
