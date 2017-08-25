﻿using System;
using ImageSharp;

namespace JetabroadNoise.Cli
{
    public class GrayScale
    {
        public static Rgba32 Create(double n)
		{
			var color = n * 255;
			var r = color;
			var g = color;
			var b = color;
			var a = 255;
			Console.Write($"r: {r}, g: {g}, b:xoffa: {n}");
			return new Rgba32((byte)r, (byte)g, (byte)b, (byte)a);
		}
    }
}
