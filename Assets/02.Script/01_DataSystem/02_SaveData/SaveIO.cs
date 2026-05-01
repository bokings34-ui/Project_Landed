using System.Collections.Generic;
using UnityEngine;
using projectUtil;

public class SaveIO
{
    // save & load ½ÇÇà

    private const string HighScore_Key = "HighScore";
    private const string Gold_Amount_Key = "Gold";
    private const string Coin_Amount_Key = "Coin";
    private const string Owned_Character_ID_Key = "OwnedCharacters";
    private const string Owned_Amulet_ID_Key = "OwnedAmulets";
    private const string Combination_Set_ID_Key = "CombinationSet";

    private const string BGM_Volume_ID_Key = "BGMvolume";
    private const string SFX_Volume_ID_Key = "SFXvolume";


    public static void Save(PlayerSaveData data)
    {
        PlayerPrefs.SetFloat(BGM_Volume_ID_Key, data.bgmVolume);
        PlayerPrefs.SetFloat(SFX_Volume_ID_Key, data.sfxVolume);

        PlayerPrefs.SetInt(Gold_Amount_Key, data.gold);
        PlayerPrefs.SetInt(Coin_Amount_Key, data.coin);
        PlayerPrefs.SetInt(HighScore_Key, data.highScore);
        PlayerPrefs.SetString(Combination_Set_ID_Key, string.Join(',', data.combinationSet));
        PlayerPrefs.SetString(Owned_Character_ID_Key, string.Join(',', data.ownCharaters));
        PlayerPrefs.SetString(Owned_Amulet_ID_Key, string.Join(',', data.ownAmulets));

        PlayerPrefs.Save();
    }

    public static void Load(PlayerSaveData data)
    {
        data.bgmVolume = PlayerPrefs.GetFloat(BGM_Volume_ID_Key, 1f);
        data.sfxVolume = PlayerPrefs.GetFloat(SFX_Volume_ID_Key, 1f);

        data.gold = PlayerPrefs.GetInt(Gold_Amount_Key, 0);
        data.coin = PlayerPrefs.GetInt(Coin_Amount_Key, 100);
        data.highScore = PlayerPrefs.GetInt(HighScore_Key, 0);
        data.combinationSet = Utility.StringToIntArray(PlayerPrefs.GetString(Combination_Set_ID_Key, "0,0,0,0"));
        data.ownCharaters = Utility.StringToIntList(PlayerPrefs.GetString(Owned_Character_ID_Key, "100001"),true);
        data.ownAmulets = Utility.StringToIntList(PlayerPrefs.GetString(Owned_Amulet_ID_Key, "200001"),true);
    }


    public static int[] StringToArray(string value)
    {
        string[] split = value.Split(',');
        int[] intArray = new int[split.Length];
        for (int i = 0; i < split.Length; i++)
        {
            int.TryParse(split[i], out intArray[i]);
        }
        return intArray;
    }

    public static List<int> StringToList(string value)
    {
        string[] split = value.Split(',');
        int maxCount = 8;

        if (split.Length >= maxCount)
        {
            for (int i = 1; i < 7; i++)
            {
                maxCount = (int)Mathf.Pow(2, i);
                if (maxCount > split.Length)
                {
                    break;
                }
            }
        }

        List<int> intList = new List<int>(maxCount);
        foreach (string splitData in split)
        {
            intList.Add(int.Parse(splitData));
        }
        return intList;
    }
}
