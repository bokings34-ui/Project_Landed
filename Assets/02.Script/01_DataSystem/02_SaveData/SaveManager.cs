public class SaveManager 
{
    // save & load °ü¸®
    private PlayerSaveData saveData;
    private RuntimeManager runtime;

    public SaveManager(RuntimeManager runtimeManager)
    {
        runtime = runtimeManager;
    }


    public  void SavePlayerData()
    {
        saveData.gold = runtime.Gold;
        saveData.coin = runtime.Coin;
        saveData.highScore = runtime.HighScore;
        saveData.combinationSet = runtime.CombinationSet;
        saveData.ownCharaters = runtime.OwnCharaters;
        saveData.ownAmulets = runtime.OwnAmulets;

        SaveIO.Save(saveData);
    }

    public  void LoadPlayerData()
    {
        SaveIO.Load(saveData);
        runtime.ApplySaveData(saveData);
    }

    
}
