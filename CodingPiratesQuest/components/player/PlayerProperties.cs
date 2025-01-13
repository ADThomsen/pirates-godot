using System;
using Godot;

namespace CodingPiratesQuest.components.player;

public sealed class PlayerProperties
{
    public PackedScene HeroScene { get; set; }
    public int RunSpeed { get; set; }
    public int Health { get; set; }
    
    public void Initialize(PackedScene heroScene, int runSpeed, int health)
    {
        HeroScene = heroScene;
        RunSpeed = runSpeed;
        Health = health;
    }
    
    private static readonly Lazy<PlayerProperties> Lazy = new(() => new PlayerProperties());

    public static PlayerProperties Instance => Lazy.Value;

    private PlayerProperties()
    {
    }
}