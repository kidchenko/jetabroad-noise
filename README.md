# jetabroad-noise
"Improved Perlin Noise" command-line application coding exercise to Jetabroad company.

"Improved Perlin Noise" is an image algorithm that is used to make computer-generated images look more natural. It is often used in video games and CGI in movies. Please see the attached image (improved-perlin.jpg) for an example of an Improved Perlin Noise image.

Please write a C# command-line application that generates an image using the "Improved Perlin Noise" algorithm. Every time you execute the application, it should generate a different random image. A sample implementation (by the inventor of the algorithm) in Java is here: http://mrl.nyu.edu/~perlin/noise/

Implementations of this algorithm are freely available, so we will be judging this implementation on the following criteria:
- Is it correct?
- Is it readable, and consistent with C# best practices?
- Does it have documentation (e.g. code comments) that explains how it works, so a reader without previous knowledge can follow the code?
- Is it well unit-tested?
- Bonus (optional): add an option to output a Perlin noise terrain map (see perlin-terrain.jpg). It doesn't have to look like this sample, you can use your own artistic judgement.

## Identified Requirements;

- Read user input to know what type of image and other configs;
- Generate a random Image using Improved Perlin Noise;
    - Default: image is grayscale;
    - Terrain: image is colorful;
- Save image;
- Display user feedback to output;