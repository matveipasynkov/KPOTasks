namespace FirstHW;

public class Engine
{
    public required int Size { get; set; }

    public override string ToString()
    {
        return $"Engine's size: {Size}";
    }
}