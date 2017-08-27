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
            var terrain = new ImageGenerator(new MockOption(true));
            terrain.Image.Should().BeOfType<TerrainImage>();
        }

        [Fact]
        public void ShouldGenerateGrayScaleImage()
        {
            var grayScale = new ImageGenerator(new MockOption(false));
            grayScale.Image.Should().BeOfType<GrayScaleImage>();
        }

        private class MockOption : IOption
        {
            public int Width { get; }
            public int Height { get; }
            public double Increment { get; }
            public bool IsTerrain { get; }

            public MockOption(bool isTerrain)
            {
                IsTerrain = isTerrain;
            }
        }
    }
}