using Godot;
using System;

public partial class Level : Node3D
{
    [Export]
    public PackedScene PlayerScene;
    public override void _Ready()
    {
        foreach (var i in Lobby.Instance._players)
        {
            AddPlayer(i.Key);
        }
    }

    private void AddPlayer(long peerId)
    {
        var p = GD.Load<PackedScene>(PlayerScene.ResourcePath);
        var player = p.Instantiate();
        player.Name = peerId.ToString();
        AddChild(player);
        GD.Print("Adding player");
        var levelChildren = GetChildren();
        foreach (var c in levelChildren)
        {
            if (c is Spawn)
            {
                if (((Spawn)c).IsOccupied)
                    GD.Print("Setting player position");
                ((Node3D)player).GlobalPosition = ((Node3D)c).GlobalPosition;
            }
        }
    }

}
