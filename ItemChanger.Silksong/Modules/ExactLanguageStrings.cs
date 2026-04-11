using ItemChanger.Modules;
using MonoDetour.DetourTypes;

namespace ItemChanger.Silksong.Modules;

/// <summary>
/// Module enabling display of exact language strings; if text is taken from the
/// sheet with key <see cref="ITEMCHANGER_EXACT_SHEET"/>, then the key will be returned.
/// </summary>
[SingletonModule]
public class ExactLanguageStrings : Module
{
    public const string ITEMCHANGER_EXACT_SHEET = "ItemChanger.Exact";

    protected override void DoLoad()
    {
        // We have to skip the original methods because otherwise the log gets spammed with sheet nonexistence messages
        Using(Md.TeamCherry.Localization.Language.Get_System_String_System_String.ControlFlowPrefix(ReturnKey));
        Using(Md.TeamCherry.Localization.Language.Has_System_String_System_String.ControlFlowPrefix(KeyExists));
    }

    private ReturnFlow KeyExists(ref string key, ref string sheetTitle, ref bool returnValue)
    {
        if (sheetTitle == ITEMCHANGER_EXACT_SHEET)
        {
            returnValue = true;
            return ReturnFlow.SkipOriginal;
        }
        return ReturnFlow.None;
    }

    private ReturnFlow ReturnKey(ref string key, ref string sheetTitle, ref string returnValue)
    {
        if (sheetTitle == ITEMCHANGER_EXACT_SHEET)
        {
            returnValue = key;
            return ReturnFlow.SkipOriginal;
        }
        return ReturnFlow.None;
    }

    protected override void DoUnload()
    {
        
    }
}
