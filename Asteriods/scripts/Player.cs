using Godot;
using System;

public partial class Player : CharacterBody2D
{
	[Export]
	public float MaxSpeed = 350.0f;
	
	[Export]
	public float Acceleration = 10.0f;

	[Export]
	public float RotationSpeed = 6.0f;

	[Export]
	public PackedScene LaserScene { get; set; }

	public Node2D Muzzle = new Node2D();

	[Signal]
	public delegate void LaserFiredEventHandler(Laser laser);

	[Signal]
	public delegate void DiedEventHandler();

    public override void _Ready()
    {
        Muzzle = GetNode<Node2D>("Muzzle");
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Fire"))
		{
			ShootLaser();
		}
    }

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

		MoveAndSlide();
	}

	public void ShootLaser()
	{
		Laser laser = LaserScene.Instantiate<Laser>();
		laser.GlobalPosition = Muzzle.GlobalPosition;
		laser.Rotation = Rotation;
		EmitSignal(SignalName.LaserFired, laser);
	}

	public void Die()
	{
		EmitSignal(SignalName.Died);
	}
}
