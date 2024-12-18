namespace Quest;

public record Hero
{
    public required string Navn;
    public required float Liv;
    public required float Damage;
    
    public List<Item> Inventory = new();

    public string TegnStats()
    {
        return $@"
HERO
[--------------------------------------------------]
| Navn: {Navn}
| Liv: {Liv}
| Damage: {Damage}
| Inventory: {string.Join(", ", Inventory.Select(i => i.Navn))}
[--------------------------------------------------]
";
    }
}