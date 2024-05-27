using Godot;

public partial class Bullet : CharacterBody2D
{
	public float Speed = 300.0f;

	public Enemy Enemy { get; set; }
	public int Damage { get; set; }

	public override void _PhysicsProcess(double delta)
	{
		if (Enemy != null)
		{
			Velocity = GlobalPosition.DirectionTo(Enemy.GlobalPosition) * Speed;

			LookAt(Enemy.GlobalPosition);
		}

		MoveAndSlide();
	}

	public void OnBodyEntered(Node2D body)
	{
		if (body is Enemy enemy)
		{
			enemy.Hit(Damage);
			QueueFree();
		}
	}
}
