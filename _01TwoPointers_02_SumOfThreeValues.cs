using System;

namespace EducativeGrokkingCodingPatterns
{
    class _01TwoPointers_02_SumOfThreeValues
    {
        static bool FindSumOfThree2(int[] nums, int target)
        {
            //first sort the numbers so that they are ordered from least to greatest
            Array.Sort(nums);
            //Console.WriteLine(Print(nums));

            for(int i=0; i<nums.Length - 2; ++i)
            {
                int left = i+1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == target)
                        return true;
                    else if (sum > target)
                        right--;
                    else
                        left++;
                }
            }
            
            return false;
        }

        //8/11/23
        //11:10am - 11:40am
        static bool FindSumOfThree(int[] nums, int target)
        {
            for (int cur = 0; cur < nums.Length - 2; ++cur)
            {
                int left = cur+1;
                int right = nums.Length - 1;
                while (left < right)
                {
                    int total = nums[cur] + nums[left] + nums[right];
                    if (total == target)
                        return true;
                    if (total <= target)
                        left++;
                    else
                        right--;
                }
            }
            return false;
        }

        static public string Print(int[] list)
        {
            string output = "";
            for (int i = 0; i < list.Length; i++)
                output += list[i].ToString() + " ";
            return output;
        }
        static public void Compute()
        {
            int[][] numsLists = new int[][] {
                new int[] { 3, 7, 1, 2, 8, 4, 5 },
                new int[] { -1, 2, 1, -4, 5, -3 },
                new int[] { 2, 3, 4, 1, 7, 9 },
                new int[] { 1, -1, 0 },
                new int[] { 2, 4, 2, 7, 6, 3, 1 }
            };
            int[] testList = new int[] { 10, 7, 20, -1, 8 };
            for (int i = 0; i < numsLists.GetLength(0); i++)
            {
                Console.WriteLine((i + 1) + ".\tInput array: " + Print(numsLists[i]));

                if (FindSumOfThree(numsLists[i], testList[i]))
                    Console.WriteLine(" \tSum for " + testList[i] + " exists");
                else
                    Console.WriteLine(" \tSum for " + testList[i] + " does not exist");

                Console.WriteLine("----------------------------------------------------------------");
            }
        }

    }
}
