using UnityEngine;

public class GoalLine : MonoBehaviour, ICheckable, IApplicable
{
    [SerializeField]
    private GameObject playableCharacter;
    private CharacterStateController StateController;

    private ConditionalSceneLoader conditionalChecker;

    private bool isChecked = false;
    private bool isSucceed = false;
    private bool isDead = false;

    public bool IsSuccess => isSucceed;
    public bool IsChecked => isChecked;
    public bool IsDead => isDead;
    public bool IsFall { get; set; }

    private void Awake()
    {
        if (StateController == null)
        {
            StateController = playableCharacter.GetComponent<CharacterStateController>();
        }
    }
    void Start()
    {
        if (playableCharacter == null)
        {
            playableCharacter = GameObject.FindGameObjectWithTag("Player");
        }

        if (conditionalChecker == null)
        {
            conditionalChecker = GetComponentInParent<ConditionalSceneLoader>();
        }
    }

    private void OnEnable()
    {
        StateController.OnStateChanged += ApplyCharacterState;

    }
    private void OnDisable()
    {
        StateController.OnStateChanged -= ApplyCharacterState;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == playableCharacter)
        {
            isSucceed = true;
            CheckCondition();
            conditionalChecker.CheckCondition();
        }
    }

    public void CheckCondition()
    {
        if (isDead || IsFall)
        {
            conditionalChecker.DoLoad();
        }


        if (isSucceed)
        {
            isChecked = true;
        }

    }

    public void ApplyCharacterState(CharacterState state)
    {
        switch (state)
        {
            case CharacterState.Dead:
                isDead = true;
                break;
        }
    }
}
