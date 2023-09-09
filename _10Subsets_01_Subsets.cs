using System;
using System.Collections.Generic;
using System.Linq;

namespace EducativeGrokkingCodingPatterns
{
    /*
     *  Statement#
        Given an array of integers, nums, find all possible subsets of nums, including the empty set.
        Note: The solution set must not contain duplicate subsets. You can return the solution in any order.
    */

    /*  
     *  This is the default IEqualityComparer<List<int>>
     *  What we see is that we will compare references of the list in Equals
     *  We also need to create a hashcode because that is what HashSet and Dictionary uses
     *  public class DefaultListEqualityComparer : IEqualityComparer<List<int>>
        {
            public bool Equals(List<int> x, List<int> y)
            {
                return object.ReferenceEquals(x, y);
            }

            public int GetHashCode(List<int> obj)
            {
                return obj.GetHashCode();
            }
        }
    */

    /*
     * 
     *  Equals(List<int> x, List<int> y):
        This method checks if two List<int> objects, x and y, are equal.
        LINQ SequenceEqual:
        The method SequenceEqual is an extension method provided by LINQ that checks if two sequences 
        are equal by comparing their elements in order. So if x = [1, 2, 3] and y = [1, 2, 3], they are 
        considered equal. If y = [1, 3, 2], they are not equal even though they have the same elements.

        GetHashCode(List<int> obj):
        This method computes a hash code for a List<int>.
        The hash code for a list is computed by XOR-ing the hash codes of its individual elements. 
        XOR is a choice here because it's commutative, meaning a ^ b == b ^ a. Thus, lists with elements NOT in the same order 
        will have the same hash code. For example, the lists [1, 2, 3] and [3, 2, 1] will have the SAME hash codes.

        Question:
        So since they have the same hash code, but equality is different, how does the comparison work when it encounters [1, 2, 3] and [3, 2, 1] ?
        
    ChatGPT
        Great question! When two items produce the same hash code, the hash table (or HashSet in this case) doesn't immediately 
        assume the items are equal. It then uses the Equals method to determine actual equality.

        Here's a step-by-step of what happens:

        The hash code of an item is computed using GetHashCode().
        The hash table uses this hash code to determine the "bucket" where the item should be placed or found.
        When inserting a new item:
        If there is no item in the bucket, the new item is inserted.
        If there's already an item in the bucket with the same hash code:
        The Equals method is used to determine if the two items are truly equal.
        If Equals returns true, then the new item is considered a duplicate and is not inserted.
        If Equals returns false, the two items, despite having the same hash code, are considered different. 
        The hash table then uses a method called "collision resolution" to find a new bucket for the item. 
        There are various ways to handle these collisions, but one common method is chaining, where items with the 
        same hash code are placed in a linked list associated with the bucket.

        For the given ListEqualityComparer:

        GetHashCode for both [1, 2, 3] and [3, 2, 1] will return the same value.
        However, Equals for these two lists will return false since they are not in the same order and SequenceEqual checks for order.
        So, if you have a HashSet with the custom comparer and you add [1, 2, 3], then when you try to add [3, 2, 1], 
        the HashSet will first see that their hash codes are the same, but then it will use the Equals method, see that they 
        are different, and both will exist in the HashSet due to collision resolution.

     * */

    public class ListEqualityComparer : IEqualityComparer<List<int>>
    {
        public bool Equals(List<int> x, List<int> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<int> obj)
        {
            int hashcode = 0;
            foreach (int t in obj)
            {
                hashcode ^= t.GetHashCode();
            }
            return hashcode;
        }
    }

    public class _10Subsets_01_Subsets
    {
        //method uses a recursive inclusion-exclusion approach. Starting from an empty set, for each element in the input, 
        //it creates new subsets by including the element and excludes it, growing the list of subsets as it proceeds.
        //Solution must sort and create a hash so that it doesnt add duplicates to the set
        public static List<List<int>> FindAllSubsets2(int[] input)
        {
            HashSet<List<int>> subsets = new HashSet<List<int>>(new ListEqualityComparer()) { new List<int> { } };

            //base case, empty set
            if (input.Length == 0)
                return subsets.ToList();

            Array.Sort(input);

            for (int i = 0; i < input.Length; ++i)
            {
                HashSet<List<int>> newSubsets = new HashSet<List<int>>();
                foreach (List<int> curSet in subsets)
                {
                    List<int> subset = new List<int>(curSet);
                    subset.Add(input[i]);
                    newSubsets.Add(subset);
                }
                subsets.UnionWith(newSubsets);
            }
            return subsets.ToList();
        }

