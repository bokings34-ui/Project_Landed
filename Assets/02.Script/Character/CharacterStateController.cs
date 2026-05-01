using System;
using TMPro;
using UnityEngine;
using static GameSceneManager;


public enum CharacterState
{
    Default,
    Hurt,
    Buster,
    Fall,
    Dead,
    Goal,
    Pause
}

public class CharacterStateController : MonoBehaviour
{

    [SerializeField]
    TextMeshProUGUI countdownText;
    private CharacterHitbox characterHitbox;
    private CharacterHp hp;
    private CharacterMove charaterMovement;

    private float fallDeadTimer = 0f;
    private bool isFallTimer = false;
    private int countDown;

    public CharacterState State { get; private set; }

    public event Action<CharacterState> OnStateChanged;

    private void Awake()
    {
        if (characterHitbox == null)
        {
            characterHitbox = GetComponentInChildren<CharacterHitbox>();
        }

        if (hp == null)
        {
            hp = GetComponent<CharacterHp>();
        }

        if (charaterMovement == null)
        {
            charaterMovement = GetComponent<CharacterMove>();
        }
        countdownText.gameObject.SetActive(false);

        State = CharacterState.Default;
    }

    private void OnEnable()
    {
        characterHitbox.OnRequestDestroyObstacle += Handle_HitObstacle;
        hp.OnDead += Handle_Dead;
        charaterMovement.OnFall += Handle_Fall;

    }

    private void OnDisable()
    {
        characterHitbox.OnRequestDestroyObstacle -= Handle_HitObstacle;
        hp.OnDead -= Handle_Dead;
        charaterMovement.OnFall -= Handle_Fall;
    }

    private void Update()
    {
        if (isFallTimer)
        {
            fallDeadTimer -= Time.deltaTime;
            countDown = Mathf.FloorToInt(fallDeadTimer);
                countDown++;
            UpDateUI();
            if (fallDeadTimer <= 0f)
            {
                isFallTimer = false;
                countdownText.gameObject.SetActive(false);
                SetState(CharacterState.Dead);
            }
        }
    }

    private void SetState(CharacterState newState)
    {
        Debug.Log($"SetState 시도: {newState} / 현재: {State}");
        if (!CanChangeState(newState)) return;

        State = newState;
        Debug.Log($"SetState 완료: {State}");
        OnStateChanged?.Invoke(State);
        if (State == CharacterState.Dead)
        {
            FailedLoad();
        }
    }


    private bool Handle_HitObstacle()
    {
        //State = CharacterState.Buster;
        //버스터 여부 체크
        if (State == CharacterState.Buster)
        {
            return true;
        }

        SetState(CharacterState.Hurt);

        if (State == CharacterState.Dead) return false;

        Invoke(nameof(ReturnToDefault), characterHitbox.cooldownTime);
        return false;
    }

    private void ReturnToDefault()
    {
        SetState(CharacterState.Default);
    }

    private void Handle_Dead()
    {
        Debug.Log("Handle_Dead 호출");
        SetState(CharacterState.Dead);
    }

    private void Handle_Fall()
    {
        SetState(CharacterState.Fall);
        fallDeadTimer = 3f;
        countDown = 3;
        isFallTimer = true;
    }

    private void FailedLoad()
    {
        GameSceneManager.Instance.LoadSceneByName(SceneName.Result);

    }
    private bool CanChangeState(CharacterState newState)
    {
        if (State == CharacterState.Dead) return false;

        if (State == CharacterState.Hurt && newState == CharacterState.Hurt)
            return false;

        return true;
    }
    private void UpDateUI()
    {
        if (countdownText != null)
        {
            if (isFallTimer)
            {
                countdownText.gameObject.SetActive(true);
            }
            countdownText.text = countDown+"";
        }

        //Debug.Log("Distance: " + currentPosition + "m");
    }
}