# Coding Pirates Galten-Skovby Forår 2024

Vi koder spil med Godot game engine.

<details>
    <summary>Installation</summary>

1. Gå til [godot download](https://godotengine.org/download) og vælg `Godot Engine - .NET`

> :warning: **Vigtigt:** Det skal være .NET versionen, da vi skal bruge C#.

2. Gå til [.NET 8 download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) og vælg vælg den rigtige download under `sdk`. Underviserne hjælper jer med at finde den rigtige.

</details>

Det første vi skal lave er en simpel udgave af spillet [Arkanoid](https://en.wikipedia.org/wiki/Arkanoid), også kendt som breakout-game.

<details>
    <summary>1. Opret projektet</summary>

1. Åben Godot og vælg `+ New`. 
2. I `Project Name` skriver du `Arkanoid`.
3. Klik på `Browse` og vælg en mappe, hvor du vil gemme alle de spil vi skal lave og klik så `Select Current Folder`.
4. Klik på `Create Folder` og klik så på `Create & Edit`.
5. Klik på `Editor -> Editor Settings` i toppen af skærmen. Scroll ned i bunden af venstre side og klik på `Dotnet -> Editor` og under `External Editor` vælger du den editor du vil bruge til at skrive kode.
</details>

<details>
    <summary>2. Opret en main scene</summary>

Alt i Godot foregår i scener. En scene er en samling af objekter, som kan være alt fra en baggrund til en spiller. Vi skal bruge en scene, som vi kan bruge som vores hovedscene. Det er herfra vi starter spillet.

Skift først til `2D` mode i toppen af skærmen. Følg derefter disse trin:

1. Klik på `:heavy_plus_sign: Other Node` i venstre side.
2. Vælg den øverste mulighed, som bare hedder `Node` og klik Create.
3. Dobbeltklik på `Node` i venstre side og skriv `Main` i stedet.
4. Klik på `Project -> Project Settings` i toppen af skærmen og vælg `Window`.
5. Sæt `Viewport Width` til `2000` og `Viewport Height` til `1000` og klik `Close`.
6. Gem projektet ved at trykke `Ctrl + S` eller `Command + S`. Klik `Save` for at gemme vores `main.tscn`scene.

</details>

<details>
    <summary>3. Importer sprites</summary>

Vi skal bruge noget simpelt grafik til vores spil.

1. Åben mappen [sprites](Arkanoid/sprites) og download de fire `*.png`-filer derfra.
2. I Godot nederst til venstre højreklik på `res://` og vælg `New Folder`. Skriv `sprites` og tryk `Enter`.
3. Træk de downloaded filer ind i `sprites`-mappen i Godot.

</details>

<details>
    <summary>4. Tilføj vægge</summary>

For at vores bold skal kunne blive på skærmen, skal vi lave nogle vægge som den kan ramme.

1. Tilføj en ny scene (find selv ud af hvordan). Den skal være af typen `StaticBody2D`.
2. Til venstre omdøber du dine nye scene til `Wall`.
3. Under `Wall` tilføjer du nu en `Sprite2D` og en `CollisionShape2D`.
4. For din `Sprite2D` finder du `Texture` og trækker `wall.png` ind.
5. For din `CollisionShape2D` finder du `Shape` og vælger `RectangleShape2D`.
6. Nu tilpasser du størrelsen af din `CollisionShape2D` til at passe med din `Sprite2D`.
7. Vælg igen `Wall` til venstre og tryke `Ctrl + G` eller `Command + G`. Dette grupperer dine objekter og sørger for at du ikke kommer til at flytte din collision shape, men altid flytter hele scenen.
8. Skift nu tilbage til din `main`-scene og tilføj en `Wall`-scen. Få den til at fylde hele den ene side af din main scene. Forsøg selv at finde ud af hvordan.
9. Gentag processen og lav en væg i den anden side samt et tag i toppen af skærmen.

</details>

<details>
    <summary>5. Tilføj en bold</summary>

1. Tilføj en ny scene. Den skal være af typen `CharacterBody2D`. Giv den navnet `Ball`.
2. Tilføj en `Sprite2D` og en `CollisionShape2D` til din `Ball`.
3. For din `Sprite2D` finder du `Texture` og trækker `ball.png` ind.
4. For din `CollisionShape2D` finder du `Shape` og vælger `CircleShape2D`.
5. Nu tilpasser du størrelsen af din `CollisionShape2D` til at passe med din `Sprite2D`.
6. Gå tilbage til din `main`-scene og tilføj en `Ball`-scene. Placer den i midten a skærmen, lidt til venstre og giv den en passende størrelse.

</details>

<details>
    <summary>6. Tilføj en spiller</summary>

1. Tilføj en ny scene. Den skal være af typen `CharacterBody2D`. Giv den navnet `Player`.
2. Tilføj en `Sprite2D` og en `CollisionShape2D` til din `Player`.
3. For din `Sprite2D` finder du `Texture` og trækker `player.png` ind.
4. For din `CollisionShape2D` finder du `Shape` og vælger `RectangleShape2D`.
5. Nu tilpasser du størrelsen af din `CollisionShape2D` til at passe med din `Sprite2D`.
6. Gå tilbage til din `main`-scene og tilføj en `Player`-scene. Placer den i bunden af skærmen, cirka i midten og giv den en passende størrelse.

</details>

<details>
    <summary>7. Få bolden til at bevæge sig</summary>

1. Gå tilbage til din `Ball`-scene og klik på `Attach script`-knappen i venstre side a skærmen (den har et grønt kryds).
2. Sæt `Language` til `C#` og `Path` til `res://Ball.cs` (:grey_exclamation: sørg for at det er med stort B).
3. Udskift indholdet i `Ball.cs` med følgende:

```csharp
using Godot;
using System;

public partial class Ball : CharacterBody2D
{
	// Her sætter vi hastigheden fra spillets start. Prøv jer frem med hvilken værdi I vil have.
	public const float Speed = 300.0f;

    public override void _Ready()
    {
		// Velocity betyder retning og hastighed. 500, 500 er en god start, men prøv jer frem.
        Velocity = new Vector2(500, 500);
    }

	// Koden i _PhysicsProcess kører i et evigt loop og kan fx bruges til at flytte vores scene
	public override void _PhysicsProcess(double delta)
	{
		// MoveAndCollide er en indbygget Godot-metode, som vi kan bruge til at flytte vores scene i en retning.
		// Samtidig fortæller den os om vi er stødt ind i noget
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null) 
		{
			// Hvis vi er stødt ind i noget finder vi her den vinkel vi er stødt ind i det med og udregner derefter
			// vores nye Velocity (retning og hastighed) ved at bruge en anden indbygget Godot-metode, nemlig Bounce()
			Vector2 reflect = collision.GetRemainder().Bounce(collision.GetNormal());
			Velocity = Velocity.Bounce(collision.GetNormal());

			// Til sidst begynder vi at flytte vores scene i den nye retning
			MoveAndCollide(reflect);
		}
    }

	public void OnScreenExited()
	{
		GetTree().ReloadCurrentScene();
	}
}

```

4. Gå tilbage til Godot og Klik på `Play`-knappen i toppen af skærmen. Nu skulle bolden gerne bevæge sig rundt på skærmen.

</details>

<details>
    <summary>8. Genstart spillet</summary>

Vi vil gerne genstarte spillet, når bolden ryger ud af bunden af skærmen.

1. Vælg `Ball`-scenen og tilføj et nyt child object af typen `VisibleOnScreenNotifier2D`.
2. Vælg `VisibleOnScreenNotifier2D` og klik så på `Node`-tabben i højre side af skærmen.
3. Find `screen_exited`, højreklik på den og klik `Connect`.
4. Klik på `Pick`-knappen og vælg `OnScreenExited()` og klik `Connect`. Koden til det har vi allerede sat ind tidligere.
5. Start spillet igen. Nu skulle du gerne se at spillet genstarter, når bolden ryger ud af bunden af skærmen.

</details>
