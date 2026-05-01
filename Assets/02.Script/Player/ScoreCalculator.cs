using System;
using UnityEngine;

public class ScoreCalculator : MonoBehaviour
{
    //TODO:: 클리어 이벤트 구독. (거리, 점수가 있는 아이템, 파괴, 스킬 발동 등의 값을 호출해와서 점수로 계산
    void TotalScoreCalculator()
    {
        DistanceCompensation();
        GetItemScore();
        DestroyBonus();
        SkillBonus();
    }

    private void DistanceCompensation()
    {
        //TODO:: (마지막 위치 - 시작위치 )로 최종 이동거리 계산
        //TODO:: 거리 * 기본 배점
        //TODO:: 총 거리를 구역 개수 단위로 나눠서 int로 변환
        //TODO:: 해당하는 보너스 조건에 따라 보너스 점수 및 추가 보상 지급
    }

    private void GetItemScore()
    {
        //TODO:: 획득한 아이템 개수 집계
    }

    private void DestroyBonus()
    {
        //TODO::파괴된 장애물(소멸말고 파괴) 개수 집계
        //개수 * 기본 배점
    }

    private void SkillBonus()
    {
        //아직 이정 스킬내용 미정
        throw new NotImplementedException();
    }
}
