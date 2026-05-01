using System.IO;
using UnityEditor;
using UnityEngine;

public class DataFileIndexer : MonoBehaviour
{
    // 데이터 초기화(기본값 지정)
    [MenuItem("Tools/Rebuild Data File Index")]
    public static void BulidIndex()
    {
        string scanPath = Application.dataPath + "Resources/Data";
        string savePath = "Asset/Resouces/Data/DataFileIndex.asset";

        string[] files = Directory.GetFiles(scanPath);

        DataFileIndex indexAsset = ScriptableObject.CreateInstance<DataFileIndex>();

        indexAsset.fileNames.Clear();
        indexAsset.extnesions.Clear();

        foreach (string file in files)
        {
            if (file.EndsWith(".meta")) continue;
            if (file.EndsWith(".asset")) continue;

            string fileName = Path.GetFileNameWithoutExtension(file);
            string ext = Path.GetExtension(file);

            indexAsset.fileNames.Add(fileName);
            indexAsset.extnesions.Add(ext);

            Debug.Log($"등록됨 : {fileName} / {ext}");
        }

        AssetDatabase.CreateAsset(indexAsset, savePath);
        AssetDatabase.SaveAssets();
        AssetDatabase.Refresh();

        Debug.Log("DataFileIndex.asset 재생성 완료");
    }
}