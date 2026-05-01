using UnityEngine;

[DisallowMultipleComponent]
public class InGameManager : MonoBehaviour
{
     public static InGameManager Instance {  get; private set; }

    public SaveManager Save {  get; private set; }
    public RuntimeManager Runtime { get; private set; }


    private void Awake()
    {
        #region ΩÃ±€≈Ê ¡∂∞« (ªË¡¶±›¡ˆ)
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion

        Runtime = new RuntimeManager(); 
        Save = new SaveManager(Runtime);
    }
}
