using System;
using System.Collections.Generic;
using UnityEngine;

public class FieldCreator : MonoBehaviour
{
    [SerializeField]
    private Transform parentTransform;
    [SerializeField]
    private GameObject testMap;

    [Header("필드 생성 정보")]
    [SerializeField]
    [Tooltip("필드 전체의 구간 개수\n해당 개수 * 20 = 최대거리")]
    private int fieldBlockTotalCount;

    [Header("필드 블록")]
    [SerializeField]
    private GameObject startBockPrefeb;
    [SerializeField]
    [Tooltip("사용할 프리펩")]
    private List<GameObject> blockPrefebs = new List<GameObject>();
    [SerializeField]
    private GameObject endBlockPrefeb;

    public int fieldTotalLength;
    private int blockLength = 20;
    private int sectionCount;
    private Vector3 setPosition;
    private int minCount = 3;

    //한 화면에 20칸 / 
    //20칸씩 한 블록 * 3~4개로 1개의 구간

    public Action<int> OnCreateField;

    private void Awake()
    {
        if (testMap) testMap.SetActive(false);

        if (fieldBlockTotalCount < minCount) fieldBlockTotalCount = minCount;
        fieldTotalLength = fieldBlockTotalCount * blockLength;

    }

    private void Start()
    {
        OnCreateField?.Invoke(fieldTotalLength);
        SetStartBlock();
        SetNormalBlock();
        SetEndBlock();
    }

    private void SetStartBlock()
    {
        if (!startBockPrefeb) return;
        Debug.Log("시작 구간");
        Instantiate(startBockPrefeb, Vector3.zero, Quaternion.identity, parentTransform);
    }

    private void SetNormalBlock()
    {
        if (blockPrefebs.Count < 0)
        {
            Debug.Log("구간 프리펩 미등록");
            return;
        }
        int installCount = 1;

        for (int i = 0; i < fieldBlockTotalCount-2; i++)
        {
            int setX = blockLength * installCount;
            setPosition = new Vector3(setX, 0, 0);
            Debug.Log($"중간 구간 {i+1} : {setPosition}");
            int select = UnityEngine.Random.Range(0, blockPrefebs.Count);

            Instantiate(blockPrefebs[select], setPosition, Quaternion.identity, parentTransform);

            installCount++;
        }
    }

    private void SetEndBlock()
    {
        if (!endBlockPrefeb) return;

        int endX = blockLength * (fieldBlockTotalCount-1);
        Vector3 endPosition = new Vector3(endX, 0, 0);
        Debug.Log("마지막 구간 : " + endPosition);
        Instantiate(endBlockPrefeb, endPosition, Quaternion.identity, parentTransform);
    }
}
