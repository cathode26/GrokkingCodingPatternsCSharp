using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
        An input array, nums containing non-zero integers, is given, where the value at each index represents the number of places to skip forward 
        (if the value is positive) or backward (if the value is negative). When skipping forward or backward, wrap around if you reach either end of the array. 
        For this reason, we are calling it a circular array. Determine if this circular array has a cycle. A cycle is a sequence of indices in the circular array 
        characterized by the following:

        The same set of indices is repeated when the sequence is traversed in accordance with the aforementioned rules.
        The length of the sequence is at least two.
        The loop must be in a single direction, forward or backward.
        It should be noted that a cycle in the array does not have to originate at the beginning. A cycle can begin from any point in the array.
     */

    class _02FastSlowPointer_04_CircularArrayLoop
    {
        
        static public bool CalculateNextPosition2(int[] array, ref int curr)
        {
            int next = (curr + array[curr]);
            if (next >= array.Length)
                next = next % array.Length;
            else if (next < 0)
                next = array.Length + next;

            bool success = (Isforward2(array, curr) == Isforward2(array, next)) && curr != next;
            curr = next;
            return success;
        }
        static public bool Isforward2(int[] array, int position)
        {
            return array[position] > 0;
        }
        static public bool CircularArrayLoop2(int[] array)
        {
            for(int i=0; i<array.Length; ++i)
            {
                int slow = i;
                int fast = i;

                do
                {
                    if (!CalculateNextPosition2(array, ref fast) || !CalculateNextPosition2(array, ref fast))
                        goto noCycle;
                    if (CalculateNextPosition2(array, ref slow) == false)
                        goto noCycle;
                } while (fast != slow);

                if (fast == slow)
                    return true;
                noCycle:;
            }
            return false;
        }
        

        //8/11/23 4:45pm
        static public bool CalculateNextPosition(int[] input, ref int index, bool direction)
        {
            if (IsForward(input[index]) != direction)
                return false;

            index += input[index];
            if (direction == false)
            {
                while (index < 0)
                    index += input.Length;
            }
            else
            {
                index = index % input.Length;
            }

            return true;
        }

        static public bool IsForward(int value)
        {
            if (value > 0)
                return true;
            else
                return false;
        }
        static public bool CircularArrayLoop(int[] input)
        {
            //the loop sequence length must be at least 2
            //The direction must just be 1 direction
            for (int i = 0; i < input.Length; ++i)
            {
                bool isForward = IsForward(input[i]);
                int fast = i;
                int slow = i;
                do
                {
                    if (CalculateNextPosition(input, ref fast, isForward) == false)
                        break;
                    if (CalculateNextPosition(input, ref fast, isForward) == false)
                        break;
                    if (CalculateNextPosition(input, ref slow, isForward) == false)
                        break;
                } while (fast != slow);

                if (fast == slow)
                {
                    CalculateNextPosition(input, ref fast, isForward);
                    if (fast != slow)
                        return true;
                }
            }

            return false;
        }
        static public string ArrayToString(int[] array)
        {
            string output = "";
            foreach (int ele in array)
                output = output + ele.ToString() + " ";
            return output;
        }
        static public void Compute()
        {
            int[][] inputs = {
                new int[] {-1, -1, -1},
                new int[] {-5, -4, -3, -2, -1},
                new int[] {-5, -5, -5, -5, -5},
                new int[] {-1, -2, -3, -4, -5},
                new int[] {2, 1, -1, -2},
                new int[] {-1, -2, -3, -4, -5, 6},
                new int[] {1, 2, -3, 3, 4, 7, 1}
              };


            for (int i = 0; i < inputs.Length; i++)
            {
                Console.WriteLine(i + 1 + ".\tGiven arr: " + ArrayToString(inputs[i]) );
                
                bool res = CircularArrayLoop(inputs[i]);

                Console.WriteLine("\tFound loop: " + res.ToString());
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
