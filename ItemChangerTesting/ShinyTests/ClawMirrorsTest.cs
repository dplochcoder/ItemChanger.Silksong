using Benchwarp.Data;
using ItemChanger.Silksong.Extensions;
using ItemChanger.Silksong.RawData;
using ItemChanger.Silksong.StartDefs;
using PrepatcherPlugin;

namespace ItemChangerTesting.ShinyTests;

internal class ClawMirrorsTest : AbstractShinyPlacementTest<ClawMirrorTest>
{
    protected override string MenuName => "Claw Mirrors";

    protected override string MenuDescription => "Tests drops from the Tormented Trobbio fight.";

    protected override int Revision => 2026093000;

    protected override string LocationName => LocationNames.Claw_Mirrors;

    protected override void OnEnterGame()
    {
        base.OnEnterGame();

        StartAct3();
        PlayerDataAccess.defeatedTormentedTrobbio = false;
        QuestUtil.SetAccepted(Quests.Anguish_and_Misery);  // TODO: Fix.
    }

    protected override void SetupStart() => StartAt(new CoordinateStartDef()
    {
        SceneName = SceneNames.Library_13,
        X = 54.30f,
        Y = 14.57f,
        MapZone = GlobalEnums.MapZone.NONE
    });
}
