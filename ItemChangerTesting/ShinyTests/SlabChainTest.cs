using Benchwarp.Data;
using ItemChanger.Silksong.RawData;
using ItemChanger.Silksong.StartDefs;

namespace ItemChangerTesting.ShinyTests;

internal class SlabChainTest : AbstractShinyPlacementTest<SlabChainTest>
{
    protected override string MenuName => "Slab Chain Test";

    protected override string MenuDescription => "Test items contained within a hanging chain in the Slab";

    protected override int Revision => 2026093000;

    protected override string LocationName => LocationNames.Frayed_Rosary__The_Slab_Choral_Entrance;

    protected override void SetupStart() => StartAt(new CoordinateStartDef()
    {
        SceneName = SceneNames.Slab_02,
        X = 61.77f,
        Y = 17.17f,
        MapZone = GlobalEnums.MapZone.NONE
    });
}
