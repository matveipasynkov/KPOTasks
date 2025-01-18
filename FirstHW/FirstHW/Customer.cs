namespace FirstHW;

public class Customer
{
    public required string Name { get; set; }

    public Car? Car { get; set; }

    public override string ToString()
    {
        return $"Name of customer: {Name}; information about car: {Car?.ToString() ?? "doesn't have a car"}";
    }
}