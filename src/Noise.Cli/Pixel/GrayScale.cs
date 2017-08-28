using System;
using ImageSharp;

namespace JetabroadNoise.Cli.Pixel
{
    public class GrayScale : IPixelCreator
    {
        public Rgba32 Create(double n)
		{
			var color = (byte) (n * 255);
			var r = color;
			var g = color;
			var b = color;
			const byte alpha = 255;
			Console.Write($"r: {r}, g: {g}, b:xoffa: {n}");
			return new Rgba32(r, g, b, alpha);
		}
    }
}
