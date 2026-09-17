using ItemChanger.Extensions;
using ItemChanger.Locations;
using ItemChanger.Tags;
using ItemChanger.Tags.Constraints;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace ItemChanger.Silksong.Tags;

/// <summary>
/// Adjust the position of an existing object.
/// </summary>
[LocationTag]
public class AdjustPositionTag : Tag
{
    /// <summary>
    /// The scene where the object is found.
    /// </summary>
    public required string SceneName { get; init; }

    /// <summary>
    /// The name or path to the object.
    /// </summary>
    public required string ObjectName { get; init; }

    /// <summary>
    /// The delta to apply to the object's position.
    /// </summary>
    public required Vector3 Adjustment { get; init; }

    /// <summary>
    /// The space to apply the adjustment within.
    /// </summary>
    public Space Space { get; init; } = Space.World;

    private Location? _location = null;

    protected override void DoLoad(TaggableObject parent)
    {
        Using(new SceneEditGroup { { SceneName, DoAdjustment } });
        _location = (parent as Location);
    }

    protected override void DoUnload(TaggableObject parent) => _location = null;

    protected virtual bool ShouldAdjustPosition(Location? location) => true;

    private void DoAdjustment(Scene scene)
    {
        if (!ShouldAdjustPosition(_location))
            return;

        GameObject? go = scene.FindGameObject(ObjectName);
        if (go == null)
            return;

        go.transform.Translate(Adjustment, Space);
    }
}

/// <summary>
/// Adjust the position of an existing object if the container type does not match the declared expected type.
/// </summary>
[TagConstrainedTo<ContainerLocation>]
public class AdjustPositiionIfUnexpectedContainerTag : AdjustPositionTag
{
    public required string ExpectedContainerType { get; init; }

    protected override bool ShouldAdjustPosition(Location? location) => location is ContainerLocation cl && cl.ChooseBestContainerType() != ExpectedContainerType;
}
