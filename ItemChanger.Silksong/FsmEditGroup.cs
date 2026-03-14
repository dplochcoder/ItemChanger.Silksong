using System.Collections;

namespace ItemChanger.Silksong;

/// <summary>
/// Object to manage hooking and unhooking a group of fsm edits.
/// </summary>
public sealed class FsmEditGroup : IDisposable, IEnumerable<(FsmId, Action<PlayMakerFSM>)>
{
    private readonly List<(FsmId, Action<PlayMakerFSM>)> edits = [];

    /// <inheritdoc cref="SilksongHost.AddFsmEdit(FsmId, Action{PlayMakerFSM})"/>
    public void Add(FsmId id, Action<PlayMakerFSM> edit)
    {
        edits.Add((id, edit));
        SilksongHost.Instance.AddFsmEdit(id, edit);
    }

    /// <summary>
    /// Removes all edits associated with the group.
    /// </summary>
    public void Dispose()
    {
        foreach ((FsmId? id, Action<PlayMakerFSM>? edit) in edits)
        {
            SilksongHost.Instance.RemoveFsmEdit(id, edit);
        }
    }

    IEnumerator<(FsmId, Action<PlayMakerFSM>)> IEnumerable<(FsmId, Action<PlayMakerFSM>)>.GetEnumerator()
    {
        return edits.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)edits).GetEnumerator();
    }
}
