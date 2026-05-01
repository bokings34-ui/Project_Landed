using System.Collections.Generic;

[System.Serializable]
public class PlayerSaveData
{
    //저장되는 데이터
    public int gold;
    public int coin;
    public int highScore;
    public int[] combinationSet;
    public List<int> ownCharaters;
    public List<int> ownAmulets;

    public float bgmVolume;
    public float sfxVolume;
}
