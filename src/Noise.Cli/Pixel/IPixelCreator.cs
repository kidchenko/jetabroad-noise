using ImageSharp;

namespace JetabroadNoise.Cli.Pixel
{
    public interface IPixelCreator
    {
        Rgba32 Create(double noise);
    }
}