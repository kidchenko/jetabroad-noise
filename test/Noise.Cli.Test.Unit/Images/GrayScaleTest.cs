using FluentAssertions;
using JetabroadNoise.Cli.Images;
using JetabroadNoise.Cli.Pixels;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit.Images
{
    public class GrayScaleTest
    {
        [Fact]
        public void ShouldHaveHeight()
        {
            var image = new GrayScaleImage(50, 100, 0.1);
            image.Height.Should().Be(100);
        }

        [Fact]
        public void ShouldHaveWidth()
        {
            var image = new GrayScaleImage(50, 100, 0.1);
            image.Width.Should().Be(50);
        }

        [Fact]
        public void ShouldHaveInitialXValue()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            image.InititalSpaceX.Should().NotBe(0);
        }
        
        [Fact]
        public void ShouldHaveInitialYValue()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            image.InititalSpaceY.Should().NotBe(0);
        }

        [Fact]
        public void ShouldHavePerlinSpaceXEqualsInitialSpaceX()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            image.PerlinSpaceX.Should().Be(image.InititalSpaceX);
        }

        [Fact]
        public void ShouldHavePerlinSpaceYEqualsInitialSpaceY()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            image.PerlinSpaceY.Should().Be(image.InititalSpaceY);
        }

        [Fact]
        public void ShouldMoveXSpaceToOrigin()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            image.IncrementXSpace();
            image.MoveXSpaceToOrigin();
            image.PerlinSpaceX.Should().Be(image.InititalSpaceX);
        }

        [Fact]
        public void ShouldMoveSpaceYToOrigin()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            image.IncrementYSpace();
            image.MoveYSpaceToOrigin();
            image.PerlinSpaceY.Should().Be(image.InititalSpaceY);
        }

        [Fact]
        public void ShouldIncrementPerlinSpaceX()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            var initialx = image.InititalSpaceX; 
            image.IncrementXSpace();
            image.PerlinSpaceX.Should().NotBe(initialx);
            image.PerlinSpaceX.Should().Be(image.InititalSpaceX + image.Increment);
        }

        [Fact]
        public void ShouldIncrementPerlinSpaceY()
        {
            var image = new GrayScaleImage(100, 100, 0.1);
            var initialy = image.InititalSpaceY; 
            image.IncrementYSpace();
            image.PerlinSpaceY.Should().NotBe(initialy);
            image.PerlinSpaceY.Should().Be(image.InititalSpaceY + image.Increment);
        }

        [Fact]
        public void ShouldHaveGrayScalePixelCreator()
        {
            var image = new GrayScaleImage(1, 1, 1);
            image.PixelCreator.Should().BeOfType<Monochrome>();
        }
    }
}