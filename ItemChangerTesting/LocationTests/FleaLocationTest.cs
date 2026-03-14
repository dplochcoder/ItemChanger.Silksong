using Benchwarp.Data;

namespace ItemChangerTesting.LocationTests;

internal class FleaLocationTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.LocationTests,
        MenuName = "Flea Location",
        MenuDescription = "Tests putting a debug item at each flea location",
        Revision = 2026020300,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);

        foreach (string loc in Finder.LocationNames.Where(x => x.StartsWith("Flea-")))
        {
            Profile.AddPlacement(
                Finder
                .GetLocation(loc)!
                .Wrap()
                .WithDebugItem()
                );
        }
    }
}
