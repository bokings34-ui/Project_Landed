using UnityEngine;

public class SelectInteract : MonoBehaviour
{
    GameObject CharacterSelect;
    GameObject AmuletSelect;

    void Start()
    {
        CharacterSelect = GameObject.Find("CharacterSelect-Popup");
        AmuletSelect = GameObject.Find("AmuletSelect-Popup");
    }

}