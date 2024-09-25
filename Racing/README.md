# Racing - Coding Pirates Skovby - Efterår 2024

## Beskrivelse

Vi vil lave et racerspil for to spillere, som skal have følgende features:

- Spillerne skal kunne styre hver sin bil
- Spillet skal have en bane, som bilerne skal køre på
- Man skal ikke kunne snyde og køre udenfor banen
- Der skal være en målstreg, som bilerne skal køre over
- Der skal være power-ups, som spillerne kan samle op og bruge

## Inden vi starter

1. Tjek at Godot 4 er installeret på din computer (.NET-udgaven) https://godotengine.org/download/
2. Installer Visual Studio eller Visual Studio Code https://visualstudio.microsoft.com/downloads/
3. Download dette repository ved at trykke på den grønne knap "Code" og vælg "Download ZIP"
4. Pak filen up og åben mappen `Racing`
5. Kopier mappen `anders` og giv kopien dit eget navn

## Lav spillet

Lad os komme i gang med at lave spillet. Start med at åbne Godot og åbn projektet i mappen med dit navn inde i `Racing`-mappen.

Start spillet. Du skulle gerne se en blå bil, som kan styres rundt på skærmen med piletasterne.

### Opgave 1: Lav en bane

Når du kører rundt, vil du opdage at du kan køren igennem nogle vægge, men ikke andre. Det tager vi os af senere.

- Vælg `BaneTiles` i `Main`-scenen og vælg `TileMap`-noden nederst på skærmen.
- Byg den bane du gerne vil have, med de tiles du har lyst til. Sørg for at der som minimum er en målstreg, som bilerne skal køre over.
  - Andre idéer til banen:
    - Power-ups
    - Hindringer (fx sand, vand, olie eller andet, hvor vi kan lege med friction
    - Forkerte veje
    - Genveje

### Opgave 2: Kollision

Vi vil gerne have at bilen ikke kan køre igennem væggene. Det gør vi ved at tilføje collissions til vores TileMap. Følg step 4 i denne guide: https://www.nightquestgames.com/adding-collision-to-tilemaps-in-godot-4/

### Opgave 3: Øget friktion

Vi vil gerne have at bilen mister fart, når den kører igennem fx noget mudder. Sørg for at din bane har et stykke, hvor bilen vil køre langsommere.

Ting vi skal gøre:

- Tilføj en `Area2D`-node til bilen og giv den en collision shape
- I scriptet til bilen, skal vi have to metoder. En til OnAreaEntered og en til OnAreaExited.
- I OnAreaEntered skal vi sætte friktionen til en lavere værdi, og i OnAreaExited skal vi sætte friktionen tilbage til normal.
- Lav en ny scene, hvor vi bruger billeder fra vores Assets til at lave noget mudder. Den skal være af typen `Area2D`

### Opgave 4: Skift farve på bilen

For at lave en nem form for multiplayer, laver vi det, så vi kan skifte farve på bilen. På den måde can vi sætte vores `blue_car`-scene ind to gange, og sætte en sprite for hver af dem.

Vi skal:

- Tilføje en `Texture2D` til vores `Car.cs`-script (husk `[Export]`)
- Tilføje en `Sprite` property til vores `Car.cs`-script
- Sætte vores `Texture2D` på vores `Sprite` i `_Ready`-metoden

Hint: Kig på, hvordan vi satte spriten for vores asteroids.

### Opgave 5: EventHub

Inden vi fortsætter, skal vi sørge for at vores scener kan snakke sammen. Vi har brug fx brug for at kunne sende beskeder:

- _Fra_ vores `Car`-scene _til_ vores `Main`-scene, når vi kører over målstregen
- _Fra_ vores `Main`-scene _til_ vores `Car`-scene, når bilen har kørt alle omgange

Opret en ny fil sammen med dine andre scripts. Kald den `EventHub.cs`. Gør det gennem Visual Studio eller VS Code. Den skal have følgende kode:

<details>
  <summary>Klik for at se koden</summary>

```csharp
using System;
using System.Collections.Concurrent;

namespace RacingGame.Scripts;

public static class EventHub
{
    // Define a generic delegate for event handlers.
    public delegate void EventHandler<in TEventArgs>(object sender, TEventArgs e);

    // A dictionary to hold events and their corresponding event handlers.
    private static readonly ConcurrentDictionary<string, Delegate> Events = new();

    // Method to subscribe to an event.
    public static void Subscribe<TEventArgs>(string eventName, EventHandler<TEventArgs> handler)
    {
        Events.AddOrUpdate(eventName, handler, (key, existingHandler) => (EventHandler<TEventArgs>)existingHandler + handler);
    }

    // Method to publish an event.
    public static void Publish<TEventArgs>(string eventName, object sender, TEventArgs e)
    {
        if (Events.TryGetValue(eventName, out Delegate handler))
        {
            ((EventHandler<TEventArgs>)handler)?.Invoke(sender, e);
        }
    }
}
```

</details>

### Opgave 6: Målstreg

Vi vil gerne have at vi kan køre over målstregen og få en besked om at vi har kørt en omgang. Vi skal:

- Lave en ny scene `goal_line` med en `Area2D` og en `CollisionShape2D`
- Lave et script til `goal_line`, kald det `GoalLine.cs`
- Lave et script til vores `main`-scene, kald det `GameManager.cs`
- Udvide vores `OnBodyEntered`-metode i `Car.cs`, så vi også registrerer hvis det er målstregen vi har krydset
- `Publish` en besked, når vi krydser målstregen
- `Subscribe` til beskeden i `GameManager.cs` og tæl omgange
- Når vi har kørt 3 omgange, så `Publish` en besked til `Car.cs` om at vi har vundet
- `Subscribe` til beskeden i `Car.cs` og stop bilen

### Opgave 7: HUD

Vi deler HUD-opgaven op i to:

- En simpel HUD, som bare viser hver spillers navn og hvilken omgang de er i gang med
- En mere avanceret HUD, som viser tidtagning og hvor mange omgange der er i alt

Vi starter med den simple:

- Lav en ny scene `HUD` af typen `Control` og tilføj en `Label`
- Fra `GameManager.cs` skal vi `Publish` to beskeder:
  - En besked for hver spiller, når spillet starter. Kald den `PlayerJoinedRace`
  - En besked for hver spiller, når de krydser målstregen. Kald den `PlayerStartedLap`
- `Subscribe` til `PlayerJoinedRace` og `PlayerStartedLap` i `HUD.cs` og opdater teksten i `Label`-noden

### Opagve 8: Tidtagning

### Opgave 9: Highscore

### Opgave 10: Power-ups