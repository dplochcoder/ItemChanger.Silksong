using ItemChanger.Silksong.RawData;
using PrepatcherPlugin;

namespace ItemChangerTesting.LocationTests;

internal class MapMachineTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.LocationTests,
        MenuName = "Map Machine Location",
        MenuDescription = "Tests putting items in a Citadel map machine.",
        Revision = 2026041700,
    };

    protected override void OnEnterGame()
    {
        PlayerDataAccess.geo += 1000;
        PlayerDataAccess.hasDash = true;
    }

    public override void Setup(TestArgs args)
    {
        StartAt(Benchwarp.Data.BaseBenchList.HighHallsVentrica);
        foreach (string l in mapMachines)
        {
            Profile.AddPlacement(Finder.GetLocation(l)!.Wrap().WithVariousItems().WithAllPersistent());
        }
    }

    public override IEnumerable<(string, Action)> TestMethods()
    {
        yield return ("Start Act 3", this.StartAct3);
    }

    private readonly string[] mapMachines =
    [
        LocationNames.Map__Choral_Chambers,
        LocationNames.Map__Cradle,
        LocationNames.Map__Grand_Gate,
        LocationNames.Map__High_Halls,
        LocationNames.Map__Memorium,
        LocationNames.Map__Whispering_Vaults,
        LocationNames.Map__Whiteward,
        LocationNames.Map__Verdania, // not a machine, but w/e
    ];
}
