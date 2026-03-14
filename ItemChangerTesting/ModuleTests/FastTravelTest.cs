using Benchwarp.Data;
using ItemChanger;
using ItemChanger.Locations;
using ItemChanger.Placements;
using ItemChanger.Silksong.Modules.FastTravel;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ModuleTests;

internal class FastTravelTest : Test
{
    public override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ModuleTests,
        MenuName = "Fast Travel",
        MenuDescription = "Tests the fast travel stuff",
        Revision = 2026021400,
    };

    public override void Setup(TestArgs args)
    {
        StartNear(SceneNames.Bellway_Shadow, PrimitiveGateNames.left1);

        // Add modules
        Modules.CreateBellwayModules();
        Modules.CreateVentricaModules();

        {
            // Add location to test unlocking a bellway in the correct scene
            Placement pmt = new CoordinateLocation()
            {
                Name = "Bellway Shadow location",
                Managed = false,
                SceneName = SceneNames.Bellway_Shadow,
                X = 44.11f,
                Y = 22.57f,
            }.Wrap()
             .Add(Finder.GetItem(ItemNames.Bellway__Bilewater)!);
            Profile.AddPlacement(pmt);
        }

        {
            // Add locations for bone bottom and marrow bellways
            Placement pmt = new CoordinateLocation()
            {
                Name = "Bellway Bonebottom location",
                Managed = false,
                SceneName = SceneNames.Bellway_01,
                X = 52.37f,
                Y = 21.59f,
            }.Wrap()
             .Add(Finder.GetItem(ItemNames.Bellway__Bone_Bottom)!);
            Profile.AddPlacement(pmt);
        }

        {
            // Add locations for bone bottom and marrow bellways
            Placement pmt = new CoordinateLocation()
            {
                Name = "Bellway Marrow location",
                Managed = false,
                SceneName = SceneNames.Bone_05,
                X = 137.18f,
                Y = 4.57f,
            }.Wrap()
             .Add(Finder.GetItem(ItemNames.Bellway__The_Marrow)!);
            Profile.AddPlacement(pmt);
        }

        {
            Placement pmt = new CoordinateLocation()
            {
                Name = "Ventrica Terminus location",
                Managed = false,
                SceneName = SceneNames.Tube_Hub,
                X = 68.77f,
                Y = 39.57f,
            }.Wrap()
             .Add(Finder.GetItem(ItemNames.Ventrica__Terminus)!);
            Profile.AddPlacement(pmt);
        }

        {
            Placement pmt = new CoordinateLocation()
            {
                Name = "Ventrica Hang location",
                Managed = false,
                SceneName = SceneNames.Hang_06b,
                X = 23.14f,
                Y = 4.57f,
            }.Wrap()
             .Add(Finder.GetItem(ItemNames.Ventrica__High_Halls)!);
            Profile.AddPlacement(pmt);
        }
    }
}
