using Benchwarp.Data;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ItemTests;

internal class FleaItemTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ItemTests,
        MenuName = "Flea Items",
        MenuDescription = "Tests putting a bunch of flea items in Tut_02",
        Revision = 2026020300
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);

        int ct = 0;
        for (float i = 140; i > 106; i -= 2)
        {
            Profile.AddPlacement(new CoordinateLocation
            {
                Name = $"FleaHolder {ct} @ {i}",
                SceneName = SceneNames.Tut_02,
                X = i,
                Y = 31.57f,
                FlingType = ItemChanger.Enums.FlingType.Everywhere,
                Managed = false,
            }.Wrap().Add(Finder.GetItem(ItemNames.Flea)!));

            ct++;
        }
    }
}
