using Benchwarp.Data;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ItemTests;

internal class JournalEntryTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ItemTests,
        MenuName = "Journal Entries",
        MenuDescription = "Tests various journal entry items",
        Revision = 2026030800,
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
        }.Wrap().Add(Finder.GetItem(ItemNames.Journal_Entry__Bell_Beast)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Left",
            SceneName = SceneNames.Tut_02,
            X = 130.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Journal_Entry__Void_Tendrils)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Right",
            SceneName = SceneNames.Tut_02,
            X = 136.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Hunter_s_Journal)!));
    }
}
