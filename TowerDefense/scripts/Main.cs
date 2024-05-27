using Godot;

public partial class Main : Node2D
{
    public int Health { get; set; }
    public Hud Hud { get; set; }

    public override void _Ready()
    {
        Hud = GetNode<Hud>("UI/HUD");
        Health = 1000;
        Hud.SetHealth(Health);
        Events<Enemy>.Subscribe("enemy_reached_end", EnemyReachedEnd);
    }

    private void EnemyReachedEnd(Enemy enemy, string channel, object[] args) {
        Health -= enemy.Health;
        Hud.SetHealth(Health);
    }
}
