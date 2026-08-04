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

}
