using System.Collections.Generic;
using UnityEngine;

public class YMotionCalculator : MonoBehaviour
{
    [Header("Your Jump Settings (CharacterMove 기준)")]
    public float jumpForce = 16f;
    public float baseGravity = 25f;
    public float upwardGravity = 2.2f;
    public float fallGravity = 2.2f;
    public float peakGravity = 0.2f;

    [Header("Simulation")]
    public float fixedDeltaTime = 0.02f;
    public float groundY = 0f;

    [Header("Result")]
    public float peakHeight;
    public float timeToPeak;
    public float totalAirTime;

    public List<Vector2> samples = new List<Vector2>();

    [ContextMenu("Calculate Y Curve")]
    public void CalculateYCurve()
    {
        samples.Clear();

        float t = 0f;
        float y = 0f;
        float vy = jumpForce;

        peakHeight = y;
        timeToPeak = 0f;
        totalAirTime = 0f;

        for (int frame = 0; frame < 2000; frame++)
        {
            samples.Add(new Vector2(t, y));

            //  CharacterMove와 동일한 로직
            if (vy > 0.1f) // 상승
            {
                vy -= baseGravity * upwardGravity * fixedDeltaTime;
            }
            else if (Mathf.Abs(vy) <= 0.1f) // 꼭대기
            {
                vy -= baseGravity * peakGravity * fixedDeltaTime;
            }
            else // 하강
            {
                vy -= baseGravity * fallGravity * fixedDeltaTime;
            }

            y += vy * fixedDeltaTime;
            t += fixedDeltaTime;

            // 최고점 기록
            if (y > peakHeight)
            {
                peakHeight = y;
                timeToPeak = t;
            }

            // 착지 체크
            if (y <= groundY && t > fixedDeltaTime)
            {
                totalAirTime = t;
                samples.Add(new Vector2(t, groundY));
                break;
            }
        }

        Debug.Log(
            $"[Y Curve] PeakHeight={peakHeight:F2}, TimeToPeak={timeToPeak:F2}, TotalAirTime={totalAirTime:F2}, Samples={samples.Count}"
        );
    }

    [ContextMenu("Print Samples")]
    public void PrintSamples()
    {
        for (int i = 0; i < samples.Count; i++)
        {
            Debug.Log($"Frame {i}: t={samples[i].x:F2}, y={samples[i].y:F3}");
        }
    }
}