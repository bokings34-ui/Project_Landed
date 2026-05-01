using System;
using UnityEngine;

[Serializable]
public class WorldItem : MonoBehaviour
{
    //[SerializeField]
    private string itemName;
    //[SerializeField]
    private int itemID;
    //[SerializeField]
    private int itemAmount;
    public string ItemName => itemName;
    public int ItemID => itemID;
    public int ItemAmount => itemAmount;
}
