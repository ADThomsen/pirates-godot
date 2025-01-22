using Godot;

public partial class DoorComponent : Area2D
{
	[Export]
	public bool IsClosed { get; set; }
	[Export]
	public bool IsLocked { get; set; }
	[Export]
	public string LeadsToPath { get; set; }
	
	public override void _Ready()
	{
	}

	public override void _Process(double delta)
	{
		
	}

	public void OnAreaEntered(Node2D node)
	{
		GetTree().CallDeferred("change_scene_to_file", LeadsToPath);
	}
}
