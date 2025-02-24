# Få et nyt object til at spawne

For at få et nyt object til at spawne, vil vi lave en `spawn_component`, som vi kan genbruge. Følg trinnene herunder og se hvor langt du kan komme uden yderligere hjælp.

1. Lav en ny mappe i `components`-mappen i Godot, som hedder `spawn`
2. Lav en ny scene i mappen, som hedder `spawn_component.tscn` af typen `Node2D`
3. Tilføj et script til scenen
4. Kopier koden herunder ind i dit script:

```csharp
using Godot;

namespace CodingPiratesQuest.components.spawn;

public partial class SpawnComponent : Node2D
{
    [Export]
    public string RespawnScenePath { get; set; }
    
    public void SpawnScene()
    {
        PackedScene respawnScene = GD.Load<PackedScene>(RespawnScenePath);
        Node2D respawnedTree = respawnScene.Instantiate<Node2D>();
        respawnedTree.GlobalPosition = GlobalPosition;
        GetParent().GetParent().CallDeferred("add_child", respawnedTree);
    }
}
```

5. Træk din nye `spawn_component` ind i den scene, hvor du gerne vil have et nyt object til at spawne fra (hvis du fx fælder et træ, som skal blive til en stub, så træk den ind i din tree-scene)
6. Husk at sætte `RespawnScenePath` til den path, hvis scene du gerne vil have til at spawne.
7. Nu skal du aktivere `SpawnScene()`-metoden. Hvordan mon vi gør det? Kig på hvordan vi får vores object til at forsvinde (fx dit træ, som er blevet fældet). Kan vi gøre noget lignende?

