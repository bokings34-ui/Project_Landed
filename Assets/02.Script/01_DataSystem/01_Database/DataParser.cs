using UnityEngine;

public class DataParser : MonoBehaviour
{
    //데이터 해석

    public static string LoadRawFile(string filename)
    {
        TextAsset file = Resources.Load<TextAsset>("Data/" + filename);
        if (file == null)
        {
            Debug.LogError($"{filename} 파일 없음");
        }
        return file.text;
    }

    public static string[][] ParseCSV(string fileText)
    {
        string[] lines = fileText.Split('\n');
        string[][] table = new string[lines.Length][];

        for (int i = 0; i < lines.Length; i++)
        {
            table[i] = lines[i].Replace("\r", "").Split(',');
        }

        return table;
    }
}
