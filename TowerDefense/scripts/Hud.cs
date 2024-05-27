using Godot;
using System;

public partial class Hud : Control
{
	public Label HealthLabel { get; set; }

	public override void _Ready()
	{
		HealthLabel = GetNode<Label>("Health");
	}

	public override void _Process(double delta)
	{
	}

	public void SetHealth(int health)
	{
		HealthLabel.Text = "HEALHT: " + health;
	}
}
