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

			if (collision.GetCollider() is Brick brick)
			{
				brick.Hit();
			}

			// Til sidst begynder vi at flytte vores scene i den nye retning
			MoveAndCollide(reflect);
		}
    }

	public void OnScreenExited()
	{
		GetTree().ReloadCurrentScene();
	}
}
