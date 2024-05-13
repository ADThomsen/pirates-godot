using Godot;

public partial class Bullet : CharacterBody2D
{
	public float Speed = 300.0f;

	public CharacterBody2D Target { get; set; }
	public int Damage { get; set; }

	public override void _PhysicsProcess(double delta)
	{
		if (Target != null)
		{
			Velocity = GlobalPosition.DirectionTo(Target.GlobalPosition) * Speed;

			LookAt(Target.GlobalPosition);
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
