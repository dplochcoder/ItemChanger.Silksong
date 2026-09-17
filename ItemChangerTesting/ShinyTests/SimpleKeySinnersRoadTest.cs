using Benchwarp.Data;
using ItemChanger.Silksong.RawData;
using ItemChangerTesting.ShinyTests;

namespace ItemChangerTesting.LocationTests;

internal class SimpleKeySinnersRoadTest : AbstractShinyPlacementTest<SimpleKeySinnersRoadTest>
{
    protected override string MenuName => "Simple Key Sinner's Road";

    protected override string MenuDescription => "Simple Key drop from the Roachkeeper in Sinner's Road.";

    protected override int Revision => 2026093000;

    protected override string LocationName => LocationNames.Simple_Key__Sinner_s_Road;

    protected override void SetupStart() => StartNear(SceneNames.Dust_06, PrimitiveGateNames.left1);
}
