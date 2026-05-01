using UnityEngine;


public enum PlayerState
{
    Running,
    Accelerate,

    Jumping,
    Sliding,

    Giantization,
    Magnetization,

    ActiveSkill
}


public class DataType : MonoBehaviour
{
    //생각나는 기능 임시 작성
    private bool isDestructible;
    private CharacterMove CharacterMove;
    private void DoAccelerate()
    {
        float MaintenanceTime = 5f;
        float startTime = Time.time;
        float endTime = startTime + MaintenanceTime;
        bool isActive = false;
        //능력 유지시간 설정
        if (Time.time < endTime)
        {
            isActive = true;
        }
        else
        {
            isActive = false;
        }


        if (isActive == true)
        {
            CharacterMove.rb.linearVelocityX = CharacterMove.moveSpeed * 2f;
        }

        if (isActive != true)
        {
            CharacterMove.rb.linearVelocityX = CharacterMove.moveSpeed;
        }
    }

    private void DoMagneticForce()
    {
        // 원의 반경을 변수로 지정해 사용된 아이템의 Value 값을 받는다.
        // 지속시간

        //TODO:: 반경 안의 아이템 콜리더 감지
        //TODO:: 감지된 아이템의 위치와 캐릭터의 위치를 캐릭터의 위치로 이동시키기
    }

    void DoGiants()
    {
        //TODO:: Rigidbody2D의 Scale을 일정 시간 동안 증가시키기
    }
}