        /*
         *          Faster Solution:
         *          Solution must sort and create a hash so that it doesnt add duplicates to the set

                    We can determine how many sets their will be by the length of the input
                    Understanding the Number of Subsets:

                    For a set of size n, there are 2^n possible subsets.This includes the empty set and the set itself.
                    The reason for this is that for each element in the set, you have two choices: include it in the subset 
                    or exclude it.Thus, the total number of combinations is 2×2×…×2(n times), which is 2^n.

                    Generating Subsets Using Bits:
                    Each subset can be represented as a binary string of length n, where a '1' at a particular position 
                    indicates the inclusion of the element at that position in the subset, and '0' indicates exclusion.
                    For example, for the set { 1,2,3}, the subset { 1,3} can be represented as the binary string 
                    '101'(where '1' in the first and third positions indicates the inclusion of the first and third elements, respectively).
                    By this logic, iterating from 0 to 2^(n−1) and representing each number in its binary form gives all 
                    possible combinations of subsets.

                    Loop and Bit Manipulation:

                    The outer loop runs from 0 to 2^(n-1)
                    For each number in this range, the inner loop(the while loop) checks each bit of the number. 
                    If the bit is '1', it adds the corresponding element from the set to the current subset.
                    Each subset is then added to the sets vector.

                    Suppose we have the set {1,2,3}.
                    Generating subsets using binary representation:
                    We will iterate from 0 to 7 (which is 2^(3-1)), and for each number, we will use its binary representation 
                    to determine the elements in the corresponding subset.

                    Number: 0
                    Binary: 000
                    Subset: {}

                    Number: 1
                    Binary: 001
                    Subset: {3}

                    Number: 2
                    Binary: 010
                    Subset: {2}

                    Number: 3
                    Binary: 011
                    Subset: {2, 3}

                    Number: 4
                    Binary: 100
                    Subset: {1}

                    Number: 5
                    Binary: 101
                    Subset: {1, 3}

                    Number: 6
                    Binary: 110
                    Subset: {1, 2}

                    Number: 7
                    Binary: 111
                    Subset: {1, 2, 3}
        */
        public static List<List<int>> FindAllSubsets(int[] input)
        {
            HashSet<List<int>> subsets = new HashSet<List<int>>(new ListEqualityComparer());

            Array.Sort(input);

            int numSubsets = (int)Math.Pow(2, input.Length); 
            for (int i = 0; i < numSubsets; ++i)
            {
                List<int> newSubset = new List<int>();
                int mask = 1;
                int bit = i;
                int count = 0;

                while(bit > 0)
                {
                   if((int)(bit & mask) == mask)
                        newSubset.Add(input[count]);
                    bit = bit >> 1;
                    count++;
                }

                subsets.Add(newSubset);
            }

            return subsets.ToList();
        }
        public static void Compute()
        {
            int[][] inputs = new int[][]
            {
                new int[]{ },
                new int[]{ 2, 5, 5 },
                new int[]{ 2, 7,2,2, 5, 7 },
                new int[]{ 1, 2, 3, 4 },
                new int[]{ 7, 3, 1, 5 } 
            };

            for (int i = 0; i < inputs.Length; i++)
            {
                Console.WriteLine( (i + 1) + ". Set:\t\t{" + string.Join(", " , inputs[i]) + "}" );
                List <List<int>> subsets = FindAllSubsets(inputs[i]);
                Console.Write("Subsets: \t{");
                foreach (List<int> subset in subsets)
                    Console.Write("{" + string.Join(", ", subset) + "}");
                Console.WriteLine("}");
                Console.WriteLine(new string('-', 100));
                subsets = FindAllSubsets2(inputs[i]);
                Console.Write("Subsets: \t{");
                foreach (List<int> subset in subsets)
                    Console.Write("{" + string.Join(", ", subset) + "}");
                Console.WriteLine("}");
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
