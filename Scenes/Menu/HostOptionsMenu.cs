using Godot;
using System;

public partial class HostOptionsMenu : Control
{
    [Export]
    public Button HostButton;

    public event EventHandler<EventArgs> HostButtonClicked;

    public override void _Ready()
    {
        HostButton.Pressed += () =>
        {
            Lobby.Instance.OnHostButtonPressed();
        };
    }

}
