using Godot;

public partial class Main : Node2D
{
	[Export]
    public PackedScene EnemyScene { get; set; }

    public Node2D EnemySpawner { get; set; } = new Node2D();

    public override void _Ready()
    {
        EnemySpawner = GetNode<Node2D>("EnemySpawner");
    }

    public void OnEnemyTimerFired()
    {
        Path2D enemy = EnemyScene.Instantiate<Path2D>();
		EnemySpawner.CallDeferred("add_child", enemy);
    }
}
