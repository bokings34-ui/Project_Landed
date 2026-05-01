
using System.Collections.Generic;
using UnityEngine;

public class SelectSlot : MonoBehaviour
{
    int itemId;
    int hasAmount;
    int characterSlot;
    int[] amuletSlot = new int[3];
    bool ishave => hasAmount > 0;

    Dictionary<int, int> hasItem = new Dictionary<int, int>();

}