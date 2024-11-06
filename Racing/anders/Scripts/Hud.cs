using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using RacingGame.Scripts;

public partial class Hud : Control
{
	private Label PlayersLabel { get; set; }
	private Label TimeLabel { get; set; }
	private Label RecordLabel { get; set; }
	private Dictionary<string, Player> Players = new();
	private long Time { get; set; }
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		PlayersLabel = GetNode<Label>("PlayersLabel");
		TimeLabel = GetNode<Label>("TimeLabel");
		RecordLabel = GetNode<Label>("RecordLabel");
		EventHub.Subscribe<string>("PlayerStartedLap", OnPlayerStartedLap);
		EventHub.Subscribe<string>("PlayerJoinedRace", OnPlayerJoinedRace);
		EventHub.Subscribe<long>("LapTimeUpdated", OnLapTimeUpdated);
		EventHub.Subscribe<PlayerTime>("FastestTimeLoaded", OnFastestTimeLoaded);
	}

	private void OnFastestTimeLoaded(object sender, PlayerTime player)
	{
		RecordLabel.Text = $"{player.Player}: {TimeSpan.FromMilliseconds(player.Milliseconds):mm\\:ss\\.fff}";
	}

	private void OnLapTimeUpdated(object sender, long time)
	{
		Time = time;
		UpdateTimeLabel();
	}

	private void OnPlayerJoinedRace(object sender, string playerName)
	{
		Players.Add(playerName, new Player { Name = playerName, Laps = 0 });
		UpdatePlayersLabel();
	}

	public void OnPlayerStartedLap(object sender, string playerName)
	{
		Players[playerName].Laps += 1;
		UpdatePlayersLabel();
	}

	public void UpdatePlayersLabel()
	{
		string playersLabelText = string.Join("\n", Players.Select(x => $"{x.Key}: {x.Value.Laps}"));
		// string time = TimeSpan.FromMilliseconds(Time).ToString("mm\\:ss\\.fff");
		PlayersLabel.Text = playersLabelText;
	}

	public void UpdateTimeLabel()
	{
		string time = TimeSpan.FromMilliseconds(Time).ToString("mm\\:ss\\.fff");
		TimeLabel.Text = time;
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
