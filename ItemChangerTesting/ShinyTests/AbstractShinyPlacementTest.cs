using ItemChanger.Silksong.Items;
using ItemChanger.Silksong.RawData;

namespace ItemChangerTesting.ShinyTests;

internal abstract class AbstractShinyPlacementTest<T> : Test where T : AbstractShinyPlacementTest<T>, new()
{
    public enum ItemType
    {
        Default,
        Assortment,
        Persistent,
        Flea,
    }
    public ItemType CurrentItemType = ItemType.Default;

    protected abstract string MenuName { get; }
    protected abstract string MenuDescription { get; }
    protected abstract int Revision { get; }

    public sealed override TestMetadata GetMetadata() => new()
    {
        Folder = TestFolder.ShinyTests,
        MenuName = MenuName,
        MenuDescription = MenuDescription,
        Revision = Revision
    };

    protected abstract void SetupStart();
    protected abstract string LocationName { get; }

    public sealed override void Setup(TestArgs args)
    {
        SetupStart();

        var placement = Finder.GetLocation(LocationName)!.Wrap();
        switch (CurrentItemType)
        {
            case ItemType.Default:
                placement.Add(Finder.GetItem(ItemNames.Surgeon_s_Key)!);
                break;
            case ItemType.Assortment:
                placement.WithVariousItems();
                break;
            case ItemType.Persistent:
                placement.WithVariousItems().WithAllPersistent();
                break;
            case ItemType.Flea:
                placement.Add(Finder.GetItem(ItemNames.Flea)!);
                placement.Add(RosariesItem.MakeRosariesItem(123));
                break;
        }
        Profile.AddPlacement(placement);
    }

    public sealed override IEnumerable<(string, Action)> TestMethods()
    {
        foreach (ItemType itemType in Enum.GetValues(typeof(ItemType)))
        {
            var copy = itemType;
            yield return ($"{itemType}", () => TestDispatcher.StartTest(new T()
            {
                CurrentItemType = itemType
            }));
        }
    }
}
