using TeamCherry.Localization;

namespace ItemChanger.Silksong.Util;

internal static class Localization
{
    internal const string Sheet = $"Mods.{ItemChangerPlugin.Id}";

    public static string GetLanguageString(this string key)
    {
        return Language.Get(key, Sheet);
    }
}
