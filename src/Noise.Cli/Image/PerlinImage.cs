using ImageSharp;

namespace JetabroadNoise.Cli
{
    public abstract class PerlinImage
    {
        public int Width { get; set; }

        public abstract Image<Rgba32> CreateImage();
	}
}
