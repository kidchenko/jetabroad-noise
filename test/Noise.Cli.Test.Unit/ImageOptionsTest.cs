using System.Collections.Generic;
using DocoptNet;
using FluentAssertions;
using JetabroadNoise.Cli.Options;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit
{
    public class ImageOptionsTest
    {
        [Fact]
        public void ShouldParseHeight()
        {
            var args = CreateDocoptArgs("--height=320");
            var option = new DocoptOptions(args);
            option.Height.Should().Be(320);
        }

		[Fact]
		public void ShouldParseWidth()
		{
            var args = CreateDocoptArgs("--width=320");
			var option = new DocoptOptions(args);
            option.Width.Should().Be(320);
		}

		[Fact]
		public void ShouldParseTerrain()
		{
            var args = CreateDocoptArgs("--terrain");
			var option = new DocoptOptions(args);
            option.IsTerrain.Should().BeTrue();
		}

		[Fact]
		public void ShouldParseIncrement()
		{
            var args = CreateDocoptArgs("--inc=0.01");
			var option = new DocoptOptions(args);
            option.Increment.Should().Be(0.01d);
		}

        [Fact]
        public void ShouldParseDefaultValues()
        {
            var args = CreateDocoptArgs("");
			var option = new DocoptOptions(args);
            option.Height.Should().Be(128);
            option.Width.Should().Be(128);
			option.Increment.Should().Be(0.05d);
            option.IsTerrain.Should().BeFalse();
        }

        private IDictionary<string, ValueObject> CreateDocoptArgs(string args)
        {
            return new Docopt().Apply(Program.Usage, args);
        }
    }
}
