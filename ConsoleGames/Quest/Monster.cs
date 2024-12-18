namespace Quest;

public record Monster
{
    public required string Navn;
    public required float Liv;
    public required float Damage;
    public bool Sover;
    public bool Død => Liv <= 0;
    public List<Item> Items = new();

    public string TegnStats()
    {
        return $@"
MONSTER
[--------------------------------------------------]
| Navn: {Navn}
| Liv: {Liv}
| Damage: {Damage}
| Sover: {(Sover ? "Ja" : "Nej")}
[--------------------------------------------------]
";
    }
}