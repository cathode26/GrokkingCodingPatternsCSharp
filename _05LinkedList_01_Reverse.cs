using System;

/*
 * 
 * Reverse Linked List
    Statement
    Given the head of a singly linked list, reverse the linked list and return its updated head.

    Constraints:

    Let n be the number of nodes in a linked list.

    1 ≤ n ≤ 500

    −5000 ≤ Node.value ≤ 5000
*/

namespace EducativeGrokkingCodingPatterns
{
    public class _05LinkedList_01_Reverse
    {
        public static void Reverse(LinkedList linkedList)
        {
            LinkedListNode cur = linkedList.root;
            LinkedListNode prev = null;
            while (cur != null)
            {
                LinkedListNode next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
            }
            linkedList.root = prev;
        }

        public static void Compute()
        {
            //Jagged Array  (not rectangular)
            int[][] input = new int[][]{
                new int[] {1, 2, 3, 4, 5},
                new int[] {1, 2, 3, 4, 5, 6},
                new int[] {3, 2, 1},
                new int[] {10},
                new int[] {1, 2}
            };

            for (int i = 0; i < input.Length; i++)
            {
                LinkedList inputLinkedList = new LinkedList();
                inputLinkedList.CreateLinkedList(input[i]);
                Console.Write((i + 1) + ".\tInput linked list: ");
                inputLinkedList.PrintListWithForwardArrowDots();
                Console.Write("\n\tReversed linked list: ");
                Reverse(inputLinkedList);
                inputLinkedList.PrintListWithForwardArrowDots();
                Console.WriteLine(new string('-', 100)); ;
            }
        }
    }
}
