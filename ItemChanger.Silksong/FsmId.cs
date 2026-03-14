namespace ItemChanger.Silksong;

/// <summary>
/// Identifier used to locate fsms to run fsm edit hooks.
/// </summary>
/// <param name="SceneName">The scene in which the fsm is found, or Wildcard ("*").</param>
/// <param name="ObjectName">The name of the object on which the fsm is found, or Wildcard ("*").</param>
/// <param name="FsmName">The FsmName property of the PlayMakerFSM. Does not support Wildcard ("*").</param>
public record class FsmId(string SceneName, string ObjectName, string FsmName) {}
