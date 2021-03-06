using FluentAssertions;
using JetabroadNoise.Cli.Pixels;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit.Pixel
{
    public class MotherNatureTest
    {
        [Fact]
        public void ShouldCreateOcean()
        {
            var biome = new MotherNature().Create(0.06);
            biome.Should().Be(MotherNature.OCEAN);
        }

        [Fact]
        public void ShouldCreateWater()
        {
            var biome = new MotherNature().Create(0.08);
            biome.Should().Be(MotherNature.WATER);
        }

		[Fact]
		public void ShouldCreateSand()
		{
			var biome = new MotherNature().Create(0.12);
			biome.Should().Be(MotherNature.SAND);
		}

        [Fact]
		public void ShouldCreateIce()
		{
			var biome = new MotherNature().Create(0.77);
            biome.Should().Be(MotherNature.SNOW);
		}

		[Fact]
		public void ShouldCreateMountain()
		{
			var biome = new MotherNature().Create(0.55);
			biome.Should().Be(MotherNature.MOUNTAIN);
		}

		[Fact]
		public void ShouldCreateForest()
		{
			var biome = new MotherNature().Create(0.44);
            biome.Should().Be(MotherNature.FOREST);
		}

		[Fact]
		public void ShouldCreateGrass()
		{
			var biome = new MotherNature().Create(0.27);
			biome.Should().Be(MotherNature.GRASS);
		}
    }
}
