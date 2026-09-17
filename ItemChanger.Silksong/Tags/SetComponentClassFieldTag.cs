using ItemChanger.Locations;
using ItemChanger.Serialization;
using ItemChanger.Silksong.Serialization;
using ItemChanger.Tags;
using ItemChanger.Tags.Constraints;
using UnityEngine.SceneManagement;

namespace ItemChanger.Silksong.Tags;

/// <summary>
/// Sets a field on a component to a provided value.
/// </summary>
[LocationTag]
public class SetComponentClassFieldTag<TComponent, TField> : Tag where TComponent : class where TField : class
{
    public required string SceneName { get; init; }

    public required ComponentClassFieldOption<TComponent, TField> Field { get; init; }

    public required IValueProvider<TField> Provider { get; init; }

    private Location? _location;

    protected override void DoLoad(TaggableObject parent)
    {
        Using(new SceneEditGroup { { SceneName, ModifyScene } });
        _location = (parent as Location);
    }

    protected override void DoUnload(TaggableObject parent) => _location = null;

    protected virtual bool ShouldSetField(Location? location) => true;

    private void ModifyScene(Scene scene)
    {
        if (ShouldSetField(_location))
            Field.Set(scene, Provider.Value);
    }
}

/// <summary>
/// Set the specified component field if the container type does not match the declared expected type.
/// </summary>
[TagConstrainedTo<ContainerLocation>]
public class SetComponentClassFieldIfUnexpectedContainerTag<TComponent, TField> : SetComponentClassFieldTag<TComponent, TField> where TComponent : class where TField : class
{
    public required string ExpectedContainerType { get; init; }

    override protected bool ShouldSetField(Location? location) => location is ContainerLocation cl && cl.ChooseBestContainerType() != ExpectedContainerType;
}
