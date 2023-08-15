using System;
using System.Collections.Generic;
using System.Linq;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Let's solve the Find Maximum in Sliding Window problem using the Sliding Window pattern.
    Statement
    Given an integer list nums, find the maximum values in all the contiguous subarrays (windows) of size w.

    Note: If the window size is greater than the list size, we consider the entire list as a single window.
    */

    class _03SlidingWindow_02_MaximumInSlidingWindow
    {
        public static List<int> FindMaxSlidingWindow(int[] nums, int windowSize)
        {
            if (windowSize > nums.Length)
                windowSize = nums.Length;
            //Item1 is the value, Item2 is the index
            List<int> maximumInWindow = new List<int>();
            LinkedList<(int, int)> deque = new LinkedList<(int, int)>();
            for (int end = 0; end < nums.Length; ++end)
            {
                //remove the first item if it is outside the window
                if (deque.Count > 0 && end - windowSize >= deque.First().Item2)
                    deque.RemoveFirst();
                //Remove all items from the end that are less than or equal
                while (deque.Count > 0 && nums[end] >= deque.Last().Item1)
                    deque.RemoveLast();
                //Add the item to the queue
                deque.AddLast((nums[end], end));
                //Add the first item, because it is the maximum in the window
                if (end + 1 >= windowSize)
                    maximumInWindow.Add(deque.First().Item1);
            }
            return maximumInWindow;
        }
        public static void Compute()
        {
           List<int> windowSizes = new List<int>{ 3, 3, 3, 3, 2, 4, 3, 2, 3, 18 };
            int[][] numsList = new int[][] {
                new int[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10},
                new int[] {10, 9, 8, 7, 6, 5, 4, 3, 2, 1},
                new int[] {10, 10, 10, 10, 10, 10, 10, 10, 10, 10},
                new int[] {1, 5, 8, 10, 10, 10, 12, 14, 15, 19, 19, 19, 17, 14, 13, 12, 12, 12, 14, 18, 22, 26, 26, 26, 28, 29, 30},
                new int[] {10, 6, 9, -3, 23, -1, 34, 56, 67, -1, -4, -8, -2, 9, 10, 34, 67},
                new int[] {4, 5, 6, 1, 2, 3},
                new int[] {9, 5, 3, 1, 6, 3},
                new int[] {2, 4, 6, 8, 10, 12, 14, 16},
                new int[] {-1, -1, -2, -4, -6, -7},
                new int[] {4, 4, 4, 4, 4, 4}
              };
            
            for (int i = 0; i < numsList.Length; i++)
            {
                Console.Write( i + 1 + ".\tInput array:\t");
                Console.WriteLine("[" + string.Join(" ", numsList[i]) + "]");
                Console.WriteLine("\tWindow size:\t" + windowSizes[i] );
                List<int> output = FindMaxSlidingWindow(numsList[i], windowSizes[i]);
                Console.Write("\n\tMaximum in each sliding window:\t");
                Console.WriteLine("[" + string.Join(" ", output) + "]");
                Console.WriteLine("-------------------------------------------------------------------");
            }
        }
    }
}
