using UnityEngine;

public class SessionData : MonoBehaviour
{
    // 런타임 중에 반영되는 값
    // + 저장하지는 않지만 다른 씬에 공유하는 값들

    // Lobby->run ->Lobby(마지막에 고른 조합유지)
    public int selectCharacterId;
    public int[] selectAmuletId;
    // run->result
    public int score;
    public int rewardAmount;
    public bool isSuccessed;

    public int[] CombineInt(int charater, int[] amulets)
    {
        int[] combine = new int[4] { charater, amulets[0], amulets[1], amulets[2] };
        return combine;
    }
}
