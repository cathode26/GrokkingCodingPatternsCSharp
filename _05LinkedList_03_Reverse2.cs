using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Reverse Linked List II
     * Statement
        Given a singly linked list with n nodes and two positions, left and right, 
        the objective is to reverse the nodes of the list from left to right. Return the modified list.
    */

    public class _05LinkedList_03_Reverse2
    {
        public static void ReverseSegment(LinkedListNode left, int k, LinkedListNode root)
        {
            LinkedListNode prev = null;
            LinkedListNode cur = left;
            int count = 0;
            while (count < k)
            {
                LinkedListNode next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
                count++; 
            }
            //reconnect the root
            root.Next = prev;
            //reconnect to the end of the list
            left.Next = cur;
        }
        public static void ReverseFromLeftToRight(LinkedList linkedList, int left, int right)
        {
            LinkedListNode dummy = new LinkedListNode(-1);
            dummy.Next = linkedList.root;
            LinkedListNode cur = linkedList.root;
            LinkedListNode prev = dummy;

            int curIndex = 1;

            while (curIndex < left)
            {
                prev = cur;
                cur = cur.Next;
                curIndex++;
            }

            ReverseSegment(cur, right - left + 1, prev);

            // reconnect the list
            linkedList.root = dummy.Next;
        }

        public static void Compute()
        {
            //jagged array
            int[][] inputList = { 
                new int[] {1, 2, 3, 4, 5, 6, 7},
                new int[] {6, 9, 3, 10, 7, 4, 6},
                new int[] {6, 9, 3, 4},
                new int[] {6, 2, 3, 6, 9},
                new int[] {6, 2}
            };
            int[] left = { 1, 3, 2, 1, 1 };
            int[] right = { 5, 6, 4, 3, 2 };

            for (int i = 0; i < inputList.Length; i++)
            {
                LinkedList inputLinkedList = new LinkedList();
                inputLinkedList.CreateLinkedList(inputList[i]);
                Console.Write( (i + 1) + ".\tOriginal linked list is: ");
                inputLinkedList.PrintListWithForwardArrowDots();
                if (left[i] <= 0)
                {
                    Console.WriteLine( "\n\tThe expected 'left' and 'right' to have value from 1 to length of the linked list only.\n");
                }
                else
                {
                    ReverseFromLeftToRight(inputLinkedList, left[i], right[i]);
                    Console.Write( "\n\tReversed linked list from left:" + left[i] + " to right:" + right[i] + " is: ");
                    inputLinkedList.PrintListWithForwardArrowDots();
                }
                Console.WriteLine(new string('-', 96));
            }
        }
    }
}
