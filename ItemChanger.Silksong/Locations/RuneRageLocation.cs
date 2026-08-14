using HutongGames.PlayMaker.Actions;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;
using PrepatcherPlugin;
using Silksong.FsmUtil;
using UnityEngine;

namespace ItemChanger.Silksong.Locations;

// Rune Rage is granted from a 'weaver corpse' but the fsm has significant differences from other weaver corpses so it gets a custom location.
public class RuneRageLocation : AutoLocation
{
    public required Vector3 SpawnPos;

    private ManagedCoordinateLocation? altLoc;

    protected override void DoLoad()
    {
        Using(new FsmEditGroup()
        {
            { new(SceneName!, "Shrine First Weaver", "Inspection"), ModifyFsmBeforeFight },
            { new(SceneName!, "Shrine First Weaver NPC", "Inspection"), ModifyFsmAfterFight }
        });
        Using(altLoc = ManagedCoordinateLocation.Load(this, SpawnPos));
    }

    protected override void DoUnload() { }

    private bool skipRespawn = false;

    private void ModifyFsmBeforeFight(PlayMakerFSM fsm)
    {
        var initState = fsm.MustGetState("Init");
        initState.GetFirstActionOfType<PlayerDataBoolTest>()?.enabled = false;
        initState.InsertMethod(0, _ =>
        {
            // Do nothing if the boss hasn't been defeated.
            if (!PlayerDataAccess.defeatedFirstWeaver) return;

            // For fully persistent items, skip spawning on the immediate scene reload.
            if (skipRespawn)
            {
                skipRespawn = false;
            }
            else
            {
                // Spawn the items if any are unobtained.
                if (Placement!.Items.Any(i => !i.IsObtained())) altLoc?.PlaceContainer(fsm.gameObject.scene);
            }

            // Always disappear the shrine if the boss is defeated.
            fsm.SendEvent("COMPLETE");
        });
    }

    private void ModifyFsmAfterFight(PlayMakerFSM fsm)
    {
        var collectedState = fsm.MustGetState("Collected Check");
        collectedState.GetFirstActionOfType<PlayerDataBoolTest>()?.enabled = false;
        collectedState.AddMethod(_ =>
        {
            if (Placement?.AllObtained() ?? false) fsm.SendEvent("COLLECTED");
        });

        bool DearestRuneRage() => Placement?.Items.Any(i => i.Name == ItemNames.Rune_Rage) ?? false;
        var runeBombFxState = fsm.MustGetState("Rune Bomb FX");
        runeBombFxState.GetFirstActionOfType<BoolTest>()?.enabled = false;
        runeBombFxState.InsertMethod(0, _ =>
        {
            if (!DearestRuneRage())
            {
                EnemyJournalManager.RecordKill(EnemyJournalManager.GetRecord(JournalEntries.First_Weaver), showPopup: false);
                fsm.SendEvent("FINISHED");
            }
        });

        // Skip memories.
        var toMemoryState = fsm.MustGetState("To Memory?");
        toMemoryState.RemoveTransition("FINISHED");
        toMemoryState.AddTransition("FINISHED", "Heal");
        toMemoryState.InsertMethod(0, _ =>
        {
            PlayerDataAccess.defeatedFirstWeaver = true;  // Normally set in the memory scene.
            fsm.SendEvent("FINISHED");
        });

        // Give items, allowing big UI defs.
        var giveState = fsm.MustGetState("Heal");
        giveState.AddMethod(_ => skipRespawn = true);
        giveState.AddLambdaMethod(GiveAll);

        var skipState = fsm.AddState("Reload Scene");
        giveState.RemoveTransition("FINISHED");
        giveState.AddTransition("FINISHED", "Reload Scene");

        skipState.AddAction(new BeginSceneTransition()
        {
            sceneName = SceneName,
            entryGateName = "door_wakeOnGround",
            entryDelay = 0,
            visualization = GameManager.SceneLoadVisualizations.Default,
            preventCameraFadeOut = false,
        });
    }
}
