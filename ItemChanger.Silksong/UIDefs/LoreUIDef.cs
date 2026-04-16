using ItemChanger.Enums;
using ItemChanger.Silksong.Components;
using ItemChanger.Silksong.Serialization;
using UnityEngine;

namespace ItemChanger.Silksong.UIDefs;

public class LoreUIDef : ControlRelinquishedUIDef
{
    public static DialogueBox.DisplayOptions DefaultTopCenter => new()
    {
        ShowDecorators = true,
        Alignment = TMProOld.TextAlignmentOptions.Top,
        OffsetY = 0,
        StopOffsetY = 0,
        TextColor = Color.white
    };

    public sealed override MessageType RequiredMessageType => MessageType.Dialog;

    // Language string is mandatory because it needs to go through the LocalisedString.ToString(false) conversion
    public required LanguageString Text { get; init; }

    public DialogueBox.DisplayOptions DisplayOptions { get; init; } = DialogueBox.DisplayOptions.Default;

    public override void DoSendMessage(Action? callback)
    {
        DialogueBox.StartConversation(
            Text.ToLocalisedString().ToString(false), NPCControlProxy.Instance, false, DisplayOptions, callback);
    }
}
