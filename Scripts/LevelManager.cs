using Godot;
using System;
using System.Collections.Generic;

public partial class LevelManager : Node3D
{
    [Export]
    public PackedScene PlayerScene;
    [Export]
    public PackedScene[] LevelScenes;

    [Export]
    public Node3D LevelRoot;
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
        foreach (var spawnNode in GetTree().GetNodesInGroup("SpawnPositions"))
        {
            if (spawnNode.Name == $"spawn{player.Name}")
            {
                GD.Print("Setting player position");
                ((Node3D)player).GlobalPosition = ((Node3D)spawnNode).GlobalPosition;
            }
        }

    }

    public void ChangeLevel(int levelIndex)
    {
        var levelScene = GD.Load<PackedScene>(LevelScenes[levelIndex].ResourcePath);
        var levelInstance = levelScene.Instantiate();
        GetNode("LevelRoot").AddChild(levelInstance);
    }
}
