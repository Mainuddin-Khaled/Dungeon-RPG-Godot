using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentSate;
    [Export] private Node[] states;

    public override void _Ready()
    {
        currentSate.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }

    public void SwitchState<T>()
    {
        Node newState = null;

        foreach (Node state in states)
        {
            if (state is T)
            {
                newState = state;
            }
        }
        if (newState == null)
        {
            return;
        }
        currentSate.Notification(GameConstants.NOTIFICATION_EXIT_STATE);
        currentSate = newState;
        currentSate.Notification(GameConstants.NOTIFICATION_ENTER_STATE);
    }
}
