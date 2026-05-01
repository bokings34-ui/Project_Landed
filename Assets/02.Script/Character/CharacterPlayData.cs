using UnityEngine;

public class CharacterPlayData : MonoBehaviour
{

    public int BubbleCount { get; set; }
    public int DestroyCount {get; set;}
    public int GoldCount {get; set;}
    public int ShellCount {get; set;}
    public int MoveDistance {get; set;}
    public int TotalScore { get; private set;}


    [SerializeField]
    private int bubblePoint;
    [SerializeField]
    private int destroyPoint;
    [SerializeField]
    private int distancePoint;


    //private int[] countArray = new int[5];
    //private bool isAchieveReward;

    //public event Action

    private void Awake()
    {
        Init();
        GameObject playManager = GameObject.Find("PlayManager");
        CharacterPlayData playData = playManager.GetComponent<CharacterPlayData>();

    }


    private void OnEnable()
    {
        //Endsign 같은 이벤트 연동
    }

    private void OnDisable()
    {
        
    }

    private void Init()
    {
        BubbleCount = 0;
        DestroyCount = 0;
        GoldCount = 0;
        ShellCount = 0;
        MoveDistance = 0;
        //isAchieveReward = false;
    }

   private void CalculateScore()
    {
        int bubbleScore = BubbleCount * bubblePoint;
        int destroyScore = DestroyCount * destroyPoint;
        int distanceScore = distancePoint * distancePoint;

        TotalScore = (bubbleScore + destroyScore + distanceScore);
    }
}
