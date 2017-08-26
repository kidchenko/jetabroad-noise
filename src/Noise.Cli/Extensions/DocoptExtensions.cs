using System;
using DocoptNet;

namespace JetabroadNoise.Cli.Extensions
{
    public static class DocoptExtensions
    {
        public static double AsDouble(this ValueObject valueObject) 
        {
            return Convert.ToDouble(valueObject.Value);
        }
    }
}
