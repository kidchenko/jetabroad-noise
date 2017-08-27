namespace JetabroadNoise.Cli.Options
{
    public interface IOptions
    {
        int Width { get; }

        int Height { get; }

        double Increment { get; }

        bool IsTerrain { get; }
        
    }
}