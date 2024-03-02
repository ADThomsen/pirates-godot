using Godot;

public partial class Asteroid : Area2D
{
	public Vector2 Movement = new Vector2(0, -1);
	public float Speed = 200;
	public Sprite2D Sprite;
	public CollisionShape2D Shape;

	[Export]
	public AsteroidSize Size = AsteroidSize.Large;

	[Signal]
	public delegate void AsteroidExplodedEventHandler(Asteroid asteroid);

    public override void _Ready()
    {
        RotationDegrees = (float)GD.RandRange(0d, 360d);

		Sprite = GetNode<Sprite2D>("Sprite2D");
		Shape = GetNode<CollisionShape2D>("CollisionShape2D");

		switch (Size)
		{
			case AsteroidSize.Large:
				Speed = GD.RandRange(50, 100);
				Sprite.Texture = GD.Load<Texture2D>("res://assets/sprites/meteorGrey_big4.png");
				Shape.Shape = GD.Load<Shape2D>("res://resources/cshape_asteroid_large.tres");
				break;
			case AsteroidSize.Medium:
				Speed = GD.RandRange(100, 150);
				Sprite.Texture = GD.Load<Texture2D>("res://assets/sprites/meteorGrey_med2.png");
				Shape.Shape = GD.Load<Shape2D>("res://resources/cshape_asteroid_medium.tres");
				break;
			case AsteroidSize.Small:
				Speed = GD.RandRange(100, 200);
				Sprite.Texture = GD.Load<Texture2D>("res://assets/sprites/meteorGrey_tiny1.png");
				Shape.Shape = GD.Load<Shape2D>("res://resources/cshape_asteroid_small.tres");
				break;
		}

		if (Size == AsteroidSize.Large)
		{
			int entrySide = (int)GD.Randi() % 3;
			switch (entrySide)
			{
				case 0:
					GlobalPosition = new Vector2(GlobalPosition.X, -10000);
					break;
				case 1:
					GlobalPosition = new Vector2(10000, GlobalPosition.Y);
					break;
				case 2:
					GlobalPosition = new Vector2(GlobalPosition.X, 10000);
					break;
				case 3:
					GlobalPosition = new Vector2(-10000, GlobalPosition.Y);
					break;
			}
		}
    }

    public override void _PhysicsProcess(double delta)
    {
		float x = GlobalPosition.X + Movement.Rotated(Rotation).X * Speed * (float)delta;
		float y = GlobalPosition.Y + Movement.Rotated(Rotation).Y * Speed * (float)delta;
        GlobalPosition = new Vector2(x, y);

		float diameter = ((CircleShape2D)Shape.Shape).Radius * 2;
		Vector2 screenSize = GetViewportRect().Size;
		if ((GlobalPosition.Y + diameter) < 0)
		{
			GlobalPosition = new Vector2(GlobalPosition.X, screenSize.Y + diameter);
		}
		if ((GlobalPosition.Y - diameter) > screenSize.Y)
		{
			GlobalPosition = new Vector2(GlobalPosition.X, 0 - diameter);
		}
		if (GlobalPosition.X + diameter < 0)
		{
			GlobalPosition = new Vector2(screenSize.X + diameter, GlobalPosition.Y);
		}
		if (GlobalPosition.X - diameter > screenSize.X)
		{
			GlobalPosition = new Vector2(0 - diameter, GlobalPosition.Y);
		}
    }

	public void OnAreaEntered(Area2D area)
	{
		if (area is Laser laser)
		{
			EmitSignal(SignalName.AsteroidExploded, this);
			QueueFree();
			laser.Hit();
		}
	}
}

public enum AsteroidSize
{
	Small,
	Medium,
	Large
}