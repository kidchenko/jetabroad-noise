using ImageSharp;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli.Images
{
    /// <summary>
    /// A class to generate image.
    /// </summary>
    public class ImageGenerator
    {
        public PerlinImage Image { get; }
        
        /// <summary>
        /// Create a generator based in your options. 
        /// </summary>
        /// <param name="option"></param>
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
