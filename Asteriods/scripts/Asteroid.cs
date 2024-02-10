using Godot;

public partial class Asteroid : Area2D
{
	public Vector2 Movement = new Vector2(0, -1);
	public float Speed = 60;
	public Sprite2D Sprite;
	public CollisionShape2D Shape;

	[Export]
	public AsteroidSize Size = AsteroidSize.Large;

    public override void _Ready()
    {
        RotationDegrees = (float)GD.RandRange(0d, 360d);

		Sprite = GetNode<Sprite2D>("Sprite2D");
		Shape = GetNode<CollisionShape2D>("CollisionShape2D");

		switch (Size)
		{
			case AsteroidSize.Large:
				Sprite.Texture = GD.Load<Texture2D>("res://assets/sprites/meteorGrey_big4.png");
				Shape.Shape = GD.Load<Shape2D>("res://resources/cshape_asteroid_large.tres");
				break;
			case AsteroidSize.Medium:
				Sprite.Texture = GD.Load<Texture2D>("res://assets/sprites/meteorGrey_med2.png");
				Shape.Shape = GD.Load<Shape2D>("res://resources/cshape_asteroid_medium.tres");
				break;
			case AsteroidSize.Small:
				Sprite.Texture = GD.Load<Texture2D>("res://assets/sprites/meteorGrey_tiny1.png");
				Shape.Shape = GD.Load<Shape2D>("res://resources/cshape_asteroid_small.tres");
				break;
		}
    }

    public override void _PhysicsProcess(double delta)
    {
		float x = GlobalPosition.X + Movement.Rotated(Rotation).X * Speed * (float)delta;
		float y = GlobalPosition.Y + Movement.Rotated(Rotation).Y * Speed * (float)delta;
        GlobalPosition = new Vector2(x, y);

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
    }

	// public void OnAreaEntered(Area2D area)
	// {
	// 	QueueFree();
	// }
}

public enum AsteroidSize
{
	Small,
	Medium,
	Large
}