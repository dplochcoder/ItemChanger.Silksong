using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using ItemChanger.Locations;
using ItemChanger.Silksong.Extensions;
using ItemChanger.Silksong.RawData;
using Silksong.FsmUtil;
using TeamCherry.Localization;
using UnityEngine;

namespace ItemChanger.Silksong.Locations;

public class MapMachineLocation : AutoLocation
{
    public required string ObjectName { get; init; }
    public required Vector3 Correction { get; init; }

    // There are multiple map machines that all use the same language key, so we need to make unique proxies.
    private static int nextId = 0;
    private int id;
    private LocalisedString DialogueKey => new("Inspect", $"ITEMCHANGER_CITADEL_MAP_PROMPT_{id}");
    private ManagedCoordinateLocation? altLoc;

    protected override void DoLoad()
    {
        id = nextId++;
        this.InjectPreviewText(DialogueKey, ItemChangerLanguageStrings.CITADEL_MAP_PROMPT_PREVIEW());
        Using(new FsmEditGroup() { { new(SceneName!, ObjectName, "Unlock Behaviour"), ModifyMapMachine } });
    }

    protected override void DoUnload() { }

    private void ModifyMapMachine(PlayMakerFSM fsm)
    {
        FsmState inertState = fsm.MustGetState("Inert");
        inertState.GetFirstActionOfType<SavedItemCanGetMore>()?.enabled = false;
        inertState.AddMethod(_ =>
        {
            if (!Placement!.CheckVisitedAll(Enums.VisitState.Accepted)) return;

            if (altLoc == null)
            {
                Vector3 pos = fsm.gameObject.transform.position - Correction;
                altLoc = ManagedCoordinateLocation.Load(this, pos);
                Using(altLoc);
            }
            altLoc.PlaceContainer(fsm.gameObject.scene);

            fsm.SendEvent("ACTIVATED");
        });

        FsmState inspectState = fsm.MustGetState("Inspect");
        inspectState.InsertMethod(0, _ => Placement!.AddVisitFlag(Enums.VisitState.Previewed));
        RunDialogue runDialogue = inspectState.GetFirstActionOfType<RunDialogue>()!;
        runDialogue.Sheet = DialogueKey.Sheet;
        runDialogue.Key = DialogueKey.Key;

        FsmState giveState = fsm.MustGetState("Get Item");
        giveState.GetFirstActionOfType<SavedItemGet>()?.enabled = false;
        giveState.AddLambdaMethod(this.CreateGiveAllDelegate(fsm.transform.Find("Active/Dish")));
        giveState.AddMethod(() => Placement!.AddVisitFlag(Enums.VisitState.Accepted));
    }
}
