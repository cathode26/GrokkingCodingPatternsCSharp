using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Find Median from a Data Stream
     * 
        Statement:
        Implement a data structure that’ll store a dynamically growing list of integers 
        and provide access to their median in O(1)
        Constraints:
        −10^5 ≤ num ≤10^5, where num is an integer received from the data stream.
        There will be at least one element in the data structure before the median is computed.
        At most, 5×10^4 calls will be made to the function that calculates the median.
     */


    public class MedianOfStream
    {
        //for the smaller numbers use the max heap
        PriorityQueue<float, float> maxHeap = new PriorityQueue<float, float>(Comparer<float>.Create((a,b)=>b.CompareTo(a)));
        //for the larger numbers use the min heap
        PriorityQueue<float, float> minHeap = new PriorityQueue<float, float>();
        public float InsertNum(float num)
        {
            //balance the values between the heaps
            if (maxHeap.Count == 0 || num <= maxHeap.Peek())
                maxHeap.Enqueue(num, num);
            else
                minHeap.Enqueue(num, num);

            //make sure that max heap is equal or larger than MinHeap
            if (minHeap.Count > maxHeap.Count)
            {
                float cur = minHeap.Dequeue();
                maxHeap.Enqueue(cur, cur);
            }
            else if (minHeap.Count + 1 < maxHeap.Count)
            {
                float cur = maxHeap.Dequeue();
                minHeap.Enqueue(cur, cur);
            }

            if (minHeap.Count == maxHeap.Count)
                return (minHeap.Peek() + maxHeap.Peek()) / 2.0f;
            else
                return maxHeap.Peek();
        }
    }
    public class _06TwoHeaps_02_MedianFromStream
    {
        static public void Compute()
        {
            MedianOfStream medianNum = new MedianOfStream();
            //int[] nums = { 35, 22, 30, 25, 1 };
            int[] nums = {3,5,7,2,8,10,11,65,72,81,99,100,150,155,160,162,164,166,168};
            List<int> numList = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                numList.Add(nums[i]);
                Console.WriteLine((i + 1) + ".\tData stream: " + String.Join(", ", numList));
                Console.WriteLine("\tThe median for the given numbers is: " + medianNum.InsertNum(nums[i]));
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
