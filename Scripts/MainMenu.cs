using Godot;
using System;

public partial class MainMenu : Control
{
    [Export]
    public PackedScene PlayerScene;
    // [Export]
    // public Button HostButton;
    // [Export]
    // public Button JoinButton;
    // [Export]
    // public Button OptionsButton;
    [Export]
    public TextureButton QuitButton;
    // [Export]
    public Control JoinMenu;

    private ENetMultiplayerPeer enetPeer;

    public override void _Ready()
    {
        base._Ready();
        //HostButton.Pressed += OnHostButtonPressed;
        QuitButton.Pressed += OnQuitButtonPressed;
        // JoinButton.Pressed += OnJoinButtonPressed;
        // HostButton.GrabFocus();
        enetPeer = new ENetMultiplayerPeer();

    }

    public void OnHostButtonPressed()
    {
        Lobby.Instance.OnHostButtonPressed();
        this.Hide();
        // OptionsMenu.Visible = false;
        // JoinMenu.Visible = false;
        // foreach (var c in JoinMenu.GetChildren())
        // {
        //     GD.Print($"{c.Name} {c.GetType} {c is LineEdit}");

        // }
        // //todo replace with ui port linedit value
        // enetPeer.CreateServer(6018);
        // Multiplayer.MultiplayerPeer = enetPeer;
        // Multiplayer.MultiplayerPeer.PeerConnected += AddPlayer;
        // AddPlayer(Multiplayer.GetUniqueId());
        // GetTree().ChangeSceneToFile("res://Scenes/TestLevel.tscn");
    }

    public void OnJoinButtonPressed()
    {
        this.Hide();
        JoinMenu.Visible = true;
        Lobby.Instance.OnJoinButtonPressed();
        //todo replace with ui port linedit value
        //enetPeer.CreateClient("127.0.0.1", 6018);
        //Multiplayer.MultiplayerPeer = enetPeer;
    }

    public void OnQuitButtonPressed()
    {
        GetTree().Quit();
    }

}
