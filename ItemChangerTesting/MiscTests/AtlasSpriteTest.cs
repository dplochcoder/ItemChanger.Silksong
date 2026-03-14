using Benchwarp.Data;
using ItemChanger.Locations;
using ItemChanger.Silksong.Serialization;

namespace ItemChangerTesting.MiscTests;

internal class AtlasSpriteTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.MiscTests,
        MenuName = "Atlas Sprite Items",
        MenuDescription = "Tests atlas sprites",
        Revision = 2026021700,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Plasmium",
            SceneName = SceneNames.Tut_02,
            X = 133.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
            ForceDefaultContainer = true,  // Multi shiny because chests aren't implemented
        }.Wrap()
         .WithDebugItem(sprite: new AtlasSprite() { BundleName = "atlases_assets_assets/sprites/_atlases/hornet_map.spriteatlas", SpriteName = "pin_tube_station" }, text: "Ventrica")
         .WithDebugItem(sprite: new AtlasSprite() { BundleName = "atlases_assets_assets/sprites/_atlases/inventory.spriteatlas", SpriteName = "I_crimson_cloak_down" }, text: "DJ without glide")
         .WithDebugItem(sprite: new AtlasSprite() { BundleName = "atlases_assets_assets/sprites/_atlases/inventory.spriteatlas", SpriteName = "S_thread_dash" }, text: "Sharpdart?")
         .WithDebugItem(sprite: new AtlasSprite() { BundleName = "atlases_assets_assets/sprites/_atlases/inventory.spriteatlas", SpriteName = "Inv_0029_spell_core_outer_icons_0000_1_wall_jump" }, text: "claw")
         );
    }
}
