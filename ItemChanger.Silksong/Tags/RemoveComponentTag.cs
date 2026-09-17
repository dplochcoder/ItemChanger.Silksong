using ItemChanger.Locations;
using ItemChanger.Silksong.Locations;
using ItemChanger.Tags;
using ItemChanger.Tags.Constraints;
using Silksong.UnityHelper.Extensions;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemChanger.Silksong.Tags;

[LocationTag]
public class RemoveComponentTag<T> : Tag where T : Component
{
    public required string SceneName { get; init; }

    public required string ObjectName { get; init; }

    protected override void DoLoad(TaggableObject parent)
    {
        Using(new SceneEditGroup() { { SceneName, DoRemoveComponent } });
        _location = (parent as Location);
    }

    protected override void DoUnload(TaggableObject parent) => _location = null;

    private Location? _location;

    protected virtual bool ShouldRemoveComponent(Location? location) => true;

    private void DoRemoveComponent(Scene scene)
    {
        if (!ShouldRemoveComponent(_location))
            return;

        GameObject? go = scene.FindGameObject(ObjectName);
        if (go == null)
            return;

        go.RemoveComponents<T>();
    }
}

[LocationTag]
public class RemoveComponentIfItemIsMissingTag<T> : RemoveComponentTag<T> where T : Component
{
    public required string ItemName { get; init; }

    protected override bool ShouldRemoveComponent(Location? location) => location?.Placement?.Items.All(i => i.Name != ItemName) ?? true;
}
