using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using RacingGame.Scripts;

public partial class Hud : Control
{
	private Label PlayersLabel { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayersLabel = GetNode<Label>("PlayersLabel");
		EventHub.Subscribe<Dictionary<string, int>>("PlayerStartedLap", UpdatePlayersLabel);
	}
	
	public void UpdatePlayersLabel(object sender, Dictionary<string, int> players)
	{
		PlayersLabel.Text = string.Join("\n", players.Select(x => $"{x.Key}: {x.Value}"));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
