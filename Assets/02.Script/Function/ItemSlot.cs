using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class itemSlot : MonoBehaviour
{
    Image bgImage;
    Button itemButton;
    TextMeshProUGUI countText;
    Button checkButton;
    TextMeshProUGUI buttonText;



    private ItemData data;
    private int amount;

    public void SetupSlot(ItemData itemData, int itemAmount)
    {
        data = itemData;
        amount = itemAmount;


    }
}