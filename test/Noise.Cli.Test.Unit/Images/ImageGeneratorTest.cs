using System.IO;
using FluentAssertions;
using JetabroadNoise.Cli.Images;
using JetabroadNoise.Cli.Options;
using Moq;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit.Images
{
    public class ImageGeneratorTest
    {
        [Fact]
        public void ShouldGenerateTerrainImage()
        {
            var mock = new Mock<IOption>();
            mock.Setup(o => o.IsTerrain).Returns(true);
            
            var terrain = new ImageGenerator(mock.Object);
            terrain.Image.Should().BeOfType<TerrainImage>();
        }

        [Fact]
        public void ShouldGenerateGrayScaleImage()
        {
            var mock = new Mock<IOption>();

            var grayScale = new ImageGenerator(mock.Object);
            grayScale.Image.Should().BeOfType<GrayScaleImage>();
        }
    }
}