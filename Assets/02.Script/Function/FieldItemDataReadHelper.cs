using UnityEngine;

public class FieldItemDataReadHelper : MonoBehaviour
{
    [SerializeField]
    private CharacterHitbox hitbox;
    [SerializeField]
    private CharacterPlayData playData;
    [SerializeField]
    private CharacterHp hp;


    private void OnEnable()
    {
        hitbox.OnHitItem += CheckItemType;
    }

    private void OnDisable()
    {
        hitbox.OnHitItem -= CheckItemType;
    }


    private void CheckItemType(int itemID)
    {
        FieldItemData item = ItemDatabase.Instance.GetFieldItem(itemID);
        if (item == null) return;

        switch (item.itemType)
        {
            case FieldItemType.Bubble:
                playData.BubbleCount++;
                Debug.Log("¹öºí È¹µæ : "+playData.BubbleCount);
                break;
            case FieldItemType.Coin:
                playData.GoldCount += item.itemValue;
                Debug.Log("°ñµå : "+playData.GoldCount);
                break;
            case FieldItemType.Shell:
                playData.ShellCount += item.itemValue;
                Debug.Log("Á¶°³ ÄÚÀÎ : " + playData.ShellCount);
                break;
            case FieldItemType.Giant:

                break;
            case FieldItemType.Booster:

                break;
            case FieldItemType.Magnet:

                break;
            case FieldItemType.Potion:
                hp.currentHp += item.itemValue;
                break;
        }

    }

}
