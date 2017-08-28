using ImageSharp;

namespace JetabroadNoise.Cli.Pixels
{
    public interface IPixelCreator
    {
        Rgba32 Create(double noise);
    }
}