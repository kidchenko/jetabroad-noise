using ImageSharp;

namespace JetabroadNoise.Cli
{
    public interface IPerlinImage
    {
        Image<Rgba32> CreateImage();
	}
}
