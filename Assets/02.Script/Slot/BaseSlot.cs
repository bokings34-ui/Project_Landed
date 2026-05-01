using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BaseSlot : MonoBehaviour,ISlot
{
    protected Sprite iconImage;
    protected TextMeshProUGUI countText;
    protected Button itemButton;

    protected ItemData data;
    protected int amount;

    void OnEnable() => itemButton.onClick.AddListener(OnClick);
    void OnDisable() => itemButton.onClick.RemoveListener(OnClick);


    public virtual void SetupSlot(ItemData itemData, int itemAmount)
    {
        data = itemData;
        amount = itemAmount;
        iconImage = data.icon;
    }

    public virtual void Clear()
    {
        data = null;
        amount = 0;
        iconImage = null;
    }


    protected virtual void OnClick() { }

}