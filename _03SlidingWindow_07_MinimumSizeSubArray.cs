using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Minimum Size Subarray Sum
       Given an array of positive integers, nums, and a positive integer, target, 
       find the minimum length of a contiguous subarray whose sum is greater than or equal to the target. 
       If no such subarray is found, return 0.
    */

    class _03SlidingWindow_07_MinimumSizeSubArray
    {

        public static int MinSubArrayLen(int target, int[] nums)
        {
            int currentSum = 0;
            int begin = 0;
            int windowSize = int.MaxValue;

            for (int end = 0; end < nums.Length; ++end)
            {
                currentSum += nums[end];
                while (currentSum >= target)
                {
                    if (end - begin + 1 < windowSize)
                        windowSize = end - begin + 1;

                    currentSum -= nums[begin++];
                }
            }
            if (windowSize == int.MaxValue)
                return 0;
            else
                return windowSize;
        }

        public static void Compute()
        {
            List<int> target = new List<int> { 7, 4, 11, 10, 5, 15 };
            int[][] inputArr = {
            new int[] {2, 3, 1, 2, 4, 3},
            new int[] {1, 4, 4},
            new int[] {1, 1, 1, 1, 1, 1, 1, 1},
            new int[] {1, 2, 3, 4},
            new int[] {1, 2, 1, 3},
            new int[] {5, 4, 9, 8, 11, 3, 7, 12, 15, 44}};
            for (int i = 0; i < inputArr.Length; i++)
            {
                int windowSize = MinSubArrayLen(target[i], inputArr[i]);
                Console.WriteLine ( (i + 1) + ".\tInput array: " + string.Join(", ", inputArr[i]));
                Console.Write("\n\tTarget: " + target[i]);
                Console.WriteLine("\n\tMinimum Length of Subarray: " + windowSize);
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
