namespace Quest;

public record Dør
{
    public bool Låst;
    public string NøgleId { get; init; }
    public Rum FørerTil { get; init; }
}