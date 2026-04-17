using ItemChanger.Containers;
using ItemChanger.Locations;
using System.Diagnostics.CodeAnalysis;
using UnityEngine;

namespace ItemChanger.Silksong.Locations;

/// <summary>
/// Utility class for a custom location to manage alternate coordinate location spawns.
/// </summary>
public sealed class ManagedCoordinateLocation : CoordinateLocation, IDisposable
{
    private readonly Location parent;

    [SetsRequiredMembers]
    private ManagedCoordinateLocation(Location parent, Vector2 pos) : base()
    {
        this.parent = parent;

        Name = parent.Name;
        SceneName = parent.SceneName;
        X = pos.x;
        Y = pos.y;
        FlingType = Enums.FlingType.Everywhere;
        Managed = true;
    }

    public static ManagedCoordinateLocation Load(Location parent, Vector2 pos)
    {
        ManagedCoordinateLocation loc = new(parent, pos);
        loc.LoadOnce();
        return loc;
    }

    public void Dispose() => UnloadOnce();

    public void PlaceContainer(UnityEngine.SceneManagement.Scene scene)
    {
        string containerType = ChooseBestContainerType();

        ContainerRegistry reg = ItemChangerHost.Singleton.ContainerRegistry;
        Container container = reg.GetContainer(containerType) ?? reg.DefaultSingleItemContainer;

        PlaceContainer(
            container,
            ContainerInfo.FromPlacement(parent.Placement!, scene, containerType, FlingType));
    }
}
