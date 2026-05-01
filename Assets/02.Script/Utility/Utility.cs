using System.Collections.Generic;
using UnityEngine;

namespace projectUtil
{
    public static class Utility
    {
        //convert
        /// <summary>
        /// 문자열로 된 배열의 정보를 Int 배열로 전환
        /// </summary>
        /// <param name="value"> string (,) 포함. 숫자만 들어있을것.</param>
        /// <returns>int배열</returns>
        public static int[] StringToIntArray(string value)
        {
            string[] split = value.Split(',');
            int[] intArray = new int[split.Length];
            for (int i = 0; i < split.Length; i++)
            {
                int.TryParse(split[i], out intArray[i]);
            }
            return intArray;
        }

        //convert
        /// <summary>
        /// 문자열은 숫자열 리스트로 바꾸는 매서드
        /// 제한단위: 최소 8. 최대 128.
        /// </summary>
        /// <param name="value">string (,) 포함. 숫자만 들어있을것.</param>
        /// <param name="limitCapacity">용량 제한 여부</param>
        /// <returns>int 리스트</returns>
        public static List<int> StringToIntList(string value, bool limitCapacity = false)
        {
            string[] split = value.Split(',');
            List<int> intList;

            if (limitCapacity != true)
            {
                intList = new List<int>();

                foreach (string splitData in split)
                {
                    intList.Add(int.Parse(splitData));
                }
                return intList;
            }

            int maxCount = 8;
            if (split.Length >= maxCount)
            {
                for (int i = 4; i < 8; i++)
                {
                    maxCount = (int)Mathf.Pow(2, i);
                    if (maxCount > split.Length)
                    {
                        break;
                    }
                }
            }

            intList = new List<int>(maxCount);
            foreach (string splitData in split)
            {
                intList.Add(int.Parse(splitData));
            }
            return intList;
        }
    }
}
