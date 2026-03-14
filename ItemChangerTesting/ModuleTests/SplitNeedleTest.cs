using Benchwarp.Data;
using ItemChanger.Locations;
using ItemChanger.Silksong.Modules.CustomSkills;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ModuleTests;

internal class SplitNeedleTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ModuleTests,
        MenuName = "Split Needle",
        MenuDescription = "Tests split needle item functionality.",
        Revision = 2026030800
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
        Profile.Modules.GetOrAdd<SplitNeedle>();
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Far right",
            SceneName = SceneNames.Tut_02,
            X = 143.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Leftslash)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Right",
            SceneName = SceneNames.Tut_02,
            X = 136.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Rightslash)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Middle",
            SceneName = SceneNames.Tut_02,
            X = 133.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Upslash)!));
        Profile.AddPlacement(new CoordinateLocation
        {
            Name = "Left",
            SceneName = SceneNames.Tut_02,
            X = 130.6f,
            Y = 31.57f,
            FlingType = ItemChanger.Enums.FlingType.Everywhere,
            Managed = false,
        }.Wrap().Add(Finder.GetItem(ItemNames.Downslash)!));
    }
}
