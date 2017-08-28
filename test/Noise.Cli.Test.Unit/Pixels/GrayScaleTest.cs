using FluentAssertions;
using JetabroadNoise.Cli.Pixels;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit.Pixel
{
    public class GrayScaleTest
    {
        [Fact]
        public void CreatedPixelShouldHaveTheSameValue()
        {
            var grayScale = new Monochrome();
            var pixel = grayScale.Create(0.7d);
            pixel.R.Should().Be(pixel.G);
            pixel.G.Should().Be(pixel.B);
            pixel.B.Should().Be(pixel.R);
        }

        [Fact]
        public void CreatedPixelShouldHaveAlpha()
        {
            var grayScale = new Monochrome();
            var pixel = grayScale.Create(0.5d);
            pixel.A.Should().Be(255);
        }
    }
}