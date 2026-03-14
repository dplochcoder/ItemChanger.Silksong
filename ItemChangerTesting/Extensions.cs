using ItemChanger.Items;
using ItemChanger.Placements;
using ItemChanger.Serialization;
using ItemChanger.Silksong.UIDefs;
using UnityEngine;

namespace ItemChangerTesting
{
    internal static class Extensions
    {
        public static Placement WithDebugItem(this Placement self, IValueProvider<Sprite>? sprite = null, string? text = null)
        => self.Add(new DebugItem()
        {
            Name = $"Debug Item @ {self.Name}",
            UIDef = new MsgUIDef()
            {
                Name = new BoxedString(text ?? $"Checked {self.Name}"),
                Sprite = sprite ?? new EmptySprite(),
            }
        });
    }
}
