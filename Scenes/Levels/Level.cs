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
        foreach (var spawnNode in GetTree().GetNodesInGroup("SpawnPositions"))
        {
            GD.Print("Spawn node");
            if (spawnNode.Name == $"spawn{player.Name}")
            {
                GD.Print("Setting player position");
                ((Node3D)player).GlobalPosition = ((Node3D)spawnNode).GlobalPosition;
            }
        }

    }

}
