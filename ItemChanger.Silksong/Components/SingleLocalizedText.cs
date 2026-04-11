using ItemChanger.Silksong.Modules;
using TeamCherry.Localization;

namespace ItemChanger.Silksong.Components;

internal class SingleLocalizedText : ILocalisedTextCollection
{
    public required string text;

    public bool IsActive => true;

    public LocalisedString GetRandom(LocalisedString skipString)
    {
        return new(sheet: ExactLanguageStrings.ITEMCHANGER_EXACT_SHEET, key: text);
    }
}
