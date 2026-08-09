using Godot;
using System;

public partial class StateMachine : Node
{
    [Export] private Node currentSate;
    [Export] private Node[] states;

    public override void _Ready()
    {
        currentSate.Notification(5001);
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
        currentSate = newState;
        currentSate.Notification(5001);
    }
}
