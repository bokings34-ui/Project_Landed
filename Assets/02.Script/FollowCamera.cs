using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    [SerializeField]
    private FieldCreator creator;
    //[SerializeField]
    private Vector3 offset = new Vector3(5, 3, -10);
    public float smoothSpeed = 6f;

    private void LateUpdate()
    {
        Vector3 targetPosition = new Vector3(target.position.x + offset.x,  offset.y, offset.z);
        if (targetPosition.x <= creator.fieldTotalLength - 5)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        }
    }
}
