using ItemChanger.Locations;
using ItemChanger.Silksong.Locations;
using Benchwarp.Data;
using ItemChanger.Silksong.Serialization;

namespace ItemChanger.Silksong.RawData;

internal static partial class BaseLocationList
{
    public static Location Crest_of_Wanderer => new CrestCorpseLocation
    {
        SceneName = SceneNames.Chapel_Wanderer,
        Name = LocationNames.Crest_of_Wanderer,
    };

    public static Location Crest_of_Reaper => new CrestCorpseLocation
    {
        SceneName = SceneNames.Greymoor_20c,
        Name = LocationNames.Crest_of_Reaper,
    };

    public static Location Crest_of_Beast => new CrestCorpseLocation
    {
        SceneName = SceneNames.Ant_19,
        Name = LocationNames.Crest_of_Beast,
    };

    public static Location Crest_of_Architect => new CrestCorpseLocation
    {
        SceneName = SceneNames.Under_20,
        Name = LocationNames.Crest_of_Architect,
    };

    public static Location Crest_of_Shaman => new CrestCorpseLocation
    {
        SceneName = SceneNames.Tut_05,
        Name = LocationNames.Crest_of_Shaman,
    };

    public static Location Crest_of_Witch => new YarnabyLocation
    {
        SceneName = SceneNames.Belltown_Room_doctor,
        Name = LocationNames.Crest_of_Witch,
    };

    public static Location Eva => new EvaLocation
    {
        SceneName = SceneNames.Weave_10,
        Name = LocationNames.Eva,
    };

    public static Location Rune_Rage => new DualLocation
    {
        SceneName = SceneNames.Slab_10b,
        Name = LocationNames.Rune_Rage,
        Test = new PDBool(nameof(PlayerData.defeatedFirstWeaver)),
        FalseLocation = new RuneRageLocation(),
        TrueLocation = new CoordinateLocation()
        {
            SceneName = SceneNames.Slab_10b,
            Name = LocationNames.Rune_Rage,
            X = 39,
            Y = 10,
            Managed = false,
        },
    };
}