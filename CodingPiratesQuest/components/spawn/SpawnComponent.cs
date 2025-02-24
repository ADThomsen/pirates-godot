using Godot;

namespace CodingPiratesQuest.components.spawn;

public partial class SpawnComponent : Node2D
{
	[Export]
	public string RespawnScenePath { get; set; }
	
	public void SpawnScene()
	{
		PackedScene respawnScene = GD.Load<PackedScene>(RespawnScenePath);
		Node2D respawnedTree = respawnScene.Instantiate<Node2D>();
		respawnedTree.GlobalPosition = GlobalPosition;
		GetParent().GetParent().CallDeferred("add_child", respawnedTree);
	}
}