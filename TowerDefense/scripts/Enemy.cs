using Godot;

public partial class Enemy : CharacterBody2D
{
	[Export]
	public float Speed { get; set; } = 1.5f;
	
	[Export]
	public int Health { get; set; } = 100;

	PathFollow2D Parent = new PathFollow2D();

    public override void _Ready()
    {
        Parent = GetParent<PathFollow2D>();
    }

    public override void _PhysicsProcess(double delta)
	{
		Parent.Progress += Speed + (float)delta;

		if (Parent.ProgressRatio >= 1)
		{
			Events<Enemy>.Publish(this, "enemy_reached_end");
			Parent.QueueFree();
		}
	}

	public void Hit(int damage)
	{
		Health -= damage;
		if (Health <= 0)
		{
			Parent.QueueFree();
		}
	}
}
