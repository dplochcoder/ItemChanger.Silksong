using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;
using Silksong.FsmUtil;

namespace ItemChanger.Silksong.Locations;

public class WeaverShrineLocation : AutoLocation
{
    public required string ObjectName { get; set; }

    protected override void DoLoad()
    {
        Using(new FsmEditGroup()
        {
            { new(SceneName!, ObjectName, "Inspection"), ModifyFsm },
        });
    }

    protected override void DoUnload() { }

    private void ModifyFsm(PlayMakerFSM fsm)
    {
        var collectedState = fsm.MustGetState("Collected Check");
        collectedState.GetFirstActionOfType<PlayerDataBoolTest>()?.enabled = false;
        collectedState.AddMethod(_ =>
        {
            if (Placement?.AllObtained() ?? false) fsm.SendEvent("COLLECTED");
        });

        bool DearestRuneRage() => fsm.FsmVariables.GetFsmBool("Is Rune Bomb").Value && (Placement?.Items.Any(i => i.Name == ItemNames.Rune_Rage) ?? false);
        var runeBombFxState = fsm.MustGetState("Rune Bomb FX");
        runeBombFxState.GetFirstActionOfType<BoolTest>()?.enabled = false;
        runeBombFxState.InsertMethod(0, _ =>
        {
            if (!DearestRuneRage()) fsm.SendEvent("FINISHED");
        });

        // Skip memories.
        var toMemoryState = fsm.MustGetState("To Memory?");
        toMemoryState.RemoveTransition("FINISHED");
        toMemoryState.AddTransition("FINISHED", "Heal");
        toMemoryState.InsertMethod(0, _ => fsm.SendEvent("FINISHED"));

        // Give items, allowing big UI defs.
        var giveState = fsm.MustGetState("Heal");
        giveState.AddLambdaMethod(GiveAll);
        ModifyGiveState(giveState);

        var endState = fsm.MustGetState("End");
        foreach (var set in endState.GetActionsOfType<HutongGames.PlayMaker.Actions.SetPlayerDataBool>()) set.enabled = false;
        endState.GetFirstActionOfType<CallStaticMethod>()?.enabled = false;

        fsm.MustGetState("Harpoon Dash Reminder").GetFirstActionOfType<SendEventToRegisterDelay>()?.enabled = false;
    }

    protected virtual void ModifyGiveState(FsmState giveState) { }
}
