using HutongGames.PlayMaker.Actions;
using ItemChanger.Extensions;
using ItemChanger.Locations;
using ItemChanger.Silksong.RawData;
using Silksong.FsmUtil;

namespace ItemChanger.Silksong.Locations;

public class NeedleStrikeLocation : AutoLocation
{
    private ManagedCoordinateLocation? altLoc1;
    private ManagedCoordinateLocation? altLoc2;

    protected override void DoLoad()
    {
        this.InjectPreviewText(new("Coral", "PINSTRESS_INTERIOR_GROUND_MEET"), ItemChangerLanguageStrings.PINSTRESS_INTERIOR_GROUND_MEET_PREVIEW());
        this.InjectPreviewText(new("Coral", "PINSTRESS_INTERIOR_GROUND_MEET_ACT_3"), ItemChangerLanguageStrings.PINSTRESS_INTERIOR_GROUND_MEET_ACT_3_PREVIEW());
        this.InjectPreviewText(new("Coral", "PINSTRESS_INTERIOR_GROUND_REOFFER"), ItemChangerLanguageStrings.PINSTRESS_INTERIOR_GROUND_REOFFER_PREVIEW());

        Using(new FsmEditGroup()
        {
            { new(SceneName!, "Pinstress States", "States"), ModifyPinstressStates },
            { new(SceneName!, "Pinstress Interior Ground Sit", "Behaviour"), ModifyPinstressDialogue }
        });
        Using(altLoc1 = ManagedCoordinateLocation.Load(this, new(30.5f, 8f)));
        Using(altLoc2 = ManagedCoordinateLocation.Load(this, new(33f, 8f)));
    }
    protected override void DoUnload() { }

    private void ModifyPinstressStates(PlayMakerFSM fsm)
    {
        var checkState = fsm.MustGetState("Check");
        checkState.GetFirstActionOfType<PlayerDataVariableTest>()?.enabled = false;
        checkState.InsertMethod(0, _ =>
        {
            if (!Placement!.Items.AnyEverObtained()) fsm.SendEvent("GROUND");
        });

        // If Pinstress has renewable items, place them on the ground.
        // She might still be in the hut, but she has no 'give' dialogue to inject them into after needle strike.
        //
        // This could in theory be implemented as a MultiLocation, but capturing the conditions that
        // precisely lead to each FSM state below would be quite ornery.
        fsm.MustGetState("Gone").AddMethod(_ => altLoc1?.PlaceContainer(fsm.gameObject.scene));
        fsm.MustGetState("Stand").AddMethod(_ => altLoc2?.PlaceContainer(fsm.gameObject.scene));
        fsm.MustGetState("Table").AddMethod(_ => altLoc1?.PlaceContainer(fsm.gameObject.scene));
    }

    private void ModifyPinstressDialogue(PlayMakerFSM fsm)
    {
        var metState = fsm.MustGetState("Met?");
        metState.GetFirstActionOfType<PlayerDataVariableAction>()?.enabled = false;
        metState.AddMethod(_ =>
        {
            if (Placement!.Items.Any(i => !i.IsObtained())) fsm.SendEvent("REOFFER");
        });

        var msgState = fsm.MustGetState("Msg");
        msgState.GetFirstActionOfType<CreateUIMsgGetItem>()?.enabled = false;
        msgState.GetFirstActionOfType<SetFsmString>()?.enabled = false;
        msgState.AddMethod(_ =>
        {
            Placement!.GiveAll(new()
            {
                FlingType = Enums.FlingType.DirectDeposit,
                MessageType = Enums.MessageType.Any,
                Transform = fsm.gameObject.transform,
            },
            callback: () => fsm.SendEvent("GET ITEM MSG END"));
        });

        foreach (var action in fsm.MustGetState("Save").GetActionsOfType<SetPlayerDataVariable>())
        {
            if (action.VariableName.Value != "disablePause") action.enabled = false;
        }
    }
}