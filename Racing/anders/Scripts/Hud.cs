using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using RacingGame.Scripts;

public partial class Hud : Control
{
	private Label PlayersLabel { get; set; }
	private Dictionary<string, Player> Players = new();
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayersLabel = GetNode<Label>("PlayersLabel");
		EventHub.Subscribe<string>("PlayerStartedLap", OnPlayerStartedLap);
		EventHub.Subscribe<string>("PlayerJoinedRace", OnPlayerJoinedRace);
	}

	private void OnPlayerJoinedRace(object sender, string playerName)
	{
		Players.Add(playerName, new Player { Name = playerName, Laps = 0 });
		UpdateLabel();
	}

	public void OnPlayerStartedLap(object sender, string playerName)
	{
		Players[playerName].Laps += 1;
		UpdateLabel();
	}

	public void UpdateLabel()
	{
		PlayersLabel.Text = string.Join("\n", Players.Select(x => $"{x.Key}: {x.Value.Laps}"));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

internal class Player
{
	public string Name { get; set; }
	public int Laps { get; set; }
}
