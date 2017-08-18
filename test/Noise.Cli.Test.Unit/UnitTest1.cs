using System;
using Xunit;

namespace Noise.Cli.Test.Unit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result = ImprovedNoise.Perlin(1, 1, 1);
            Console.WriteLine(result);
        }
    }
}
