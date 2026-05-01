using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public enum SceneName
{
    Title,
    Lobby,
    Running,
    Result
}

[DisallowMultipleComponent]
public  class GameSceneManager: MonoBehaviour
{
    public static GameSceneManager Instance { get; private set; }

    public string CurrentScene { get; private set; }
    private Stack<string> PreviousScene = new Stack<string>();
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        DontDestroyOnLoad(gameObject);
        if (PreviousScene.Count > 0)
        {
            PreviousScene.Clear();
        }
        CurrentScene = SceneManager.GetActiveScene().name;
    }

    private void SaveCurrentScene(string sceneName)
    {
        PreviousScene.Push(CurrentScene);
        CurrentScene = sceneName;
    }

    /// <summary>
    /// SceneName을 enum으로 입력받음 (외부. 오타 방지용)
    /// </summary>
    public void LoadSceneByName(SceneName sceneName)
    {
        string _name = sceneName.ToString();

        SaveCurrentScene(_name);
        LoadSceneByName(_name);
    }

    /// <summary>
    /// SceneName을 문자열로 입력 받음. (내부에서만 사용)
    /// </summary>
    private void LoadSceneByName(string sceneName)
    {

        if (!IsValidSceneName(sceneName))
        {
            Debug.LogWarning("[GameSceneManager] !SceneManager.GetSceneByName(_name).IsValid()");
            return;
        }

        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogWarning($"[GameSceneManager] LoadSceneByName 실패: Build Settings에 없는 씬입니다. sceneName={sceneName}");
            return;
        }

        SceneManager.LoadScene(sceneName);
    }

    /// <summary>
    /// 현재 활성 씬을 다시 로드한다.
    /// </summary>
    public void ReloadCurrentScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (!activeScene.IsValid())
        {
            Debug.LogWarning("[GameSceneManager] ReloadCurrentScene 실패: 현재 활성 씬이 유효하지 않습니다.");
            return;
        }

        LoadSceneByName(activeScene.name);
    }


    public void LoadPreviousScene()
    {
        string previous = PreviousScene.Pop();
        if (!IsValidSceneName(previous) || previous == CurrentScene)
        {
            return;
        }   

        LoadSceneByName(previous);
    }

    /// <summary>
    /// sceneName으로 비동기 로드를 시작하고 AsyncOperation을 반환한다.
    /// 호출 측에서 completed 콜백 연결이나 progress 표시를 구현할 수 있다.
    /// </summary>
    public AsyncOperation LoadSceneAsyncByName(string sceneName, LoadSceneMode loadSceneMode = LoadSceneMode.Single)
    {
        if (!SceneManager.GetSceneByName(sceneName).IsValid())
        {
            return null;
        }

        if (!Application.CanStreamedLevelBeLoaded(sceneName))
        {
            Debug.LogWarning($"[GameSceneManager] LoadSceneAsyncByName 실패: Build Settings에 없는 씬입니다. sceneName={sceneName}");
            return null;
        }

        SaveCurrentScene(sceneName);

        return SceneManager.LoadSceneAsync(sceneName, loadSceneMode);
    }

    /// <summary>
    /// SceneUtility에서 Index기반의 이름 추출.
    /// 확장자명을 제외한 이름과 비교
    /// </summary>
    /// <param name="sceneName"></param>
    /// <returns></returns>
    private bool IsValidSceneName(string sceneName)
    {
        int count = SceneManager.sceneCountInBuildSettings;

        for (int i = 0; i < count; i++)
        {
            string path = SceneUtility.GetScenePathByBuildIndex(i);
            string name = System.IO.Path.GetFileNameWithoutExtension(path);
            if (name == sceneName)
                return true;
        }
        return false;
    }
}