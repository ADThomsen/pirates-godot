# Coding Pirates Galten-Skovby Forår 2024

Vi koder spil med Godot game engine.

<details>
    <summary>Installation</summary>

1. Gå til [godot download](https://godotengine.org/download) og vælg `Godot Engine - .NET`

> :warning: **Vigtigt:** Det skal være .NET versionen, da vi skal bruge C#.

2. Gå til [.NET 8 download](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) og vælg vælg den rigtige download under `sdk`. Underviserne hjælper jer med at finde den rigtige.

</details>

## Arkanoid

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
	// Her saetter vi hastigheden fra spillets start. Proev jer frem med hvilken vaerdi I vil have.
	public const float Speed = 300.0f;

    public override void _Ready()
    {
		// Velocity betyder retning og hastighed. 500, 500 er en god start, men proev jer frem.
        Velocity = new Vector2(500, 500);
    }

	// Koden i _PhysicsProcess koerer i et evigt loop og kan fx bruges til at flytte vores scene
	public override void _PhysicsProcess(double delta)
	{
		// MoveAndCollide er en indbygget Godot-metode, som vi kan bruge til at flytte vores scene i en retning.
		// Samtidig fortaeller den os om vi er stoedt ind i noget
        KinematicCollision2D collision = MoveAndCollide(Velocity * (float)delta);
		if (collision != null) 
		{
			// Hvis vi er stoedt ind i noget finder vi her den vinkel vi er stoedt ind i det med og udregner derefter
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

4. Gå tilbage til Godot og Klik på `Play`-knappen i toppen af skaermen. Nu skulle bolden gerne bevaege sig rundt på skærmen.

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

<details>
    <summary>9. Få spilleren til at bevæge sig</summary>

Vi flytter spilleren frem og tilbage ved at bruge piletasterne.

1. Vælg `Player`-scenen og klik på øverste objekt i venstre side, som hedder `Player`. Det skal gerne ligne dette billede:

![img.png](files/player-selected.png)

2. Klik på `Attach script`-knappen i venstre side af skærmen (den med det grønne kryds).
> :grey_exclamation: Kald scriptet `Player.cs` med stort P.
3. Gå til `Project -> Project Settings` i toppen af skærmen og vælg `Input Map`.
4. Tilføj to nye actions, en kaldet `MoveLeft` og en kaldet `MoveRight`. Se om du selv kan finde ud af hvordan. Når du har gjort det, skal det gerne se sådan her ud:

![img.png](files/input-actions.png)

5. Nu skal du få `MoveLeft` til at lytte på venstre piletast og `MoveRight` til at lytte på højre piletast. Klik på `MoveLeft` og klik på `+ Add Event`. Vælg `Key` og tryk på venstre piletast. Gør det samme for `MoveRight` og højre piletast. Du skal bruge `+`-knappen ud for hver funktion.

![img.png](files/input-actions-set.png)

6. Udskift indholdet i `Player.cs` med følgende:

```csharp
using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Acceleration betyder hvor hurtigt spilleren bevaeger sig
	public float Acceleration = 100;
	// Friction betyder hvor hurtigt spilleren stopper, naar man slipper tasten
	public float Friction = 100;

	public override void _PhysicsProcess(double delta)
	{
		if (Input.IsActionPressed("MoveLeft"))
		{
			Velocity = new Vector2(Velocity.X - Acceleration, Velocity.Y);
		}
		if (Input.IsActionPressed("MoveRight"))
		{
			Velocity = new Vector2(Velocity.X + Acceleration, Velocity.Y);
		}

		MoveAndSlide();
		Velocity = Velocity.MoveToward(Vector2.Zero, Friction);
	}
}
```
7. Start spillet og se at spilleren bevæger sig, når du trykker på piletasterne. Den bevæger sig bare ikke særlig optimalt.

</details>

<details>
    <summary>10. Få spilleren til at bevæge sig ordentligt</summary>

Spilleren kan bevæge sig nu, men det fungerer ikke særlig godt.

> **Opgave**: Åben `Player.cs` og se øverst i filen, hvor der er to variabler, som hedder `Acceleration` og `Friction`. Prøv at ændre på dem og start spillet igen. Hvad sker der? Find frem til to værdier, som du synes fungerer godt.

</details>

<details>
    <summary>11. Tilføj bricks</summary>

Bricks er de ting, som bolden skal ramme. Vi skal bruge en ny scene til dem.

1. Tilføj en ny scene. Den skal være af typen `StaticBody2D`. Giv den navnet `Brick`.
2. Tilføj en `Sprite2D` og en `CollisionShape2D` til din `Brick`.
3. For din `Sprite2D` finder du `Texture` og trækker `brick.png` ind.
4. For din `CollisionShape2D` finder du `Shape` og vælger `RectangleShape2D`. Sørg for at den passer med din `Sprite2D`.
5. Gå tilbage til din `main`-scene og tilføj en `Brick`-scene. Placer den et sted på skærmen og giv den en passende størrelse.
6. Start spillet og prøv at bolden rammer din brick.

</details>

<details>
    <summary>12. Få bolden til at ødelægge bricks</summary>

Bricks skal forsvinde når bolden rammer dem.

1. Gå tilbage til din `Ball`-scene og klik på `Attach script`-knappen i venstre side a skærmen (den har et grønt kryds).
2. Sæt `Language` til `C#` og `Path` til `res://Ball.cs` (:grey_exclamation: sørg for at det er med stort B).

Der skal kodes to ting for at få bolden til at ødelægge bricks:

1. Først skal vi lave en metode i vores `Brick.cs` script, som kan få den til at forsvinde fra skærmen.
2. Derefter skal vi kalde den metode fra vores `Ball.cs` script, når bolden rammer en brick.

Vi starter med at lave metoden i `Brick.cs`. Kopier følgende ind i `Brick.cs`:

```csharp
public void Hit() 
{
    QueueFree();
}
```

`QueueFree()` er en indbygget Godot-metode, som sørger for at fjerne objektet fra skærmen.

Vi har nu en metode kaldet `Hit()` som vi kan kalde fra vores `Ball.cs` script. Vi skal bare finde ud af hvornår bolden har ramt en brick.

Skift over til `Ball.cs` og find linjen, hvor der står `Velocity = Velocity.Bounce(collision.GetNormal());` 

Efter den linje skal du tilføje følgende:

```csharp
if (collision.GetCollider() is Brick brick)
{
    // her har du en variabel der hedder brick. Proev om du kan bruge den til at faa vores brick til at forsvinde
}
```

Nu skal du finde ud af hvordan du retter den kode til, så en brick forsvinder, når bolden rammer den.

</details>

<details>
    <summary>13. Tilføj flere bricks</summary>

Tilføj en masse bricks til din `main`-scene og start spillet. Se om du kan rydde skærmen for bricks.

</details>

## Asteroids

Nu skal vi lave en klon af det gamle spil [Asteroids](https://en.wikipedia.org/wiki/Asteroids_(video_game)).

<details>
    <summary>1. Opret projektet</summary>

1. Åben Godot og vælg `+ New`.
2. I `Project Name` skriver du `Asteroids`.
3. Klik på `Browse` og vælg den samme mappe som du valgte til Arkanoid og klik så `Select Current Folder`.
4. Klik på `Create Folder` og klik så på `Create & Edit`.

</details>

<details>
    <summary>2. Klargør projektet</summary>

1. Opret mapper. Nederst til venstre i Godot laver du denne struktur under `res://`:
```
res://
  - assets
    - sprites
    - audio
    - font
  - scenes
  - scripts
```
2. Download `*.png`-filer fra [sprites](Asteroids/assets/sprites) og `*.wav`-filer fra [audio](Asteroids/assets/audio) og læg dem i de rigtige mapper.

</details>

<details>
    <summary>3. Tilføj en main scene</summary>

1. Tilføj en ny scene. Den skal være af typen `Node`. Giv den navnet `Main`.
2. Tryk `Ctrl` + `S` eller `Command` + `S` for at gemme din scene. Sørg for at gemme den i `scenes`-mappen og kald den `main.tscn`.
3. Gå til `Project -> Project Settings` i toppen af skærmen og vælg `Environment` og sæt `Default Clear Color` til helt sort.
4. Start spillet og se hvor meget det fylder på din skærm. Gå til `Project -> Project Settings` igen og vælg `Window`. Prøv om du kan finde en `Viewport Width` og `Viewport Height` der passer godt til din skærm.

</details>

<details>
    <summary>4. Tilføj en spiller</summary>

Spilleren er vores rumskib, som vi kan styre rundt på skærmen. Vi har allerede lavet en spiller før, så prøv om du selv kan finde ud af at lave den. Åben `spoilers` hvis du skal have hjælp.

Lidt hjælp:

- `Player` skal være af typen `CharacterBody2D`.
- Husk at tilføje en `Sprite2D` og en `CollisionShape2D`.
- Husk at gemme din scene i `scenes`-mappen og kalde den `player.tscn`.
- Tilføj en `Player`-scene til din `Main`-scene og se om du kan finde ud af at ændre størrelsen så den passer til din skærm.

<details>
    <summary>spoilers</summary>

1. Tilføj en ny scene. Den skal være af typen `CharacterBody2D`. Giv den navnet `Player`.
2. Tilføj en `Sprite2D` og en `CollisionShape2D` til din `Player`.
3. For din `Sprite2D` finder du `Texture` og trækker `player.png` ind.
4. For din `CollisionShape2D` finder du `Shape` og vælger `CircleShape2D`.
5. Nu tilpasser du størrelsen af din `CollisionShape2D` til at passe med din `Sprite2D`.
6. Gå tilbage til din `main`-scene og tilføj en `Player`-scene. Placer den cirka i midten af skærmen.
7. Start spillet og se hvordan størrelsen på din spiller passer til skærmen.
8. Vælg igen din `Player`-scene og sørg for at vælge `Player`-objektet i venstre side af skærmen.
9. Vælg nu `Transform` i højre side af skærmen og sæt `Scale` til fx `0.5` i både `X` og `Y`.
10. Start spillet igen og se om din spiller nu passer bedre til skærmen.
11. Gentag trin 8-10 indtil du synes din spiller passer godt til skærmen.

</details>

</details>

<details>
    <summary>5. Input map</summary>

Næste trin er at mappe vores input. Det betyder at vi skal fortælle Godot, hvilke taster vi vil bruge til at styre vores spiller.

Hvis du kan huske det fra Arkanoid, så skal vi bruge `Project -> Project Settings` og vælge `Input Map` (øverst). Vi skal bruge følgende actions:

- `TurnLeft` --> `left arrow` eller `a`
- `TurnRight` --> `right arrow` eller `d`
- `Forward` --> `up arrow` eller `w`
- `Fire` --> `space`

<details>
    <summary>spoilers</summary>

1. Gå til `Project -> Project Settings` og vælg `Input Map` (øverst).
2. Tilføj en ny action ved at skrive `TurnLeft` i `Add New Action`-feltet og klikke på `Add`.
3. Klik på `+` ved siden af `TurnLeft`, tryk på venstre piletast og klik på `OK`.
4. Klik igen på `+` ved siden af `TurnLeft`, tryk på `a` og klik på `OK`.
5. Gentag trin 2-4 for `TurnRight`, `Forward` og `Fire`.

</details>

</details>

<details>
    <summary>6. Få spilleren til at bevæge sig</summary>

1. Vælg `Player`-scenen og klik på `Player`-objektet i venstre side af skærmen.
2. Klik på `Attach script`-knappen i venstre side a skærmen (den har et grønt kryds).
3. Sæt `Language` til `C#` og `Path` til `res://scripts/Player.cs` (:grey_exclamation: sørg for at det er med stort P).
4. Udskift indholdet i `Player.cs` med følgende:

```csharp
using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float MaxSpeed = 50.0f;
	
	[Export]
	public float Acceleration = 200.0f;

	[Export]
	public float RotationSpeed = 150.0f;

	public override void _PhysicsProcess(double delta)
	{
		int direction = Input.IsActionPressed("Forward") ? -1 : 0;
		Vector2 inputVector = new Vector2(0, direction);

		Velocity += inputVector.Rotated(Rotation) * Acceleration;
		Velocity = Velocity.LimitLength(MaxSpeed);

		if (direction == 0)
		{
			Velocity = Velocity.MoveToward(Vector2.Zero, 3);
		}

		if (Input.IsActionPressed("TurnLeft"))
		{
			Rotate(-(RotationSpeed * (float)delta));
		}
		if (Input.IsActionPressed("TurnRight"))
		{
			Rotate(RotationSpeed * (float)delta);
		}

		MoveAndSlide();
	}
}

```

5. Start spillet og se, at du kan styre din spiller rundt på skærmen. Den bevæger sig ikke særlig flot.
6. Juster værdierne `MaxSpeed`, `Acceleration` og `RotationSpeed` indtil du synes din spiller bevæger sig godt.

</details>

<details>
    <summary>7. Sørg for at spilleren bliver på skærmen</summary>

Hvis spilleren flyver ud af skærmen, skal den komme ind fra den anden side.

Prøv om du selv kan løse denne opgave. Her er lidt hjælp:

- Husk at vi har et koordinatsystem for spillet. Øverst til venstre er `0,0`.
- Der er en standard-metode vi kan bruge som hedder `GetViewportRect()`. Brug den sådan her: `Vector2 screenSize = GetViewportRect().Size;`.
- `screenSize` har en `X` og en `Y` værdi. `X` er bredden af skærmen og `Y` er højden af skærmen.
- Vi har også en standard-property, som hedder `GlobalPosition`. Den fortæller os hvor vores spiller er på skærmen. Den har også en `X` og en `Y` værdi.
- Vi kan fx ændre spillerens position ved at skrive `GlobalPosition = new Vector2(100, 100);`.

<details>
    <summary>Spoiler 1</summary>

Sæt koden her ind i din `Player.cs` fil. Koden skal være lige inden `MoveAndSlide()`. Se om du selv kan gøre den færdig.

```csharp
Vector2 screenSize = GetViewportRect().Size;
if (GlobalPosition.Y < 0)
{
}
if (GlobalPosition.Y > screenSize.Y)
{
}
if (GlobalPosition.X < 0)
{
}
if (GlobalPosition.X > screenSize.X)
{
}
```

</details>

<details>
    <summary>Spoiler 2</summary>

Sæt koden her ind i din `Player.cs` fil. Koden skal være lige inden `MoveAndSlide()`. Se om du selv kan gøre den færdig.

```csharp
Vector2 screenSize = GetViewportRect().Size;
if (GlobalPosition.Y < 0)
{
    GlobalPosition = new Vector2();
}
if (GlobalPosition.Y > screenSize.Y)
{
    GlobalPosition = new Vector2();
}
if (GlobalPosition.X < 0)
{
    GlobalPosition = new Vector2();
}
if (GlobalPosition.X > screenSize.X)
{
    GlobalPosition = new Vector2();
}
```

</details>

<details>
    <summary>Spoiler 3</summary>

Koden som sørger for at spilleren kommer ind fra den anden side af skærmen ser sådan ud. Koden skal være lige inden `MoveAndSlide()`.

```csharp
Vector2 screenSize = GetViewportRect().Size;
if (GlobalPosition.Y < 0)
{
    GlobalPosition = new Vector2(GlobalPosition.X, screenSize.Y);
}
if (GlobalPosition.Y > screenSize.Y)
{
    GlobalPosition = new Vector2(GlobalPosition.X, 0);
}
if (GlobalPosition.X < 0)
{
    GlobalPosition = new Vector2(screenSize.X, GlobalPosition.Y);
}
if (GlobalPosition.X > screenSize.X)
{
    GlobalPosition = new Vector2(0, GlobalPosition.Y);
}
```

</details>

</details>