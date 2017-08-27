using ImageSharp;

namespace JetabroadNoise.Cli.Image
{
    public class GrayScaleImage : RandomImage
    {
	    private readonly double _xinit;
	    private readonly double _yinit;

	    private double _yoff;
	    private double _xoff;

	    public GrayScaleImage(int width, int height, double increment) : base(width, height, increment)
        {
	        _xinit = GenerateSeedValue();
	        _yinit = GenerateSeedValue();
        }

        public override Image<Rgba32> CreateImage()
        {
	        CreateYOff();
			using (BaseImage = new Image<Rgba32>(Width, Height))
			{
				for (var y = 0; y < Height; y++)
				{
					CreateXOff();
					for (var x = 0; x < Width; x++)
					{
						FillImage(x, y);
						IncrementXOff();
					}
					IncrementYOff();
				}
				return new Image<Rgba32>(BaseImage);
			}
		}

	    private void FillImage(int x, int y)
	    {
		    var noise = ImprovedPerlin.Noise(_xoff, _yoff);

		    BaseImage.GetPixelReference(x, y) = GrayScale.Create(noise);
		    IncrementXOff();
	    }
	    
	    private void CreateXOff()
	    {
		    _xoff = _xinit;
	    }

	    private void CreateYOff()
	    {
		    _yoff = _yinit;
	    }
	    
	    private void IncrementXOff()
	    {
		    _xoff += Increment;
	    }

	    private void IncrementYOff()
	    {
		    _yoff += Increment;
	    }
    }
}
