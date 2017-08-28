using System.Collections.Generic;
using FluentAssertions;
using ImageSharp;
using JetabroadNoise.Cli.Images;
using JetabroadNoise.Cli.Pixels;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit.Images
{
    public class TerrainImageTest
    {
        [Fact]
        public void ShouldHaveHeight()
        {
            var image = new TerrainImage(50, 100, 0.1);
            image.Height.Should().Be(100);
        }

        [Fact]
        public void ShouldHaveWidth()
        {
            var image = new TerrainImage(50, 100, 0.1);
            image.Width.Should().Be(50);
        }

        [Fact]
        public void ShouldHaveInitialXValue()
        {
            var image = new TerrainImage(100, 100, 0.1);
            image.InititalSpaceX.Should().NotBe(0);
        }
        
        [Fact]
        public void ShouldHaveInitialYValue()
        {
            var image = new TerrainImage(100, 100, 0.1);
            image.InititalSpaceY.Should().NotBe(0);
        }

        [Fact]
        public void ShouldHaveMotherNaturePixelCreator()
        {
            var image = new TerrainImage(1, 1, .1);
            image.PixelCreator.Should().BeOfType<MotherNature>();
        }
        
        [Fact]
        public void ShouldCreateTerrainImage()
        {
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
            var terrainImage = new TerrainImage(10, 10, .1);
            var image = terrainImage.CreateImage();
            var pixel = image.GetPixelReference(4, 4);
            allTerrainPixels.Should().Contain(pixel);
        }
    }
}