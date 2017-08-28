using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FluentAssertions;
using ImageSharp;
using JetabroadNoise.Cli.Pixel;
using Xunit;

namespace JetabroadNoise.Cli.Test.Acceptance
{
    public class NoiseCliTest : IDisposable
    {
	    private readonly Random _seed = new Random();
	    
	    public NoiseCliTest()
	    {
		    Clean();
	    }
	    
	    [Fact]
		public void GenerateImage()
		{
			var randomPixelX = _seed.Next(127);
			var randomPixelY = _seed.Next(127);

			Program.Main(Array.Empty<string>());
			var images = LookupImages();
			ImageExist(images).Should().BeTrue();
			
			var loadedImage = LoadImage(images.First());
			var rgba = loadedImage.GetPixelReference(randomPixelX, randomPixelY);

			// in grayscale RGB have the same value
			rgba.R.Should().Be(rgba.G);
			rgba.G.Should().Be(rgba.B);
			rgba.B.Should().Be(rgba.G);
		}

		[Fact]
		public void GenerateTerrain()
		{
			var randomPixelX = _seed.Next(127);
			var randomPixelY = _seed.Next(127);
			var allTerrainPixels = new List<Rgba32>
			{
				MotherNature.FOREST, 
				MotherNature.GRASS, 
				MotherNature.MOUNTAIN,
				MotherNature.OCEAN,
				MotherNature.SAND,
				MotherNature.SNOW,
				MotherNature.WATER
			};
			
			Program.Main(new []{"--terrain"});
			var images = LookupImages();
			ImageExist(images).Should().BeTrue();

			var loadedImage = LoadImage(images.First());
			var rgba = loadedImage.GetPixelReference(randomPixelX, randomPixelY);
			
			// assert if the pixel picked is one of created by nature
			allTerrainPixels.Should().Contain(rgba);
		}

		[Fact]
		public void ChangeImageSize()
		{
			const int width = 300;
			const int height = 300;
			
			Program.Main(new[] {$"--height={height}", $"--width={width}"});
			var images = LookupImages();
			ImageExist(images).Should().BeTrue();
			
			var loadedImage = ImageSharp.Image.Load<Rgba32>(images.First());
			loadedImage.Height.Should().Be(height);
			loadedImage.Height.Should().Be(width);
		}

	    private string[] LookupImages()
	    {
		    return Directory.GetFiles(".", "*.png", SearchOption.TopDirectoryOnly);   
	    }

	    private void Clean()
	    {
		    var images = LookupImages();
		    if (ImageExist(images))
		    {
			    foreach (var image in images)
			    {
				    DeleteImage(image);
			    }
		    }
	    }

	    private void DeleteImage(string fileName)
	    {
		    File.Delete(fileName);
	    }

	    private bool ImageExist(string[] images)
	    {
		    return images.Length > 0;
	    }

	    private Image<Rgba32> LoadImage(string name)
	    {
		    return ImageSharp.Image.Load<Rgba32>(name);
	    }

	    public void Dispose()
	    {
		    Clean();
	    }
    }
}
