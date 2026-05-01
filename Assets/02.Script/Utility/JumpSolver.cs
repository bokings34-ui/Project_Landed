using UnityEngine;

public class JumpSolver : MonoBehaviour
{
    [Header("Target (원하는 결과)")]
    public float targetHeight = 4.0f;
    public float targetAirTime = 1.2f;

    [Header("Fixed Settings")]
    public float upwardGravity = 2.2f;
    public float fallGravity = 2.2f;
    public float peakGravity = 0.2f;

    public float fixedDeltaTime = 0.02f;

    [Header("Result")]
    public float solvedJumpForce;
    public float solvedBaseGravity;

    [ContextMenu("Solve Jump")]
    public void Solve()
    {
        float bestError = float.MaxValue;

        // 탐색 범위 (중요)
        for (float jf = 5f; jf <= 30f; jf += 0.5f)
        {
            for (float bg = 10f; bg <= 60f; bg += 0.5f)
            {
                Simulate(jf, bg, out float height, out float airTime);

                float error =
                    Mathf.Abs(height - targetHeight) +
                    Mathf.Abs(airTime - targetAirTime);

                if (error < bestError)
                {
                    bestError = error;
                    solvedJumpForce = jf;
                    solvedBaseGravity = bg;
                }
            }
        }

        Debug.Log(
            $"[Solved] JumpForce={solvedJumpForce:F2}, BaseGravity={solvedBaseGravity:F2}, Error={bestError:F3}"
        );
    }

    void Simulate(float jumpForce, float baseGravity, out float peakHeight, out float totalTime)
    {
        float y = 0f;
        float vy = jumpForce;
        float t = 0f;

        peakHeight = 0f;

        for (int i = 0; i < 2000; i++)
        {
            // 중력 적용 (CharacterMove 동일)
            if (vy > 0.1f)
                vy -= baseGravity * upwardGravity * fixedDeltaTime;
            else if (Mathf.Abs(vy) <= 0.1f)
                vy -= baseGravity * peakGravity * fixedDeltaTime;
            else
                vy -= baseGravity * fallGravity * fixedDeltaTime;

            y += vy * fixedDeltaTime;
            t += fixedDeltaTime;

            if (y > peakHeight)
                peakHeight = y;

            if (y <= 0f && t > fixedDeltaTime)
            {
                totalTime = t;
                return;
            }
        }

        totalTime = t;
    }
}