using System;
using Xunit;

namespace JetabroadNoise.Cli.Test.Unit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var result = ImprovedPerlin.Noise(1, 1, 1);
            Console.WriteLine(result);
        }
    }
}
