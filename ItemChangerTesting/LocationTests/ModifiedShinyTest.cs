using Benchwarp.Data;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.LocationTests;

internal class ModifiedShinyTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.LocationTests,
        MenuName = "Modified Shiny",
        MenuDescription = "Tests modifying Pale_Oil-Whispering_Vaults in-place to give Surgeon's_Key.",
        Revision = 2026012300,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Library_03, PrimitiveGateNames.left1);
        Profile.AddPlacement(Finder.GetLocation(LocationNames.Pale_Oil__Whispering_Vaults)!
            .Wrap().Add(Finder.GetItem(ItemNames.Surgeon_s_Key)!));
    }
}
