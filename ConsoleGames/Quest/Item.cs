namespace Quest;

public record Item
{
    public required string Navn;
    public required ItemType Type;
    public required float Styrke;
    public string Id { get; init; }
}

public enum ItemType
{
    Armor,
    Våben,
    Potion,
    Nøgle
}