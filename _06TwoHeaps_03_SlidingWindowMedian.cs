using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{

    /* 
     *  Sliding Window Median:
     *  Statement
        Given an integer array, nums, and an integer, k, there is a sliding window of size k, 
        which is moving from the very left to the very right of the array. We can only see the k numbers in the window. 
        Each time the sliding window moves right by one position.
        Given this scenario, return the median of the each window. Answers within 10^-5 of the actual value will be accepted.

     * The key to solving this problem is tracking which element is in each heap.
     * Once we do this properly we can balance the heap so that even though there is dead elements in it, it will still be correct by
     * adding an element that is in the current window into the heap from the other heap.
     * when removing, we need to know which heap the element is coming from and that can be tricky. 
     * We can solve this problem without tracking indices but if we do that we could accidently remove an element that is in the window 
     * because it is a duplicate but in a different heap
     */
    public class _06TwoHeaps_03_SlidingWindowMedian
    {
        static public double Median(PriorityQueue<(int index, int priority), int> minHeap, PriorityQueue<(int index, int priority), int> maxHeap, int windowSize)
        {
            if (windowSize % 2 == 0)
                return (minHeap.Peek().priority + maxHeap.Peek().priority) / 2.0;
            else
                return maxHeap.Peek().priority;
        }
        static public int AddToHeap(int value, int index, PriorityQueue<(int index, int priority), int> minHeap, PriorityQueue<(int index, int priority), int> maxHeap, HashSet<int> minHeapMap, HashSet<int> maxHeapMap)
        {
            //Add the element to the heaps
            int balance = 0;
            if (maxHeap.Count == 0 || value <= maxHeap.Peek().priority)
            {
                balance--;
                maxHeap.Enqueue((index, value), value);
                maxHeapMap.Add(index);
            }
            else
            {
                balance++;
                minHeap.Enqueue((index, value), value);
                minHeapMap.Add(index);
            }
            return balance;
        }
        public static double[] MedianSlidingWindow(int[] values, int windowSize)
        {
            PriorityQueue<(int index, int priority), int> minHeap = new PriorityQueue<(int index, int priority), int>();
            PriorityQueue<(int index, int priority), int> maxHeap = new PriorityQueue<(int index, int priority), int>(Comparer<int>.Create((a,b) => b.CompareTo(a)));
            List<double> medians = new List<double>();
            HashSet<int> minHeapMap = new HashSet<int>();
            HashSet<int> maxHeapMap = new HashSet<int>();

            //We cannot delete the values once they are inside of the heaps so we must keep a balance between the heaps
            //When each element exits the window but can't be removed, we must increment the balancer and correct the heaps

            //prefill the array and calculate the first median
            for (int i = 0; i < values.Length && i < windowSize; i++)
            {
                maxHeapMap.Add(i);
                maxHeap.Enqueue((i, values[i]), values[i]);             //3,2,1
            }
            //move half the elements into the minHeap
            for (int i = 0; i < values.Length && i < windowSize / 2; i++)   //min heap 3 
            {                                                               //max heap = 2,1
                (int index, int priority) tuple = maxHeap.Dequeue();
                maxHeapMap.Remove(tuple.index);
                minHeap.Enqueue((tuple.index, tuple.priority), tuple.priority);
                minHeapMap.Add(tuple.index);
            }
            //calculate the median
            medians.Add(Median(minHeap, maxHeap, windowSize));

            int begin = 1;
            for (int end = windowSize; end < values.Length; ++end)
            {
                int balance = AddToHeap(values[end], end, minHeap, maxHeap, minHeapMap, maxHeapMap);

                if (maxHeapMap.Contains(begin-1))                   //the value we cant remove is in the max heap, so increment the balance
                    balance++;                                      //checking the value is not enough, we also need to check the index
                else 
                    balance--;                                      //the value we cant remove is in the min heap, so decrement the balance

                //now rebalance if we need to
                if (balance < 0)
                {
                    (int index, int priority) val = maxHeap.Dequeue();
                    maxHeapMap.Remove(val.index);
                    minHeap.Enqueue(val, val.priority);
                    minHeapMap.Add(val.index);
                }
                else if (balance > 0)
                {
                    (int index, int priority) val = minHeap.Dequeue();
                    minHeapMap.Remove(val.index);
                    maxHeap.Enqueue(val, val.priority);
                    maxHeapMap.Add(val.index);
                }

                while (maxHeap.Count > 0 && maxHeap.Peek().index < begin)
                {
                    //removed from maxHeap
                    (int index, int priority) val = maxHeap.Dequeue();
                    maxHeapMap.Remove(val.index);
                }
                while (minHeap.Count > 0 && minHeap.Peek().index < begin)
                {
                    //removed from minHeap
                    (int index, int priority) val = minHeap.Dequeue();
                    minHeapMap.Remove(val.index);
                }

                //calculate the median
                medians.Add(Median(minHeap, maxHeap, windowSize));
                begin++;
            }
            return medians.ToArray();
        }

        public static void Compute()
        {
            int[][] arr = new int[][]
            {
                new int[]{3, 1, 2, -1, 0, 5, 8},
                new int[]{1, 2},
                new int[]{4, 7, 2, 21},
                new int[]{22, 23, 24, 56, 76, 43, 121, 1, 2, 0, 0, 2, 3, 5},
                new int[]{1, 1, 1, 1, 1}
            };

            int[] k = { 4, 1, 2, 5, 2 };
            for (int i = 1; i <= k.Length; i++)
            {
                Console.WriteLine( i + ".\tInput array = " + String.Join(", ", arr[i - 1]) + ", k = " + k[i - 1]);
                double[] output = MedianSlidingWindow(arr[i - 1], k[i - 1]);
                Console.WriteLine("\tMedians = " + String.Join(", ", output));
                Console.WriteLine(new string('-', 100));
            }
        }

    }
}
