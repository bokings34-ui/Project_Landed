using System;
using UnityEngine;

public class CharacterHp : MonoBehaviour, IApplicable
{
    private CharacterStateController StateController;

    public int maxHp = 160;
    public int currentHp = -1;
    private float reducePerSecond = 5f;
    private float hpAccumulator = 0f;
    private float fillAmount;
    private int obstacleDamage = 10;

    private bool isActive = true;
    private float timer;

    public event Action<float> UpdateHpUI;
    public event Action OnDead;



    private void Awake()
    {
        if (StateController == null)
        {
            StateController = GetComponent<CharacterStateController>();
        }
        currentHp = maxHp;
        UpdateHp();
    }

    private void OnEnable()
    {
        StateController.OnStateChanged += ApplyCharacterState;
    }

    private void OnDisable()
    {
        StateController.OnStateChanged -= ApplyCharacterState;
    }

    private void Update()
    {
        if (!isActive)
        { 
            if (timer +5 < Time.time)
            {
                Dead();
            }
            return;
        }

        DrainHP();
    }


    private void DrainHP()
    {
        if (currentHp <= 0) return;

        // 1. 시간 기반으로 누적
        hpAccumulator += reducePerSecond * Time.deltaTime;

        // 2. 1 이상 쌓이면 int로 반영
        if (hpAccumulator >= 1f)
        {
            int damage = Mathf.FloorToInt(hpAccumulator);
            hpAccumulator -= damage;

            currentHp = Mathf.Clamp(currentHp - damage, 0, maxHp);
            UpdateHp();
        }
    }

    public void TakeDamage(int damage)
    {
        currentHp = Mathf.Clamp(currentHp - damage, 0, maxHp);
        UpdateHp();
    }

    public void Dead()
    {
        if (currentHp > 0) return;

        OnDead.Invoke();
    }

    public void UpdateHp()
    {
        fillAmount = (float)currentHp / maxHp;
        //Debug.Log(currentHp);
        if (currentHp == 0)
        {
            //Debug.Log("OnDead 발행");
            OnDead?.Invoke();
        }
        UpdateHpUI.Invoke(fillAmount);

    }

    public void ApplyCharacterState(CharacterState state)
    {
        
        switch (state)
        {
            case CharacterState.Hurt:
                TakeDamage(obstacleDamage);
                break;
            case CharacterState.Fall:
                isActive = false;
                timer = Time.time;
                break;
            case CharacterState.Dead:
                isActive = false;
                break;
        }
    }
}


