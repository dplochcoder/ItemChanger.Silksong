using Benchwarp.Data;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ShinyTests;

internal class CogheartPieceTest : AbstractShinyPlacementTest<CogheartPieceTest>
{
    protected override string MenuName => "Cogheart Piece";

    protected override string MenuDescription => "Test replacements of the Cogheart Piece items in bounce pod mechanisms.";

    protected override int Revision => 2026093000;

    protected override string LocationName => LocationNames.Cogheart_Piece__Choral_Chambers;

    protected override void SetupStart() => StartNear(SceneNames.Song_26, PrimitiveGateNames.right1);
}
