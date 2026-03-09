using DataDrivenConstants.Marker;

namespace ItemChanger.Silksong.Assets;

/// <summary>
/// Keys for game object assets (scene and non-scene).
/// </summary>
[JsonData("$.*~", "**/Assets/scenegameobjects.json")]
[JsonData("$.*~", "**/Assets/nonscenegameobjects.json")]
public static partial class GameObjectKeys { }

/// <summary>
/// Keys for game object asset lists (scene).
/// </summary>
[JsonData("$.*~", "**/Assets/scenegameobjectlists.json")]
public static partial class GameObjectListKeys {}

/// <summary>
/// Keys for sprite assets.
/// </summary>
[JsonData("$.*~", "**/Assets/sprites.json")]
public static partial class SpriteKeys { }
