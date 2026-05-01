using System;
using UnityEngine;

public class CharacterDistance : MonoBehaviour
{
    [SerializeField]
    private GameObject playableCharacter;

    private int startPosition;
    private int currentPosition;
    private int endPosition;

    private int distanceRatio = 1;
    private int rewardDistanceSection = 100;
    private int rewardCount;

    public int CurrentPosition => currentPosition;
    public int RewardCount => rewardCount;

    public event Action<int> UpdateDistanceUI;


    private void Awake()
    {
        if (playableCharacter == null)
        {
            playableCharacter = GameObject.FindGameObjectWithTag("Player");
            GetPositionX(ref startPosition);
        }

    }

    private void Start()
    {
        UpDateDistance();
    }

    private void Update()
    {
        GetPositionX(ref currentPosition);
        if (CurrentPosition != startPosition && endPosition != CurrentPosition)
        {
            UpDateDistance();
        }
    }

    //RoundToInt
    private void GetPositionX(ref int position)
    {
        int nowPosition = (Mathf.FloorToInt(playableCharacter.transform.position.x) / distanceRatio);
        if (nowPosition != position)
        {
            position = nowPosition;
        }
        //Debug.Log("위치 계산 : " + position);
    }

    public int GetTotalDistance()
    {
        endPosition = CurrentPosition;

        int distance = endPosition - startPosition;

        if (distance < rewardDistanceSection)
        {
            return distance;
        }

        if (distance >= rewardDistanceSection)
        {
            rewardCount = distance / rewardDistanceSection;
            return distance;
        }
        //Debug.Log("거리 측정 : " + distance);
        return 0;
    }

    private void UpDateDistance()
    {
        int tempPosition = CurrentPosition;
        UpdateDistanceUI.Invoke(tempPosition);

    }
}
