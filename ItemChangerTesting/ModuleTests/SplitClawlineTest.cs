using Benchwarp.Data;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ModuleTests;

internal class SplitClawlineTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ModuleTests,
        MenuName = "Split Clawline",
        MenuDescription = "Tests left and right clawline item functionality.",
        Revision = 2026030800
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Right",
            SceneName = SceneNames.Tut_02,
            X = 136.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Right_Clawline)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Middle",
            SceneName = SceneNames.Tut_02,
            X = 133.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Left_Clawline)!));
    }
}
