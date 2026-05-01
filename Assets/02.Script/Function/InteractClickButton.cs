using UnityEngine;

public class InteractClickButton : MonoBehaviour
{
    //private Button clickButton;
    [SerializeField]
    private GameObject target;
    [SerializeField]
    private GameObject other;



    public void ClickIToggleActive(GameObject target)
    {
        if (!target.activeSelf)
        {
            target.gameObject.SetActive(true);
        }
        else if (target.activeSelf)
        {
            target.gameObject.SetActive(false);
        }

        return;
    }

    public void SwitchingPopup()
    {
        if (!target.activeSelf || other.activeSelf)
        {
            if (other.activeSelf)
            {
                other.gameObject.SetActive(false);
            }
            target.gameObject.SetActive(true);
        }
        else if (target.activeSelf || !other.activeSelf)
        {
            target.gameObject.SetActive(false);
        }
    }

}
