using Benchwarp.Data;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.LocationTests;

internal class FleaAtFleaTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.LocationTests,
        MenuName = "Flea At Flea",
        MenuDescription = $"Tests putting a flea at the {LocationNames.Flea__Slab_Cell} location",
        Revision = 2026020300,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Slab_13, PrimitiveGateNames.right1);
        Profile.AddPlacement(Finder.GetLocation(LocationNames.Flea__Slab_Cell)!.Wrap().Add(Finder.GetItem(ItemNames.Flea)!));
    }
}
