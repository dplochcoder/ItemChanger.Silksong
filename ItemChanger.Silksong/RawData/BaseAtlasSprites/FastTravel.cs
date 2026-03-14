using ItemChanger.Silksong.Serialization;

namespace ItemChanger.Silksong.RawData;

internal static partial class BaseAtlasSprites
{
    public static AtlasSprite Bellway => new()
    {
        BundleName = "atlases_assets_assets/sprites/_atlases/hornet_map.spriteatlas",
        SpriteName = "pin_stag_station"
    };

    public static AtlasSprite Ventrica => new()
    {
        BundleName = "atlases_assets_assets/sprites/_atlases/hornet_map.spriteatlas",
        SpriteName = "pin_tube_station"
    };
}
