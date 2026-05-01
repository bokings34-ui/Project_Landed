using System.Collections.Generic;
using UnityEngine;


[DisallowMultipleComponent]
public class GameDataManager : MonoBehaviour
{ 
    public static GameDataManager Instance { get; private set; }

   

    public Dictionary<int, ItemData> itemData;

    public int selectedCharacterID=0;
    public int[] selectedAmuletsID = new int[3];
    public List<int> ownedCharacterIDslist;
    public List<int> ownedAmuletIDslist;
    public int currentGold = 0;
    public int currentCoin = 0;
    public int bestHighScore = 0;


    [Header("소유량 리스트 Capacity 제한\n최소 8. 초과시 4의 배수")]
    [SerializeField]
    private int CharacterListCount;
    [SerializeField]
    private int AmuletListCount;


    private void Awake()
    {
        #region 싱글톤 조건 (삭제금지)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion


        ownedCharacterIDslist = new List<int>(CharacterListCount);
        ownedAmuletIDslist = new List<int>(AmuletListCount);
    }


    private void Init()
    {

    }
    //TODO:: 게임 시작시, 아이템 Dictionary 만들고 참조.
    //TODO::캐릭터와 부적을 조합 데이터를 가지고 있다가, 씬 전환시 저장. (내용이 바뀌었을 때만(조건문) / playerPref)
    //TODO::최종 점수 참조
    //TODO::결과창에서 저장된 점수와 비교 후, 최고점수 저장(playerPref)
    //Lobby 나 Running으로 씬이 바뀔때, 저장한 조합 정보 반영
}
