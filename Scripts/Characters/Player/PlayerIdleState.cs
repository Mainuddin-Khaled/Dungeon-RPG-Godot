using Godot;
using System;

public partial class PlayerIdleState : PlayerState
{
    // public Player characterNode;
    // public override void _Ready()
    // {
    //     characterNode = GetOwner<Player>();
    //     SetPhysicsProcess(false);
    //     SetProcessInput(false);
    // }
    public override void _PhysicsProcess(double delta)
    {
        if (characterNode.direction != Vector2.Zero)
        {
            characterNode.stateMachineNode.SwitchState<PlayerMoveState>();
        }
    }

    // public override void _Notification(int what)
    // {
    //     base._Notification(what);
    //     if (what == GameConstants.NOTIFICATION_ENTER_STATE)
    //     {
    //         characterNode.animationPlayer.Play(GameConstants.ANIMATION_IDLE);
    //         SetPhysicsProcess(true);
    //         SetProcessInput(true);
    //     }
    //     else if (what == GameConstants.NOTIFICATION_EXIT_STATE)
    //     {
    //         SetPhysicsProcess(false);
    //         SetProcessInput(false);
    //     }
    // }

    public override void _Input(InputEvent @event)
    {
        if (Input.IsActionJustPressed(GameConstants.INPUT_DASH))
        {
            characterNode.stateMachineNode.SwitchState<PlayerDashState>();
        }
    }

    protected override void EnterState()
    {
        base.EnterState();
        characterNode.animationPlayer.Play(GameConstants.ANIMATION_IDLE);
    }
}
