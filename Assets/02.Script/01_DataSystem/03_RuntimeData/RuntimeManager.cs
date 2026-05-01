using System.Collections.Generic;

public class RuntimeManager
{
    // 실행중에 변동되는 값 관리
    private SessionData session;

    public int Gold;
    public int Coin;
    public int HighScore;
    public int[] CombinationSet;
    public List<int> OwnCharaters;
    public List<int> OwnAmulets;

    public float BgmVolume;
    public float SfxVolume;

    public void UpdateRuntimeData()
    {
        CombinationSet = session.CombineInt(session.selectCharacterId, session.selectAmuletId);
    }

    //저장된 데이터 런타임으로 받아오기
    public void ApplySaveData(PlayerSaveData data)
    {
        Gold = data.gold;
        Coin = data.coin;
        HighScore = data.highScore;
        CombinationSet = data.combinationSet;
        OwnCharaters = data.ownCharaters;
        OwnAmulets = data.ownAmulets;
        BgmVolume = data.bgmVolume;
        SfxVolume = data.sfxVolume;
    }


  
}