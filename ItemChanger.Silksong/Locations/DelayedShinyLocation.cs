using ItemChanger.Containers;
using ItemChanger.Locations;
using ItemChanger.Serialization;
using ItemChanger.Silksong.Containers;
using ItemChanger.Silksong.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemChanger.Silksong.Locations;

/// <summary>
/// A shiny location which is only activated after a trigger of some sort, such as defeating a boss, or breaking a container.
/// For locations which have a distinct visible preview asset which is not a generic shiny, like a mask shard, use <see cref="BreakableWithDummyLocation"/> instead.
/// </summary>
public class DelayedShinyLocation : ObjectLocation
{
    public required IValueProvider<bool> GiveEarly;

    protected override void OnSceneLoaded(Scene scene)
    {
        GetContainer(scene, out Container container, out ContainerInfo info);

        // Replace the container lazily when the shiny becomes active, instead of immediately.
        GameObject target = FindObject(scene, ObjectName);
        var wasActive = target.activeSelf;
        target.SetActive(false);
        target.AddComponent<ReplaceContainerWhenActive>().Init(this, container, info, GiveEarly.Value);
        target.SetActive(wasActive);
    }
}

file class ReplaceContainerWhenActive : MonoBehaviour
{
    internal DelayedShinyLocation? Location;
    internal Container? Container;
    internal ContainerInfo? Info;
    internal bool GiveEarly;

    internal void Init(DelayedShinyLocation location, Container container, ContainerInfo info, bool giveEarly)
    {
        Location = location;
        Container = container;
        Info = info;
        GiveEarly = giveEarly;
    }

    private void OnEnable()
    {
        if (Location == null || Container == null || Info == null)
            return;

        bool haveGiveEarlyEffects = Info.GiveInfo.Items.Any(i => i.GiveEarly(ContainerNames.Chest));
        if (Container.Name == ContainerNames.Shiny)
        {
            if (GiveEarly && haveGiveEarlyEffects)
                SpawnItems();
            else
                Container.ModifyContainerInPlace(gameObject, Info);
        }
        else if (Container.Name == ContainerNames.Chest && GiveEarly)
            SpawnItems();
        else
            Location.ReplaceWithContainer(gameObject.scene, Container, Info);
    }

    private void SpawnItems()
    {
        if (Location == null || Info == null)
            return;

        GameObject surrogate = new();
        surrogate.transform.position = transform.position;
        Info.OpenAndFlingItems(surrogate.transform, ContainerNames.Chest);
        Destroy(gameObject);
    }
}
