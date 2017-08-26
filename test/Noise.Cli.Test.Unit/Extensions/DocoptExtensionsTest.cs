using DocoptNet;
using FluentAssertions;
using JetabroadNoise.Cli.Extensions;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit.Extensions
{
    public class DocoptExtensionsTest
    {
        [Fact]
        public void ShouldReturnArgumentAsDouble()
        {
			var args = new Docopt().Apply(Program.Usage, "--inc=0.02");
			args["--inc"].AsDouble().Should().Be(0.02D);
        }
    }
}
