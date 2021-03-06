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

- Read user input to know what type of image and other configs; ok;
- Generate a random Image using Improved Perlin Noise; ok
    - Default: image is grayscale; ok
    - Terrain: image is colorful; ok
- Save image; ok
- Display user feedback to output; ok

## Images

<img  src="./print-terrain.png">

Terrain

<img  src="./print-noise.png">

Grayscale

Coding activity: 24h [powered by wakatime](https://wakatime.com/i/kidchenko).

Cups of coffee: 6 <3

## What I learned in this exercise:
- About Perlin Noise;
- A lot about graphical generation images;
- Some design patterns and about SOLID;
- Try build a flexible design without create complexity;
- Rider IDE (Alternative to VS powered by Jetbrains);
- Docopt;
- Testing a console app - see acceptance tests;

## My pain points:
- Tooling :c I used VS for macOS, it is not so good like VS for Windows;
- This domain is very mathematical with a lot of complex calculations, find a good name was a hard task;

## Running in your machine

This project was build using .NET Core 1.1.x, so if you don't have please download [here](https://github.com/dotnet/core/blob/master/release-notes/download-archive.md). I also ran it using .NET Core 2.0.x and woked fine. You can also try too.

- `dotnet restore` to install dependencies;
- `dotnet run` to run
- `dotnet watch run` to run in watch mode

## Available Jetabroad CLI commands

- `dotnet run -- --help` show help
- `dotnet run -- --version` show version
- `dotnet run -- --terrain` generate a terrain
- `dotnet run -- --terrain` generate a terrain
- `dotnet run -- --height=<h> --width=<w>` set the image height or width default is 128px
- `dotnet run -- --inc=<inc>` set the increment of Perlin Noise, small increment generate smooth patterns, big increment generate rough pattern. You can joy with some numbers like: e.g 0.01, 0.03, 0.06, 0.09.

## Running tests

There are tests projects, for `unit tests` and `acceptance tests (e2e)`

Go to `.test` folder, enter in a project folder and run

- `dotnet restore` to install dependencies;
- `dotnet run` to run

