using System.Collections.Generic;
using UnityEngine;

public class PositionGraphDebugger : MonoBehaviour
{
    [Header("Graph Settings")]
    public int maxSamples = 100;
    public float yScale = 1.0f;
    public float height = 0.5f;

    private List<Vector3> positions = new List<Vector3>();

    public float recordDistance = 0.2f;
    private Vector3 lastPos;

    void Update()
    {
        if (Vector3.Distance(transform.position, lastPos) > recordDistance)
        {
            Vector3 setPosition = new Vector3(transform.position.x, transform.position.y + height, transform.position.z);
            
            positions.Add(setPosition);
            lastPos = transform.position;
        }
    }

    void OnDrawGizmos()
    {
        if (positions == null || positions.Count < 2) return;

        Gizmos.color = Color.green;

        for (int i = 1; i < positions.Count; i++)
        {
            Vector3 p1 = positions[i - 1];
            Vector3 p2 = positions[i];

            // y값 강조하고 싶으면 스케일 적용
            p1.y *= yScale;
            p2.y *= yScale;

            Gizmos.DrawLine(p1, p2);
        }
    }
}