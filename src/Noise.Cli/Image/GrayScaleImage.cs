using ImageSharp;
using JetabroadNoise.Cli.Options;

namespace JetabroadNoise.Cli.Image
{
    public class GrayScaleImage : PerlinImage
    {
	    private readonly double _xinit;
	    private readonly double _yinit;
	    private readonly int _width;
	    private readonly int _height;
	    private readonly double _inc;
	    private double _yoff;
	    private double _xoff;
	    private Image<Rgba32> _image;

        public GrayScaleImage(IOptions options)
        {
	        _xinit = GenerateSeedValue();
	        _yinit = GenerateSeedValue();
	        _width = options.Width;
	        _height = options.Height;
	        _inc = options.Increment;
        }

        public override Image<Rgba32> CreateImage()
        {
	        CreateYOff();
			using (_image = new Image<Rgba32>(_width, _height))
			{
				for (var y = 0; y < _height; y++)
				{
					CreateXOff();
					for (var x = 0; x < _width; x++)
					{
						FillImage(x, y);
					}
					IncrementYOff();
				}
				return new Image<Rgba32>(_image);
			}
		}

	    private void FillImage(int x, int y)
	    {
		    var noise = ImprovedPerlin.Noise(_xoff, _yoff);

		    _image.GetPixelReference(x, y) = GrayScale.Create(noise);
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
		    _xoff += _inc;
	    }

	    private void IncrementYOff()
	    {
		    _yoff += _inc;
	    }
    }
}
