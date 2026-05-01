using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameUIController : MonoBehaviour
{
    [Header("체력 표시")]
    [SerializeField]
    private Slider hpSlider;
    [SerializeField]
    private CharacterHp hp;

    [Header("이동한 거리")]
    [SerializeField]
    private TextMeshProUGUI distanceUI;
    [SerializeField]
    private CharacterDistance distance;


    private void OnEnable()
    {
        if (hp == null) return;
        hp.UpdateHpUI += HpDisplay;

        if (distanceUI == null) return ;
        distance.UpdateDistanceUI += DistanceDisplay;
    }

    private void OnDisable()
    {
        if (hp == null) return;
        hp.UpdateHpUI -= HpDisplay;

        if (distanceUI == null) return;
        distance.UpdateDistanceUI -= DistanceDisplay;

    }


    private void HpDisplay(float hpRatio)
    {
        hpSlider.value = hpRatio;
    }

    private void DistanceDisplay(int currentDistance)
    {
        distanceUI.text = currentDistance + "m";
    }
}
