using CodingPiratesQuest.components.player;
using Godot;

public partial class MainMenu : Control
{
	[Export]
	public PackedScene StartScene { get; set; }
	[Export]
	public PackedScene HeroScene { get; set; }
	[Export] 
	public int RunSpeed = 100;
	[Export] 
	public int Health = 100;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayerProperties.Instance.Initialize(HeroScene, RunSpeed, Health);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	public void OnStartButtonPressed()
	{
		GetTree().ChangeSceneToPacked(StartScene);
	}
}
