using ItemChanger.Silksong.Util;
using Silksong.AssetHelper.ManagedAssets;

namespace ItemChanger.Silksong.Assets;

internal class GameObjectListCache : IObjectCache<IList<GameObject>>
{
    private Dictionary<string, ManagedAssetList<GameObject>> _assetLists = [];

    public IList<GameObject> GetAsset(string key)
    {
        if (_assetLists.TryGetValue(key, out ManagedAssetList<GameObject> assetList))
        {
            assetList.EnsureLoaded();
            return assetList.Handle.Result;
        }

        throw new ArgumentException($"GameObject asset list with key {key} not recognized");
    }

    public GameObjectListCache()
    {
        // Load scene asset lists
        if (!JsonUtils.TryDeserializeEmbeddedResource(
            "ItemChanger.Silksong.Resources.Assets.scenegameobjectlists.json",
            out Dictionary<string, ManagedAssetGroup<GameObject>.SceneAssetInfo>? sceneAssetListData))
        {
            throw new ArgumentException($"Could not find scene game object lists resource");
        }

        foreach ((string key, ManagedAssetGroup<GameObject>.SceneAssetInfo info) in sceneAssetListData)
        {
            _assetLists[key] = ManagedAssetList<GameObject>.FromSceneAsset(sceneName: info.SceneName, objPath: info.ObjPath);
        }
    }

    public void Load()
    {
        foreach (ManagedAssetList<GameObject> assetList in _assetLists.Values)
        {
            assetList.Load();
        }
    }

    public void Unload()
    {
        foreach (ManagedAssetList<GameObject> assetList in _assetLists.Values)
        {
            assetList.Unload();
        }
    }
}