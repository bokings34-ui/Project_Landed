using System.Collections.Generic;
using System.IO.Enumeration;
using UnityEngine;

[CreateAssetMenu(fileName = "DataFileIndex", menuName = "GameData/Data File Index")]
public class DataFileIndex : ScriptableObject
{
    //파일 확장자 목록
    public List<string> fileNames = new List<string>();
    public List<string> extnesions = new List<string>();

    public string GetExtension(string fileName)
    {
        int index = fileNames.IndexOf(fileName);
        if (index < 0) return string.Empty;

        return extnesions[index];
    }
}