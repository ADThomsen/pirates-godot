using Godot;
using CodingPiratesQuest.components.player;

public partial class RumPreset : Node2D
{
	public Marker2D HeroSpawnPoint { get; set; }
	public Camera2D Camera { get; set; }
	public HeroPreset Hero { get; set; }
	
	public override void _Ready()
	{
		Camera = GetNode<Camera2D>("Camera2D");
		HeroSpawnPoint = GetNode<Marker2D>("Camera2D/HeroSpawnPoint");
		
		Hero = (HeroPreset)PlayerProperties.Instance.HeroScene.Instantiate();
		GetTree().CurrentScene.CallDeferred("add_child", Hero);
		Hero.SetPosition(HeroSpawnPoint.GlobalPosition);
		Camera.Position = Hero.Position;
	}

	public override void _Process(double delta)
	{
		Camera.Position = Hero.Position;
	}
}
