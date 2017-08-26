using Xunit;
using FluentAssertions;

namespace JetabroadNoise.Cli.Test.Unit
{
    public class MotherNatureTest
    {
        [Fact]
        public void ShouldCreateOcean()
        {
            var biome = MotherNature.Create(0.06, 0);
            biome.Should().Be(MotherNature.OCEAN);
        }

        [Fact]
        public void ShouldCreateWater()
        {
            var biome = MotherNature.Create(0.08, 0);
            biome.Should().Be(MotherNature.WATER);
        }

		[Fact]
		public void ShouldCreateSand()
		{
			var biome = MotherNature.Create(0.12, 0);
			biome.Should().Be(MotherNature.SAND);
		}

        [Fact]
		public void ShouldCreateIce()
		{
			var biome = MotherNature.Create(0.77, 0);
            biome.Should().Be(MotherNature.SNOW);
		}

		[Fact]
		public void ShouldCreateMountain()
		{
			var biome = MotherNature.Create(0.55, 0);
			biome.Should().Be(MotherNature.MOUNTAIN);
		}

		[Fact]
		public void ShouldCreateForest()
		{
			var biome = MotherNature.Create(0.44, 0);
            biome.Should().Be(MotherNature.FOREST);
		}

		[Fact]
		public void ShouldCreateGrass()
		{
			var biome = MotherNature.Create(0.27, 0);
			biome.Should().Be(MotherNature.GRASS);
		}
    }
}
