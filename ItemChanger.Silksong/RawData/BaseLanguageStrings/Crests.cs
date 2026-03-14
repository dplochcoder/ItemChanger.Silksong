using ItemChanger.Silksong.Serialization;

namespace ItemChanger.Silksong.RawData;

internal static partial class BaseLanguageStrings
{
    //crests
    //TODO: find better names/descriptions for cloakless and cursed
    //TODO: find better names for hunter crest upgrades
        //both upgrades have the name Hunter
    public static LanguageString Crest_of_Architect_Name => new("Tools", "CREST_TOOLMASTER_NAME");
    public static LanguageString Crest_of_Architect_Desc => new("Tools", "CREST_TOOLMASTER_DESC");
    public static LanguageString Crest_of_Beast_Name => new("Tools", "CREST_WARRIOR_NAME");
    public static LanguageString Crest_of_Beast_Desc => new("Tools", "CREST_WARRIOR_DESC");
    public static LanguageString Crest_of_Cloakless_Name => new("AutoSaveNames", "SLAB_CAPTURED");//says Caged
    public static LanguageString Crest_of_Cloakless_Desc => new("Tools", "EQUIP_BENCH_MSG_CURSED_CREST");//says Cannot change Crest
    public static LanguageString Crest_of_Cursed_Witch_Name => new("AutoSaveNames", "GAINED_CURSE");//says Cursed
    public static LanguageString Crest_of_Cursed_Witch_Desc => new("Tools", "EQUIP_BENCH_MSG_CURSED_CREST");//says Cannot change Crest
    public static LanguageString Crest_of_Hunter_Name => new("Tools", "CREST_HUNTER_NAME");
    public static LanguageString Crest_of_Hunter_Desc => new("Tools", "CREST_HUNTER_DESC");
    public static LanguageString Crest_of_Hunter__Upgrade_1_Name => new("Tools", "CREST_HUNTER_NAME");//improve
    public static LanguageString Crest_of_Hunter__Upgrade_1_Desc => new("Tools", "CREST_HUNTER_UPGRADED_DESC");
    public static LanguageString Crest_of_Hunter__Upgrade_2_Name => new("Tools", "CREST_HUNTER_NAME");//improve
    public static LanguageString Crest_of_Hunter__Upgrade_2_Desc => new("Tools", "CREST_HUNTER_UPGRADED_DESC");
    public static LanguageString Crest_of_Reaper_Name => new("Tools", "CREST_REAPER_NAME");
    public static LanguageString Crest_of_Reaper_Desc => new("Tools", "CREST_REAPER_DESC");
    public static LanguageString Crest_of_Shaman_Name => new("Tools", "CREST_SPELL_NAME");
    public static LanguageString Crest_of_Shaman_Desc => new("Tools", "CREST_SPELL_DESC");
    public static LanguageString Crest_of_Wanderer_Name => new("Tools", "CREST_PILGRIM_NAME");
    public static LanguageString Crest_of_Wanderer_Desc => new("Tools", "CREST_PILGRIM_DESC");
    public static LanguageString Crest_of_Witch_Name => new("Tools", "CREST_WITCH_NAME");
    public static LanguageString Crest_of_Witch_Desc => new("Tools", "CREST_WITCH_DESC");

    //vesticrests
    //TODO: find better names/descriptions for vesticrests
        //current name/description is Vesticrest : Use Tool
    public static LanguageString Vesticrest_Blue_Name => new("Tools", "UI_MSG_TITLE_EXTRASLOT_NAME");
    public static LanguageString Vesticrest_Blue_Desc => new("Prompts", "THROW_TOOL_GENERIC");
    public static LanguageString Vesticrest_Yellow_Name => new("Tools", "UI_MSG_TITLE_EXTRASLOT_NAME");
    public static LanguageString Vesticrest_Yellow_Desc => new("Prompts", "THROW_TOOL_GENERIC");

}
