namespace ItemChangerTesting.ItemTests;

// The following tests were not migrated with the ItemChangerTesting rewrite, to speed the overall migration.
// They are ok to add back to ItemTests if needed, ideally combining tests to reduce the number of menu items.

internal class OldItemTests
{
    /*
public enum TestIDs
{
    [Description("Tests giving Surgeon's_Key from a coordinate shiny")]//testing for keys
    Surgeon_s_Key_from_spawned_shiny,
    [Description("Tests giving Everbloom from a coordinate shiny")]//testing for plot items
    Everbloom_from_spawned_shiny,

    [Description("Tests giving all Hunter Crest variants (base + upgrades) from coordinate shinies")]//testing hunter crest upgrades
    Crest_of_Hunter_variants_from_spawned_shinies,
    [Description("Tests giving Wanderer Crest from a coordinate shiny")]//testing for crests
    Crest_of_Wanderer_from_spawned_shiny,
    [Description("Tests giving Cloakless from a coordinate shiny")]//testing for normally unobtainable/toggleable crests
    Cloakless_from_spawned_shiny,

    [Description("Tests giving Cross Stitch from a coordinate shiny")]//testing for silk skills
    Cross_Stitch_from_spawned_shiny,
    [Description("Tests giving red/blue/yellow tools from coordinate shinies")]//testing for tools
    Tools_from_spawned_shinies,
    [Description("Tests giving Curveclaw and Curvesickle from coordinate shinies")]//testing for tools with progressive upgrades
    Progressive_Tools_from_spawned_shinies,

    [Description("Tests giving Arcane Egg from a coordinate shiny")]//testing for relics
    Arcane_Egg_from_spawned_shiny,
    [Description("Tests giving Sacred Cylinder from a coordinate shiny")]//testing for relic that is also important for plot
    Vaultkeeper_s_Melody_from_spawned_shiny,

    [Description("Tests giving Pale Oil from a coordinate shiny")]//testing for items
    Pale_Oil_from_spawned_shiny,
    [Description("Tests giving Tool Pouch and Crafting Kit from coordinate shinies")]//testing for overlapping items
    Tool_Pouch_Kit_Inv_from_spawned_shiny,

    [Description("Tests giving Quills from coordinate shinies")]//testing for quills
    Quills_from_spawned_shiny,

    [Description("Tests giving Hornet Statuette from a coordinate shiny")]//testing for consumables
    Hornet_Statuette_from_spawned_shiny,

    [Description("Tests giving Hunter's Memento from a coordinate shiny")]//testing for mementos
    Hunter_s_Memento_from_spawned_shiny,

    [Description("Tests giving Farsight from a coordinate shiny")]//testing for collectable bellhome upgrades
    Farsight_from_spawned_shiny,

    [Description("Tests giving Twisted Bud from a coordinate shiny")]//testing for finite quest items
    Twisted_Bud_from_spawned_shiny,
    [Description("Tests giving multiple Flintgems from coordinate shinies")]//testing for multiple instances of the same finite quest item
    Flintgem_from_spawned_shinies,

    [Description("Tests giving delivery items from coordinate shinies")]//testing for delivery items
    Delivery_from_spawned_shinies,

    [Description("Tests giving Plasmium from a coordinate shiny")]//testing for respawning quest drops
    Plasmium_from_spawned_shinies,
}
    */

