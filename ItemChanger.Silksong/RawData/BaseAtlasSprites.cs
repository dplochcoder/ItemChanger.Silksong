using ItemChanger.Silksong.Serialization;

namespace ItemChanger.Silksong.RawData;

// This is a partial class containing a large number of AtlasSprite properties. The properties are arranged in the files in the BaseAtlasSprites folder.

internal static partial class BaseAtlasSprites
{

    public static AtlasSprite DefaultSprite = new AtlasSprite()//default sprite of hornet icon from the flea minigames scoreboard
    {
        BundleName = "atlases_assets_assets/sprites/_atlases/fleascoreboard.spriteatlas",
        SpriteName = "Flea_Scoreboard_Icons_0004_Hornet"
    };

    public static List<AtlasSprite> GetBaseAtlasSprites() => [.. typeof(BaseAtlasSprites).GetProperties().Select(p => (AtlasSprite)p.GetValue(null)!)];
}
