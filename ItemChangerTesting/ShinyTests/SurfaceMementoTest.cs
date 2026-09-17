using Benchwarp.Data;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ShinyTests;

internal class SurfaceMementoTest : AbstractShinyPlacementTest<SurfaceMementoTest>
{
    protected override string MenuName => "Surface Memento";

    protected override string MenuDescription => "Tests items replacing the Surface Memento location.";

    protected override int Revision => 2026093000;

    protected override string LocationName => LocationNames.Surface_Memento;

    protected override void SetupStart() => StartNear(SceneNames.Abandoned_town, PrimitiveGateNames.bot1);
}
