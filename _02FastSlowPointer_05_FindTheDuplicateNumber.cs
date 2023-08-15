using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * 
    Loop with a fast and slow pointer until the pointers find each other.
     
    now that they have found each other, we know that the distance from the start of the list
    to the start of the cycle happens to be the same distance from the fast pointer to the 
    start of the cycle.

    What this means is that if we move the fast pointer n elements in sync with a pointer that starts
    at the begining of the list, they will eventually be equal, and when they are equal we have 
    found the start of the cycle, which is the duplicate in the list.

    Why is this true?
    This is true because of the properties of a cycle. If we have 2 pointers looping through a cycle and 
    1 is a slow pointer and the other is a fast pointer. Then the slow pointer will travel 1 cycle, and the
    fast pointer will travel N cycles, this at a minimum will be 2 cycles. 
    When we have this base case where the fast pointer travels 2 cycles,
    it means that node which is the start of the cycle (duplicate) 
    and where the pointers meet will be the same node.

    Now that we know this base case, add 1 element to the beginning of the list that is not part of the cycle,
    By doing this, the position where they meet will be offset by 1, you can extrapolate this to n,
    so as we add n nodes to the front of the cycle, the meeting position is offset by n nodes. 

    What this also tells us is that there is n nodes that the fast pointer must travel to reach the 
    cycles entrance. The cycles entrance is also the duplicate node in the list.

    So since there are n nodes in front of the cycle, and n nodes from the fast pointer, just loop through each 
    at the same speed until they meet.
*/

    class _02FastSlowPointer_05_FindTheDuplicateNumber
    {
        static public int FindDuplicate2(int[] array)
        {
            int slow = array[0];
            int fast = array[0];

            do
            {
                slow = array[slow];
                fast = array[fast];
                fast = array[fast];
            } while (array[slow] != array[fast]);

            //now that they have met, we can find where the cycle begins, which is also the duplicate number

            slow = array[0];
            while(slow != fast)
            {
                slow = array[slow];
                fast = array[fast];
            }
            return fast;
        }
        static public string ArrayToString(int[] array)
        {
            string output = "";
            foreach (int ele in array)
                output = output + ele.ToString() + " ";
            return output;
        }

        //8/11/23 5:35pm
        static public int FindDuplicate(int[] array)
        {
            int fast = array[0];
            int slow = array[0];
            do
            {
                fast = array[fast];
                fast = array[fast];
                slow = array[slow];
            }
            while (fast != slow);

            slow = array[0];
            while (slow != fast)
            {
                fast = array[fast];
                slow = array[slow];
            }

            return fast;
        }

        static public void Compute()
        {
            int[][] inputs = {
                new int[] {1, 3, 2, 3, 5, 4},
                new int[] {2, 4, 5, 4, 1, 3},
                new int[] {1, 6, 3, 5, 1, 2, 7, 4},
                new int[] {1, 2, 2, 4, 3},
                new int[] {3, 1, 3, 5, 6, 4, 2}
              };


            for (int i = 0; i < inputs.Length; i++)
            {
                string input = "";
                foreach (int x in inputs[i])
                {
                    input += x.ToString() + ", ";
                }
                input = input.Substring(0, input.Length - 2);
                Console.WriteLine(i + 1 + ".\tnums: [" + input + "]" );

                Console.WriteLine("\tDuplicate Number: " + FindDuplicate(inputs[i]));
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
