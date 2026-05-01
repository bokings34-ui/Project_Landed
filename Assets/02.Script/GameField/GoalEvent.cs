using UnityEngine;

public class GoalEvent : MonoBehaviour
{
    [SerializeField]
    private SceneName _sceneName;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameSceneManager.Instance.LoadSceneByName(_sceneName);
    }

}
