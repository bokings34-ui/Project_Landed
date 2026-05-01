using UnityEngine;

public class LobbUIButton : MonoBehaviour
{
    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터 플레이 중지
#else
    Application.Quit(); // 빌드에서 종료
#endif
    }
}
