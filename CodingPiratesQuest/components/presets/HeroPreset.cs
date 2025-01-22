using Godot;
using CodingPiratesQuest.components.attack;
using CodingPiratesQuest.components.player;

public partial class HeroPreset : CharacterBody2D
{
    public AnimationNodeStateMachinePlayback StateMachine { get; set; }
    public CollisionShape2D AttackCollisionShape { get; set; }

    public Sprite2D Sprite { get; set; }

    public override void _Ready()
    {
        StateMachine =
            (AnimationNodeStateMachinePlayback)GetNode<AnimationTree>("AnimationTree").Get("parameters/playback");
        Sprite = GetNode<Sprite2D>("Sprite2D");
        AttackCollisionShape = GetNode<CollisionShape2D>("HitboxComponent/CollisionShape2D");
    }

    public override void _PhysicsProcess(double delta)
    {
        Velocity = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown") * PlayerProperties.Instance.RunSpeed;

        if (Velocity.Length() > 0)
        {
            Sprite.FlipH = Velocity.X < 0;
            StateMachine.Travel("walk");
        }
        else
        {
            StateMachine.Travel("idle");
        }

        if (Input.IsActionJustPressed("Attack1"))
        {
            StateMachine.Travel("attack1");
        }

        MoveAndSlide();
    }

    public void OnHeroAttackStarted()
    {
        if (!Sprite.FlipH)
        {
            AttackCollisionShape.SetPosition(new Vector2(12, 5));
        }
        else
        {
            AttackCollisionShape.SetPosition(new Vector2(-12, 5));
        }
    }

    public void OnHeroAttackEnded()
    {
        AttackCollisionShape.SetPosition(new Vector2(-2, 5));
    }

    public void OnHeroAttacked(Attack attack)
    {
    }
}