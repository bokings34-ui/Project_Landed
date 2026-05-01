using System;
using UnityEngine;

public class CharacterHitbox : MonoBehaviour
{
    private SetFieldItem fieldItem;

    public float cooldownTime = 0.5f; // 충돌 후 재충돌까지의 시간
    private float lastHitTime = -999f;
    private bool isInvincible => (Time.time < lastHitTime + cooldownTime);

    /// <summary>
    /// 장애물의 파괴가 가능한지 체크. true = destroy / false = damage.
    /// </summary>
    public event Func<bool> OnRequestDestroyObstacle;
    public event Action<int> OnHitItem;



    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject item = collision.gameObject;

        if(item.layer == 10)//(장애물)
        {
            //Debug.Log("충돌 : " + collision);
            HitColliderObstacle(item);
        }

        if (item.layer == 11)//(아이템)
        {
            fieldItem = item.GetComponent<SetFieldItem>();

            //Debug.Log("획득 : " + fieldItem.ItemId);
            OnHitItem?.Invoke(fieldItem.ItemId);
        }
    }

    private void HitColliderObstacle(GameObject obstacle)
    {
        if (isInvincible)
        {
            //Debug.Log($"쿨타임: {isInvincible}");
            return; //무적시간
        }

        float tempTime = Time.time;
        bool accepted = OnRequestDestroyObstacle?.Invoke() ?? false;
        Debug.Log("충돌! 파괴 가능 여부 :" + accepted);
        if (accepted)
        {
            obstacle.SetActive(false);
            //Destroy(obstacle);
            return;
        }
        else
        {
            lastHitTime = tempTime;
            //Debug.Log("충돌 효과");
        }
    }

}
