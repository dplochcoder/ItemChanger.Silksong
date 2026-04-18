using HutongGames.PlayMaker.Actions;
using ItemChanger.Locations;
using Silksong.FsmUtil;

namespace ItemChanger.Silksong.Locations;

public class EverbloomLocation : AutoLocation
{
    protected override void DoLoad() => Using(new FsmEditGroup() { { new(SceneName!, "door_wakeInRedMemory Root", "Wake Up"), ModifyFsm } });

    protected override void DoUnload() { }

    private void ModifyFsm(PlayMakerFSM fsm)
    {
        var giveState = fsm.MustGetState("Get Item Msg");
        giveState.GetFirstActionOfType<CreateUIMsgGetItem>()?.enabled = false;
        giveState.GetFirstActionOfType<SetFsmString>()?.enabled = false;
        giveState.AddMethod(_ => GiveAll(() => fsm.SendEvent("GET ITEM MSG END")));
    }
}
