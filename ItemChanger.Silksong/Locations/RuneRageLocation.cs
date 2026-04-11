using Benchwarp.Data;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ItemChanger.Silksong.RawData;
using Silksong.FsmUtil;
using System.Diagnostics.CodeAnalysis;

namespace ItemChanger.Silksong.Locations;

// The first weaver has a fake shrine (triggers boss) and a real shrine (enabled after boss defeat).
// The parent class handles the real shrine, the child handles the fake shrine.
public class RuneRageLocation : WeaverShrineLocation
{
    [SetsRequiredMembers]
    public RuneRageLocation()
    {
        SceneName = SceneNames.Slab_10b;
        Name = LocationNames.Rune_Rage;
        ObjectName = "Shrine First Weaver NPC";
    }

    protected override void DoLoad()
    {
        base.DoLoad();
        Using(new FsmEditGroup() { { new(SceneName!, "Shrine First Weaver", "Inspection"), ModifyShrine } });
    }

    protected override void ModifyGiveState(FsmState giveState)
    {
        // Force-reload the scene after receiving items, to simulate reloading from the memory.
        var fsm = giveState.Fsm.FsmComponent;
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
        skipState.AddAction(new Wait() { time = 999 });  // Don't terminate the FSM before the scene loads.
    }

    private void ModifyShrine(PlayMakerFSM fsm)
    {
        var initState = fsm.MustGetState("Init");
        initState.GetFirstActionOfType<PlayerDataBoolTest>()?.enabled = false;
        initState.InsertMethod(0, _ =>
        {
            if (Placement?.AllObtained() ?? false) fsm.SendEvent("COMPLETE");
        });
    }
}