    /*
            case TestIDs.Everbloom_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Everbloom",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Everbloom)!));
                break;

            case TestIDs.Crest_of_Hunter_variants_from_spawned_shinies:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Base Hunter Crest (middle)",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Hunter)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Hunter Crest v2 (left)",
                    SceneName = SceneNames.Tut_02,
                    X = 130.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Hunter__Upgrade_1)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Hunter Crest v3 (right)",
                    SceneName = SceneNames.Tut_02,
                    X = 136.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Hunter__Upgrade_2)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Wanderer Crest (far right)",
                    SceneName = SceneNames.Tut_02,
                    X = 143.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Wanderer)!));
                break;

            case TestIDs.Crest_of_Wanderer_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Wanderer Crest",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Wanderer)!));
                break;

            case TestIDs.Cloakless_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Cloakless",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Crest_of_Cloakless)!));
                break;

            case TestIDs.Cross_Stitch_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Cross Stitch",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Cross_Stitch)!));
                break;

            case TestIDs.Tools_from_spawned_shinies:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Delver's Drill (left)",
                    SceneName = SceneNames.Tut_02,
                    X = 130.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Delver_s_Drill)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Multibinder (middle)",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Multibinder)!));
                
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Compass (right)",
                    SceneName = SceneNames.Tut_02,
                    X = 136.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Compass)!));
                break;

            case TestIDs.Progressive_Tools_from_spawned_shinies:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Curveclaw (left)",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Curveclaw)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Curvesickle (right)",
                    SceneName = SceneNames.Tut_02,
                    X = 136.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Curvesickle)!));
                break;

            case TestIDs.Arcane_Egg_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Arcane Egg",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Arcane_Egg)!));
                break;

            case TestIDs.Vaultkeeper_s_Melody_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Vaultkeeper's Melody",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Vaultkeeper_s_Melody)!));
                break;

            case TestIDs.Pale_Oil_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Pale Oil",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Pale_Oil)!));
                break;

            case TestIDs.Tool_Pouch_Kit_Inv_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Tool Pouch (left)",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Tool_Pouch)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Crafting Kit (right)",
                    SceneName = SceneNames.Tut_02,
                    X = 136.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Crafting_Kit)!));
                break;

            case TestIDs.Quills_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "White Quill (left)",
                    SceneName = SceneNames.Tut_02,
                    X = 130.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Quill__White)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Red Quill (middle)",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Quill__Red)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Purple Quill (right)",
                    SceneName = SceneNames.Tut_02,
                    X = 136.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Quill__Purple)!));
                break;

            case TestIDs.Hornet_Statuette_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Hornet Statuette",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Hornet_Statuette)!));
                break;

            case TestIDs.Hunter_s_Memento_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Hunter's Memento",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Hunter_s_Memento)!));
                break;

            case TestIDs.Farsight_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Farsight",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Farsight)!));
                break;

            case TestIDs.Twisted_Bud_from_spawned_shiny:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Twisted Bud",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Twisted_Bud)!));
                break;

            case TestIDs.Flintgem_from_spawned_shinies:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Flintgem (left)",
                    SceneName = SceneNames.Tut_02,
                    X = 130.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Flintgem)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Flintgem (middle)",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Flintgem)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Flintgem (right)",
                    SceneName = SceneNames.Tut_02,
                    X = 136.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Flintgem)!));
                break;

            case TestIDs.Delivery_from_spawned_shinies:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Courier's Swag (left)",
                    SceneName = SceneNames.Tut_02,
                    X = 130.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Courier_s_Swag)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Courier's Rasher (middle)",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Courier_s_Rasher)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Queen's Egg (right)",
                    SceneName = SceneNames.Tut_02,
                    X = 136.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Queen_s_Egg)!));
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Liquid Lacquer (far right)",
                    SceneName = SceneNames.Tut_02,
                    X = 139.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Liquid_Lacquer)!));
                break;

            case TestIDs.Plasmium_from_spawned_shinies:
                StartNear(SceneNames.Tut_02, PrimitiveGateNames.right1);
                Profile.AddPlacement(new CoordinateLocation
                {
                    Name = "Plasmium",
                    SceneName = SceneNames.Tut_02,
                    X = 133.6f,
                    Y = 31.57f,
                    FlingType = ItemChanger.Enums.FlingType.Everywhere,
                    Managed = false,
                }.Wrap().Add(Finder.GetItem(ItemNames.Plasmium)!));
                break;
    */
}
