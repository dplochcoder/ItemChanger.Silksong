using ItemChanger.Silksong.Serialization;

namespace ItemChanger.Silksong.RawData;

// This is a partial class containing a large number of LanguageString properties. The properties are arranged in the files in the BaseLanguageStrings folder.

internal static partial class BaseLanguageStrings
{
    public static LanguageString DefaultString => new("UI", "UI_BLANK");

    public static List<LanguageString> GetBaseLanguageStrings() => [.. typeof(BaseLanguageStrings).GetProperties().Select(p => (LanguageString)p.GetValue(null)!)];
}
