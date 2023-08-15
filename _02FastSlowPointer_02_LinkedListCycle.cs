using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    /*
        Check whether or not a linked list contains a cycle. If a cycle exists, return TRUE. 
        Otherwise, return FALSE. The cycle means that at least one node can be reached again by traversing the next pointer.
     */

    class _02FastSlowPointer_02_LinkedListCycle
    {
         static public bool DetectCycle2(LinkedListNode root)
         {
            LinkedListNode slow = root;
            LinkedListNode fast = root;

            do
            {
                if(fast != null)
                    fast = fast.Next;
                if(fast != null)
                    fast = fast.Next;
                if (slow != null)
                    slow = slow.Next;
            } while (fast != null && slow != fast);

            if (fast == null)
                return false;
            else
                return true;
         }

        //8/11/23 3:55pm
        static public bool DetectCycle(LinkedListNode root)
        {
            if (root == null || root.Next == null)
                return false;

            LinkedListNode fast = root;
            LinkedListNode slow = root;

            do
            {
                fast = fast.Next;
                fast = fast.Next;
                slow = slow.Next;
            } while (fast != null && fast.Next != null && fast != slow);

            if (fast == null || fast.Next == null)
                return false;
            else
                return true;
        }

        static public void Compute()
        {
            int[][] inputs = {
                new int[] {2, 4, 6, 8, 10, 12},
                new int[] {1, 3, 5, 7, 9, 11, 13},
                new int[] {0, 1, 2, 3, 4, 6},
                new int[] {3, 4, 7, 9, 11, 17},
                new int[] {5, 1, 4, 9, 2, 3}
              };

            int[] pos = new int[]{ 0, -1, 1, -1, 2 };

            for (int i = 0; i < inputs.Length; i++)
            {
                LinkedList linkedlist = new LinkedList();
                linkedlist.CreateLinkedList(inputs[i]);
                Console.WriteLine( i + 1 + ".\tInput:\t");
                linkedlist.PrintListWithForwardArrowDots();

                //now maybe corrupt the list, if the pos is -1, dont corrupt the list
                if (pos[i] != -1)
                {
                    int length = linkedlist.GetLength();
                    LinkedListNode lastNode = linkedlist.GetNode(length - 1);
                    lastNode.Next = linkedlist.GetNode(pos[i]);
                }
                Console.WriteLine("\tProcessing...");
                bool cycle = DetectCycle(linkedlist.root);
                Console.WriteLine("\tDetected cyle: " + cycle.ToString() );
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
