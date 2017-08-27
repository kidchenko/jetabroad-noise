namespace JetabroadNoise.Cli.Options
{
    public interface IOption
    {
        int Width { get; }

        int Height { get; }

        double Increment { get; }

        bool IsTerrain { get; }
        
    }
}