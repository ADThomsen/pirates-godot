using Godot;

public partial class Wave : Node
{
	[Export]
	public double SpawnInterval { get; set;}

	[Export]
	public double WaveCount { get; set;}

	[Export]
	public double Delay { get; set; }	

	[Export]
	public PackedScene LevelPath { get; set;}

	[Export]
	public Node2D Parent { get; set;}

	[Export]
	public PackedScene EnemyScene { get; set; }

	public Timer SpawnTimer = new Timer();
	public Timer DelayTimer = new Timer();
	public int SpawnConter = 0;

    public override void _Ready()
    {
        SpawnTimer = GetNode<Timer>("SpawnTimer");
        DelayTimer = GetNode<Timer>("DelayTimer");

		SpawnTimer.WaitTime = SpawnInterval;

		DelayTimer.WaitTime = Delay;
		DelayTimer.OneShot = true;
		DelayTimer.Start();
    }

	public void OnSpawnTimerExpired()
	{
		SpawnConter++;
		if (SpawnConter >= WaveCount)
		{
			SpawnTimer.Stop();
		}

		CharacterBody2D enemy = EnemyScene.Instantiate<CharacterBody2D>();
		Path2D level = LevelPath.Instantiate<Path2D>();
		level.GetNode<PathFollow2D>("EnemySpawnLocation").CallDeferred("add_child", enemy);
		Parent.CallDeferred("add_child", level);
	}

	public void OnDelayTimerExpired()
	{
		SpawnTimer.Start();
	}
}
