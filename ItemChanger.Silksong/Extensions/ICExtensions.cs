using ItemChanger.Containers;
using ItemChanger.Costs;
using ItemChanger.Items;
using ItemChanger.Locations;
using ItemChanger.Placements;
using ItemChanger.Serialization;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemChanger.Silksong.Extensions;

internal static class ICExtensions
{
    /// <summary>
    /// Converts an object to a writable value provider wrapping that object.
    /// </summary>
    public static IWritableValueProvider<T> ToValueProvider<T>(this T t) => new LiftedT<T> { Value = t };
    /// <summary>
    /// Converts a struct-returning value provider to an object-returning value provider.
    /// </summary>
    public static IValueProvider<object> Embox<T>(this IValueProvider<T> t) where T : struct => new Box<T> { Source = t };
    /// <summary>
    /// Returns a string provider for the items placed at this location.
    /// </summary>
    public static IValueProvider<string> UINameProvider(this Location l) => new UINameProvider(l);
    /// <summary>
    /// Traverse all GameObjects in a scene.
    /// </summary>
    public static IEnumerable<GameObject> AllGameObjects(this Scene scene)
    {
        Queue<GameObject> queue = new();
        foreach (var obj in scene.GetRootGameObjects()) queue.Enqueue(obj);

        while (queue.Count > 0)
        {
            var obj = queue.Dequeue();
            yield return obj;

            foreach (Transform child in obj.transform) queue.Enqueue(child.gameObject);
        }
    }
    /// <summary>
    /// Returns a name incorporating the name of the placement and the indices of the items associated with the container.
    /// </summary>
    public static string GetGameObjectName(this ContainerInfo info, string prefix)
    {
        string itemSuffix;
        IEnumerable<Item> items = info.GiveInfo.Items;
        Placement placement = info.GiveInfo.Placement;

        if (ReferenceEquals(placement.Items, items))
        {
            itemSuffix = "all";
        }
        else
        {
            itemSuffix = string.Join(",", items.Select(i => placement.Items.IndexOf(i) is int j && j >= 0 ? j.ToString() : "?"));
        }


        return $"{prefix}-{placement.Name}-{itemSuffix}";
    }
    /// <summary>
    /// Returns all sub-costs of this possible Multicost.
    /// </summary>
    public static IEnumerable<Cost> Flatten(this Cost cost)
    {
        if (cost is MultiCost multi)
        {
            foreach (var c1 in multi)
            {
                foreach (var c2 in Flatten(c1)) yield return c2;
            }
        }
        else yield return cost;
    }
    /// <summary>
    /// Returns all sub-costs that match the specified type, traversing nested Multicosts.
    /// </summary>
    public static IEnumerable<T> GetCostsOfType<T>(this Cost cost) => cost.Flatten().OfType<T>();
}

file class Box<T> : IValueProvider<object> where T : struct
{
    public required IValueProvider<T> Source { get; init; }
    public object Value => Source.Value;
}

file class UINameProvider(Location Location) : IValueProvider<string>
{
    public string Value => Location.Placement?.GetUIName() ?? "???";
}

file class LiftedT<T> : IWritableValueProvider<T>
{
    public required T Value { get; set; }
}
