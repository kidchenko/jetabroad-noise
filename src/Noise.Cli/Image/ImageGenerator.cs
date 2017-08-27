using ImageSharp;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli.Image
{
    public class ImageGenerator
    {
        public readonly RandomImage Image;
        
        public ImageGenerator(IOption option)
        {
            if (option.IsTerrain) 
            {
                Image = new TerrainImage(option.Width, option.Height, option.Increment);
            }
            else
            {
                Image = new GrayScaleImage(option.Width, option.Height, option.Increment);
            }
        }

		public Image<Rgba32> Generate()
		{
            return Image.CreateImage();
		}
    }
}
