using ItemChanger.Locations;
using ItemChanger.Tags;
using ItemChanger.Silksong.Util;
using Newtonsoft.Json;
using Silksong.FsmUtil;
using Silksong.FsmUtil.Actions;
using HutongGames.PlayMaker;
using HutongGames.PlayMaker.Actions;
using TeamCherry.Localization;
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
    }

    protected override void DoUnload()
    {
        fsmEdits!.Dispose();
        fsmEdits = null;
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
        crestUpgState.InsertMethod(i, () =>
        {
            var hasPayableItems = Placement!.Items.Any(it => !it.GetTag<CostTag>(out var c) || (!c.Cost.Paid && c.Cost.CanPay()));
            if (!hasPayableItems)
            {
                fsm.SendEvent("FALSE");
                return;
            }
        });
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