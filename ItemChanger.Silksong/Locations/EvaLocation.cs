using ItemChanger.Items;
using ItemChanger.Extensions;
using ItemChanger.Locations;
using ItemChanger.Placements;
using ItemChanger.Tags;
using ItemChanger.Silksong.Placements;
using ItemChanger.Silksong.Util;
using ItemChanger.Silksong.Extensions;
using ItemChanger.Silksong.Assets;
using Benchwarp.Data;
using Newtonsoft.Json;
using Silksong.FsmUtil;
using Silksong.FsmUtil.Actions;
using Silksong.AssetHelper.ManagedAssets;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using TeamCherry.Localization;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Text;

namespace ItemChanger.Silksong.Locations;

public class EvaLocation : AutoLocation
{
    public override bool SupportsCost => true;

    [JsonIgnore]
    private FsmEditGroup? fsmEdits;

    protected override void DoLoad()
    {
        fsmEdits = new()
        {
            {new(SceneName!, "Crest Upgrade Shrine", "Dialogue"), HookEva},
        };
        GameEvents.AddSceneEdit(SceneName!, SpawnTablet);
    }

    protected override void DoUnload()
    {
        fsmEdits!.Dispose();
        fsmEdits = null;
        GameEvents.RemoveSceneEdit(SceneName!, SpawnTablet);
    }

    public override Placement Wrap() => new EvaPlacement(Name) { Location = this };

    private void SpawnTablet(Scene scene)
    {
        string inspectRegionName = "Inspect Region (1)";
        var tabletPrefab = AssetCache.GetAsset<IList<GameObject>>(GameObjectListKeys.LORE_TABLET_WEAVER)
            .First(obj => obj.FindChild(inspectRegionName) != null);
        var tablet = GameObject.Instantiate(tabletPrefab);
        tablet.transform.position = new Vector3(71.94f, 10.57f, tablet.transform.position.z);
        var modKey = "EVA_ITEM_DESCRIPTION";
        LocalisedString s = new(Localization.Sheet, modKey);
        Language._currentEntrySheets[Localization.Sheet][modKey] = BuildDescription();
        var npc = tablet.FindChild(inspectRegionName)!.GetComponent<BasicNPC>();
        npc.talkText = [s];
        npc.repeatText = s;
        npc.returnText = s;
        tablet.SetActive(true);
    }

    private void HookEva(PlayMakerFSM fsm)
    {
        var initState = fsm.MustGetState("Init");
        initState.ReplaceFirstActionOfType<PlayerDataVariableTest>(new LambdaAction { Method = () =>
        {
            if (Placement!.AllObtained())
            {
                fsm.SendEvent("BROKEN");
            }
        }});

        var setPreDlgState = fsm.MustGetState("Set Pre Dlg");
        setPreDlgState.RemoveTransitions();
        setPreDlgState.AddTransition("FINISHED", "Crest Upg 1 Dlg");

        var crestUpg1DlgState = fsm.MustGetState("Crest Upg 1 Dlg");
        var dialogueIndex = crestUpg1DlgState.IndexLastActionOfType<RunDialogue>();
        if (dialogueIndex == -1)
        {
            throw new InvalidOperationException("RunDialogue not found");
        }
        var dialogue = (RunDialogue)crestUpg1DlgState.actions[dialogueIndex];
        var modSheet = $"Mods.{ItemChangerPlugin.Id}";
        var modKey = "EVA_ITEM_DESCRIPTION";
        dialogue.Sheet = new() { Value = modSheet };
        dialogue.Key = new() { Value = modKey };
        crestUpg1DlgState.InsertMethod(dialogueIndex, () =>
        {
            Language._currentEntrySheets[modSheet][modKey] = BuildDescription();
        });

        var crestUpgState = fsm.MustGetState("Crest Upg?");
        var i = crestUpgState.IndexLastActionOfType<DialogueYesNo>();
        if (i == -1)
        {
            throw new InvalidOperationException("DialogueYesNo not found");
        }
        crestUpgState.InsertMethod(i, () =>
        {
            var hasPayableItems = Placement!.Items.Any(it => !it.GetTag<CostTag>(out var c) || (!c.Cost.Paid && c.Cost.CanPay()));
            if (!hasPayableItems)
            {
                fsm.SendEvent("FALSE");
                return;
            }
        });

        var upgradeSequence = fsm.MustGetState("Upgrade Sequence");
        upgradeSequence.RemoveTransitions();
        // bypasses the actions that actually give the evolved Hunter Crest
        upgradeSequence.AddTransition("FINISHED", "Crest Change Antic");

        FsmState crestChangeAnticState = fsm.MustGetState("Crest Change Antic");
        crestChangeAnticState.RemoveLastActionOfType<Wait>();
        crestChangeAnticState.RemoveLastActionMatching(act => 
            act is SendEventByName send
            && send.sendEvent.Value == "CREST CHANGE ANTIC");

        FsmState crestChangeState = fsm.MustGetState("Crest Change");
        crestChangeState.RemoveFirstActionOfType<AutoEquipCrestV4>();
        crestChangeState.RemoveFirstActionOfType<SendToolEquipChanged>();
        crestChangeState.InsertMethod(0, GivePayableItems);
    }

    private void GivePayableItems()
    {
        List<Item> givenItems = [];
        foreach (var item in Placement!.Items)
        {
            if (item.IsObtained())
            {
                continue;
            }
            if (item.GetTag<CostTag>(out var c) && !c.Cost.Paid)
            {
                if (c.Cost.CanPay())
                {
                    c.Cost.Pay();
                }
                else
                {
                    continue;
                }
            }
            givenItems.Add(item);
        }
        Placement!.GiveSome(givenItems, GetGiveInfo());
    }

    private string BuildDescription()
    {
        StringBuilder sb = new();
        foreach (var item in Placement!.Items)
        {
            sb.Append(item.GetPreviewName(Placement));
            sb.Append(" - ");
            if (item.IsObtained())
            {
                sb.Append("OBTAINED".GetLanguageString());
                continue;
            }
            CostTag? c = item.GetTag<CostTag>();
            if (c == null || c.Cost.IsFree)
            {
                sb.Append("FREE".GetLanguageString());
            }
            else if (c.Cost.Paid)
            {
                sb.Append("PAID".GetLanguageString());
            }
            else
            {
                sb.Append(c.Cost.GetCostText());
            }
            sb.Append("<br>");
        }
        return sb.ToString();
    }
}
