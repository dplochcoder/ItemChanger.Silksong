using Benchwarp.Data;
using ItemChanger;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ItemTests;

internal class MaskShardTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ItemTests,
        MenuName = "Mask Shard",
        MenuDescription = "Tests various mask shard items.",
        Revision = 2026022300,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Middle",
            SceneName = SceneNames.Tut_02,
            X = 133.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Double_Mask_Shard)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Left",
            SceneName = SceneNames.Tut_02,
            X = 130.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Mask_Shard)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Right",
            SceneName = SceneNames.Tut_02,
            X = 136.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Full_Mask)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Far right",
            SceneName = SceneNames.Tut_02,
            X = 143.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Double_Mask_Shard)!));
    }
}
