using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using Godot;

namespace RacingGame.Scripts;

public static class Storage
{
    private static List<PlayerTime> GetTimes()
    {
        string path = "times.json";
        if (!File.Exists(path))
        {
            List<PlayerTime> records = new();
            string initialContent = JsonSerializer.Serialize(records);
            File.WriteAllText(path, initialContent);
        }

        string content = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<PlayerTime>>(content);
    }
    
    private static void SaveTimes(List<PlayerTime> records)
    {
        string path = "times.json";
        string content = JsonSerializer.Serialize(records);
        File.WriteAllText(path, content);
    }

    public static void AddNewTime(string playerName, long milliseconds)
    {
        List<PlayerTime> times = GetTimes();
        times.Add(new PlayerTime { Player = playerName, Milliseconds = milliseconds });
        SaveTimes(times);
        LoadFastestTime();
    }

    public static void LoadFastestTime()
    {
        List<PlayerTime> times = GetTimes();
        PlayerTime fastestTime = times.OrderBy(x => x.Milliseconds).FirstOrDefault();
        EventHub.Publish("FastestTimeLoaded", null, fastestTime);
    }
}

public record PlayerTime
{
    public string Player { get; init; }
    public long Milliseconds { get; init; }
}