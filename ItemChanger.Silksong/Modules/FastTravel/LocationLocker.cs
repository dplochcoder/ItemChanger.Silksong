using Silksong.UnityHelper.Extensions;  // Transitive reference from ModMenu
using TeamCherry.SharedUtils;
using UnityEngine;

namespace ItemChanger.Silksong.Modules.FastTravel;

/// <summary>
/// Component to lock fast travel menu button for current station if not unlocked.
/// Reads the PlayerData bool tied to the original button to determine behavior.
/// </summary>
public class LocationLocker<TLocation> : MonoBehaviour where TLocation : struct, IComparable
{
    private FastTravelMapButtonBase<TLocation> _buttonComponent;
    private FastTravelMapBase<TLocation> _mapComponent;
    private UISelectionListItem _uiListItemComponent;
    private TMProOld.TextMeshPro _textComponent;

    void Awake()
    {
        _buttonComponent = GetComponent<FastTravelMapButtonBase<TLocation>>();

        if (_buttonComponent == null)
        {
            Destroy(this);
            return;
        }

        _mapComponent = GetComponentInParent<FastTravelMapBase<TLocation>>();
        _uiListItemComponent = GetComponent<UISelectionListItem>();
        _textComponent = gameObject.FindChild("Text")!.GetComponent<TMProOld.TextMeshPro>();

        _mapComponent.Opening += SetButtonLockedState;
    }

    private bool ShouldLockButton()
    {
        string pdBool = _buttonComponent.playerDataBool;

        // The original code for IsUnlocked, regardless of the value of IsCurrentLocation
        return !(string.IsNullOrEmpty(pdBool) || PlayerData.instance.GetVariable<bool>(pdBool));
    }

    private void SetButtonLockedState()
    {
        if (ShouldLockButton())
        {
            _textComponent.color = Color.gray;
            _uiListItemComponent.InactiveConditionText = () => "LOCKED";  // This text is never displayed, but needs to be nonempty
        }

        else
        {
            _textComponent.color = Color.white;
            _uiListItemComponent.InactiveConditionText = null;
        }
    }
}
