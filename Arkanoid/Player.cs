using Godot;
using System;

public partial class Player : CharacterBody2D
{
	// Acceleration betyder hvor hurtigt spilleren bevaeger sig
	public float Acceleration = 500;
	// Friction betyder hvor hurtigt spilleren stopper, naar man slipper tasten
	public float Friction = 200;

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
