using System;
using UnityEngine;

public class CharacterMove : MonoBehaviour, IApplicable
{
    //public GameObject target;
    public Rigidbody2D rb;
    public PlayerInputReader inputReader;
    //private PlayerDistance playerDistance;
    private CharacterStateController StateController;


    [Header("Move Speed")]
    [Tooltip("캐릭터의 이동 속도")]
    public float moveSpeed = 6f;

    [Header("Jump Gravity")]
    [Tooltip("점프 시 적용되는 중력 가중치 설정")]
    [SerializeField] public float jumpForce = 14f;
    [SerializeField] float baseGravity = 21f;   // 기본 가중치
    [SerializeField] float upwardGravity = 2.2f;   // 상승 중 (약하게)
    [SerializeField] float fallGravity = 2.2f;     // 하강 중 (강하게)
    [SerializeField] float peakGravity = 0.2f;     // 꼭대기 (거의 무중력 느낌)

    private int jumpCount = 0;

    private float tiemCount;
    private float delay = 1f;

    private bool isFall = false;
    //public bool IsFall { set => isFall; }
    private bool isActive =true;

    public event Action OnFall;

    private void Awake()
    {
        if (rb == null)
        {
            //Debug.Log("Rigidbody 적용");
            rb = GetComponent<Rigidbody2D>();
        }

        if (inputReader == null)
        {
            //Debug.Log("PlayerInputReader 적용");
            inputReader = GetComponent<PlayerInputReader>();
        }

        if (StateController == null)
        {
            StateController = GetComponent<CharacterStateController>();
        }


        gameObject.transform.position = Vector3.zero;
    }

    private void OnEnable()
    {
        StateController.OnStateChanged += ApplyCharacterState;
    }

    private void OnDisable()
    {
        StateController.OnStateChanged -= ApplyCharacterState;
    }


    private void FixedUpdate()
    {
        if (rb.position.y <= -5f)
        {
            if (!isFall)
            {
                isFall = true;
                OnFall?.Invoke();
                /*rb.linearVelocityX = 0;
                rb.constraints = RigidbodyConstraints2D.FreezePositionY;
                isFall = true;*/
                return;
            }

            return;
        }
        else
        {
            if (!isActive)
            {
                rb.linearVelocityX = 0;
                return;
            }
            // 기본 이동
            rb.linearVelocityX = moveSpeed;
        }

        float vy = rb.linearVelocity.y;

        if (vy > 0.1f) // 상승 중
        {
            vy -= baseGravity * upwardGravity * Time.fixedDeltaTime;
        }
        else if (Mathf.Abs(vy) <= 0.1f) // 꼭대기
        {
            vy -= baseGravity * peakGravity * Time.fixedDeltaTime;
        }
        else // 하강 중
        {
            vy -= baseGravity * fallGravity * Time.fixedDeltaTime;
            vy = Mathf.Max(vy, -20f); // ← 최대 하강속도 제한 추가
        }

        rb.linearVelocity = new Vector2(rb.linearVelocity.x, vy);
    }



    private void Update()
    {
        if (!isActive)
        {
            return;
        }
        if (isActive)
        {
            if (inputReader.JumpPressedThisFrame)
            {
                DoJump();
            }

            if (inputReader.SlideHeldPressed)
            {
                //TODO::슬라이드 구현
                Debug.Log("슬라이드");
            }

            if (inputReader.ResetPositionPressedThisFrame)
            {
                Debug.Log("R키 누름");
                ResetTransform();
            }

        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"충돌 감지: {collision.gameObject.name}, layer: {collision.gameObject.layer}");
        if (collision.gameObject.layer == 8 || collision.gameObject.layer == 9)
        {
            foreach (ContactPoint2D contact in collision.contacts)
            {
                if (contact.normal.y > 0.5f)
                {
                    jumpCount = 0;
                    Debug.Log("점프횟수 초기화");
                    break;
                }
            }
        }
    }

    private void DoJump()
    {
        if (jumpCount >= 2)
        {
            return;
        }
        //if (jumpRequested == true)
        //{
        //Debug.Log("점프");

        rb.linearVelocityY = jumpForce; // Y속도를 jumpForce로 설정
        jumpCount++;
        //Debug.Log(jumpCount);

        //jumpRequested = false;
        //}
    }

    private void ResetTransform()
    {
        rb.linearVelocityX = 0f;
        moveSpeed = 0f;
        this.transform.position = Vector3.zero;
        rb.constraints = RigidbodyConstraints2D.None;
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
        for (int i = 3; i > 0; i--)
        {
            Debug.Log($"Countdown: {i}");
        }

        rb.linearVelocityX = moveSpeed;
    }

    private void FreezeCharater()
    {
        Debug.Log($"FreezeCharater 호출 / isActive: {isActive}");
        rb.linearVelocity = Vector2.zero;
        isActive = false;
        Debug.Log($"FreezeCharater 완료 / isActive: {isActive}");

        /*rb.linearVelocity = Vector2.zero;
        rb.constraints = RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezePositionX;
        isActive = false;*/
    }


    public void ApplyCharacterState(CharacterState state)
    {
        Debug.Log($"ApplyCharacterState: {state}");
        switch (state)
        {
            case CharacterState.Default:
                if (moveSpeed != 6f)
                {
                    moveSpeed = 6f;
                }
                break;
            case CharacterState.Fall:
                FreezeCharater();
                isFall = true;
                break;
            case CharacterState.Dead:
                FreezeCharater();
                break;
            case CharacterState.Hurt:
                moveSpeed = 4f;
                break;

        }
    }
}
