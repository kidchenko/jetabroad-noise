using FluentAssertions;
using JetabroadNoise.Cli.Image;
using JetabroadNoise.Cli.Options;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit.Image
{
    public class ImageGeneratorTest
    {
        [Fact]
        public void ShouldGenerateTerrainImage()
        {
            var terrain = new ImageGenerator(new MockOptions(true));
            terrain.Image.Should().BeOfType<TerrainImage>();
        }

        [Fact]
        public void ShouldGenerateGrayScaleImage()
        {
            var grayScale = new ImageGenerator(new MockOptions(false));
            grayScale.Image.Should().BeOfType<GrayScaleImage>();
        }

        private class MockOptions : IOptions
        {
            public int Width { get; }
            public int Height { get; }
            public double Increment { get; }
            public bool IsTerrain { get; }

            public MockOptions(bool isTerrain)
            {
                IsTerrain = isTerrain;
            }
        }
    }
}