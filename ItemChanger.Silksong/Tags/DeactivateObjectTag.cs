using ItemChanger.Extensions;
using ItemChanger.Locations;
using ItemChanger.Silksong.Components;
using ItemChanger.Tags;
using ItemChanger.Tags.Constraints;
using UnityEngine.SceneManagement;

namespace ItemChanger.Silksong.Tags;

[LocationTag]
public class DeactivateObjectTag : Tag
{
    public required string SceneName { get; init; }

    public required string ObjectName { get; init; }

    private Location? _location;

    protected override void DoLoad(TaggableObject parent)
    {
        Using(new SceneEditGroup() { { SceneName, DoDeactivate } });
        _location = (parent as Location);
    }

    protected override void DoUnload(TaggableObject parent) => _location = null;

    protected virtual bool ShouldDeactivate(Location? location) => true;

    private void DoDeactivate(Scene scene)
    {
        GameObject? go = scene.FindGameObject(ObjectName);
        if (go == null)
            return;

        if (ShouldDeactivate(_location))
            go.AddComponent<Deactivator>();
    }
}

/// <summary>
/// Deactivate the listed object if the placement has had any items obtained.
/// </summary>
[LocationTag]
public class DeactivateIfPlacementCheckedTag : DeactivateObjectTag
{
    protected override bool ShouldDeactivate(Location? location) => location?.Placement?.AllObtained() is true;
}

/// <summary>
/// Deactivate the listed object if the location's container does not match the expected container.
/// </summary>
[TagConstrainedTo<ContainerLocation>]
public class DeactivateIfUnexpectedContainerTag : DeactivateObjectTag
{
    public required string ExpectedContainerType { get; init; }

    protected override bool ShouldDeactivate(Location? location) => location is ContainerLocation cl && cl.ChooseBestContainerType() != ExpectedContainerType;
}
