using Godot;
using System;

public partial class PlayerMoveState : PlayerState
{
    // private Player characterNode;
    // public override void _Ready()
    // {
    //     characterNode = GetOwner<Player>();
    //     SetPhysicsProcess(false);
    //     SetProcessInput(false);
    // }

    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction == Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerIdleState>();
            return;
        }
        characterNode.Velocity = new(characterNode.direction.X, 0, characterNode.direction.Y);
        characterNode.Velocity *= 5;

        characterNode.MoveAndSlide();
        characterNode.Flip();
    }


    protected override void EnterState()
    {
        characterNode.animationPlayer.Play(GameConstants.ANIMATION_RUN);
    }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }

}
