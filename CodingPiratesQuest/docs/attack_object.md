# Angrib et `Object`

Nu skal vi kombinere to ting vi lavede tidligere:

- Vi har animationen, der får spilleren til at angribe
- Vi har `Object`-komponenten

Det er `Object`-komponenten, der nu skal reagere på at blive angrebet. I første omgang får vi bare objektet til at forsvinde, når det ikke har mere `Health`(liv).

## Sådan gør du

1. Find din `Object`-scene og åben den.
2. Fra `health`-mappen under `components` trækker du `health_component.tscn` ind.

![attack_object_1.png](./images/attack_object_1.png)

3. Tilføj en `CollisionShape2D` til `HealthComponent` (ligesom i billedet ovenfor)
4. Skift farven på `CollisionShape2D` til rød, så vi kan kende forskel på den og den anden `CollisionShape2D`

![attack_object_2.png](./images/attack_object_2.png)

5. Tilpas `CollisionShape2D` til at dække det område du vil have din spiller skal kunne ramme med sit angreb. Fx sådan her:

![attack_object_3.png](./images/attack_object_3.png)

Den blå cirkel er den vi lavede tidligere, som gør at spilleren ikke kan gå igennem træet. Den røde firkant er den jeg vil have spilleren skal kunne ramme med sit angreb.

6. Tilføj et script til dit `Object`

![attack_object_4.png](./images/attack_object_4.png)

![attack_object_5.png](./images/attack_object_5.png)

7. Kopier koden herunder ind i dit script:

```csharp
using Godot;
using System;

public partial class SmallTree : Sprite2D
{
    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }
    
    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }
    
    public void OnChoppedDown()
    {
        QueueFree();
    }
}

```

8. Tilbage i Godot klikker du på `HealthComponent` i venstre side og derefter på `Node` i højre side.
9. Dobbeltklik på `Death()` og connect det til `OnChoppedDown`

Vælg først den rigtige Node og klik derefter på `Pick`:

![attack_object_6.png](./images/attack_object_6.png)

Klik derefter på `OnChoppedDown()` og så på `OK`:

![attack_object_7.png](./images/attack_object_7.png)

Klik på `Connect`:

![attack_object_8.png](./images/attack_object_8.png)

10. Vælg igen `HealthComponent` i venstre side og klik på `Inspector` i højre side.
11. Skriv `20` i `Health`
12. Start spillet og prøv nu at angribe dit `Object`.