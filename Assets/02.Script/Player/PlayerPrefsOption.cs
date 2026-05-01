using UnityEngine;

public class PlayerPrefsOption
{
    #region 고정 키 값
    private const string HighScore_Key = "HighScore";
    private const string Gold_Amount_Key = "GoldAmount";
    private const string Coin_Amount_Key = "CoinCount";
    private const string Owned_Character_ID_Key = "OwnedCharacters";
    private const string Owned_Amulet_ID_Key = "OwnedAmulets";
    private const string Selected_Character_ID_Key = "SelectedCharacter";
    private const string Selected_Amulet_ID_Key = "SelectedAmulets";
    #endregion

    public int currentScore = 10;
    public int goldAmount = 100;
    public int coinAmount = 100;
    public string ownedCharacter = "100000,100001";
    public string ownedAmulet = "200000,200001";
    public int selectedCharacter = 100000;
    public string selectedsAmulet = "0,0,0";

    public bool isMultipleSave = true;

    private GameDataManager DM => GameDataManager.Instance;

    public void LoadPayerPrefsAtStart()
    {

    }

    #region HighScore_Data
    public void SaveHighScore()
    {
        int currentScore = DM.bestHighScore;
        int savedScore = LoadHighScore();
        if (savedScore >= currentScore)
        {
            Debug.Log("[highScore] 갱신 불가. savedScore >= currentScore");
            return;
        }
        Debug.Log("[highScore] 최고 점수 정보 등록");
        PlayerPrefs.SetInt(HighScore_Key, currentScore);
    }

    public int LoadHighScore()
    {
        return PlayerPrefs.GetInt(HighScore_Key, 0);
    }
    #endregion

    #region Gold_Data 
    /// <param name="multyCheck">다른 항목과 동시 저장 여부 확인. false= 개별 저장</param>
    public void SaveGoldAmount(bool multyCheck = false)
    {
        int hasGold = LoadGoldAmount();
        if (goldAmount == hasGold)
        {
            Debug.Log("[Gold] 변동 없음");
            return;
        }

        PlayerPrefs.SetInt(Gold_Amount_Key, goldAmount);
        if (!multyCheck)
        {
            Debug.Log("[Gold] 저장");
            PlayerPrefs.Save();
        }
    }
    public int LoadGoldAmount()
    {
        return PlayerPrefs.GetInt(Gold_Amount_Key, 0);
    }
    #endregion

    #region Coin_Data
    /// <param name="multyCheck">다른 항목과 동시 저장 여부 확인. false= 개별 저장</param>
    public void SaveCoinAmount(bool multyCheck = false)
    {
        int hasCoin = LoadCoinAmount();
        if (coinAmount == hasCoin)
        {
            Debug.Log("[Coin] 변동 없음");
            return;
        }

        PlayerPrefs.SetInt(Coin_Amount_Key, coinAmount);
        if (!multyCheck)
        {
            Debug.Log("[Coin] 저장");
            PlayerPrefs.Save();
        }
    }

    public int LoadCoinAmount()
    {
        return PlayerPrefs.GetInt(Coin_Amount_Key, 0);
    }
    #endregion

    #region Selected_Slot_Data
    public void SaveSelectedCharacterID()
    {
        int selectedBefore = LoadSelectedCharacterID();
        if (selectedBefore == selectedCharacter)
        {
            Debug.Log("[캐릭터 선택] 이미 선택한 캐릭터");
            return;
        }
        PlayerPrefs.SetInt(Selected_Character_ID_Key, selectedCharacter);
    }

    public int LoadSelectedCharacterID()
    {
        return PlayerPrefs.GetInt(Selected_Character_ID_Key, 0);
    }


    /// <summary>
    /// 선택한 부적을 담은 array를 string으로 변환하여 저장하는 메서드
    /// selectedsAmulet = string.Join(",", arr)
    /// </summary>
    public void SaveSelectedAmuletID()
    {
        Debug.Log("[선택한 부적] " + selectedsAmulet);
        PlayerPrefs.SetString(Selected_Amulet_ID_Key, selectedsAmulet);
        //PlayerPrefs.Save();
    }

    /// <summary>
    /// 저장된 부적 ID string을 불러와서 int[]로 반환
    /// </summary>
    /// <returns>int[3]</returns>
    public int[] LoadSelectedAmuletID()
    {
        string amuletIDs = PlayerPrefs.GetString(Selected_Amulet_ID_Key, "0,0,0");
        string[] amuletIDStrings = amuletIDs.Split(',');
        int[] amuletIDArray = new int[amuletIDStrings.Length];

        for (int i = 0; i < amuletIDStrings.Length; i++)
        {
            int.TryParse(amuletIDStrings[i], out amuletIDArray[i]);
        }

        return amuletIDArray;
    }
    #endregion

    #region Owned_Data
    public void SaveOwnedCharacterID()
    {
        PlayerPrefs.SetString(Owned_Character_ID_Key, ownedCharacter);
        PlayerPrefs.Save();
    }

    //''=> char 구분 / " " string 구분
    /// <summary>
    /// 소유한 캐릭터 정보를 불러와 string => List로 전환
    /// </summary>
    public void LoadOwnedCharacterID()
    {
        string characterIDs = PlayerPrefs.GetString(Owned_Character_ID_Key, "100000,100001");
        string[] characterIDsStrings = characterIDs.Split(',');
        foreach (string characterID in characterIDsStrings)
        {
            DM.ownedCharacterIDslist.Add(int.Parse(characterID));
        }
    }

    public void SaveOwnedAmuletID()
    {
        PlayerPrefs.SetString(Owned_Amulet_ID_Key, ownedAmulet);
        PlayerPrefs.Save();
    }

    /// <summary>
    /// 소유한 부적 정보를 불러와 string => List로 전환
    /// </summary>

    public void LoadOwnedAmuletID()
    {
        string amuletIDs = PlayerPrefs.GetString(Owned_Amulet_ID_Key, "200000,200001");
        string[] amuletIDsStrings = amuletIDs.Split(',');
        foreach (string amuletID in amuletIDsStrings)
        {
            DM.ownedAmuletIDslist.Add(int.Parse(amuletID));
        }
    }
    #endregion
   
}
