using System;

namespace EducativeGrokkingCodingPatterns
{
    public class _05LinkedList_07_SwapNodesInPairs
    {
        /*
         *  Swap Nodes in Pairs
         *  Statement
            Given a singly linked list, swap every two adjacent nodes of the linked list. 
            After the swap, return the head of the linked list.
        */

        public static void SwapNodesInPairs(LinkedList linkedList)
        {
            LinkedListNode dummy = new LinkedListNode(-1);
            LinkedListNode prevGroup = dummy;
            LinkedListNode cur = linkedList.root;

            while (cur != null && cur.Next != null)
            {
                LinkedListNode next = cur.Next.Next;
                prevGroup.Next = cur.Next;
                prevGroup.Next.Next = cur;
                cur.Next = next;
                prevGroup = prevGroup.Next.Next;
                cur = prevGroup.Next;
            }

            linkedList.root = dummy.Next;
        }
        public static void Compute()
        {
            //Jagged Array
            int[][] inputList = new int[][]
            {
                new int[] {1, 2, 3, 4 },
                new int[] {10, 1, 2, 3, 4, 5 },
                new int[] {28, 21, 14, 7 },
                new int[] {11, 12, 13, 14, 15 },
                new int[] {1, 2 }
            };

            for (int i = 0; i < inputList.Length; ++i)
            {
                LinkedList linkedList = new LinkedList();
                linkedList.CreateLinkedList(inputList[i]);
                Console.WriteLine("Swap Nodes in Pairs of 2");
                Console.Write("Input \t");
                linkedList.PrintListWithForwardArrowDots();
                SwapNodesInPairs(linkedList);
                Console.Write("Output \t");
                linkedList.PrintListWithForwardArrowDots();
            }
        }
    }
}
