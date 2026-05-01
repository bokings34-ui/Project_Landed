using UnityEngine;

public class ConditionalSceneLoader : MonoBehaviour, ICheckable
{
    [SerializeField]
    private SceneName sceneName;
    [SerializeField]
    private GameObject checkRoot;

    private bool _isChecked = false;
    bool ICheckable.IsChecked => _isChecked;


    public void CheckCondition()
    {
        if (checkRoot == null)
        {
            DoLoad();
            return;
        }

        ICheckable[] checkables = checkRoot.GetComponentsInChildren<ICheckable>();

        if (checkables.Length == 0 )
        {
            _isChecked = true;
        }
        else
        {
            // C# 기능. 배열 내부를 전체 탐색하여 전부 true인지 확인
            // 기본적으로 함수를 만들어야 하지만, 람다식으로 변수 내용 바로 지정
            _isChecked = System.Array.TrueForAll(checkables, check => check.IsChecked);
        }

        if (_isChecked)
        {
            DoLoad();
        }
    }

    public void CheckCondition(GameObject target)
    {
        CheckCondition();
    }

    public void DoLoad()
    {
        GameSceneManager.Instance.LoadSceneByName(sceneName);
    }
}
