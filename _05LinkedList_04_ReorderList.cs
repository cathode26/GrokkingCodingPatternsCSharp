using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
     *  Statement
        Given the head of a singly linked list, 
        reorder the list as if it were folded on itself. 
        For example, if the list is represented as follows:
        L(0) → L(1) → L(2) → … → L(n−2) → L(n−1) → L(n)
​
        This is how you’ll reorder it:
        L(0) → L(n) → L(1) → L(n−1) → L(2) → L(n−2) → …

        You don’t need to modify the values in the list’s nodes; 
        only the links between nodes need to be changed.
    
        1->2->3->4->5
        s  f
           s     f
              s       f

        1->2->3
        4->5
        -------
        1->2->3
        4->5
        -------
        1->4->2->5->3

        1->2->3->4->5->6
        s  
           f
           s     f
              s        f
                 s        f        
        1->2->3
        4->5->6
        -------
        1->2->3
        6->5->4
        -------
        1->6->2->5->4->4
     */

    internal class _05LinkedList_04_ReorderList
    {
        public static LinkedListNode Reverse(LinkedListNode root)
        {
            LinkedListNode cur = root;
            LinkedListNode prev = null;
            while (cur != null)
            {
                LinkedListNode next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
            }
            return prev;
        }
        public static void ReorderList(LinkedList linkedList)
        {
            //lets use a fast,slow, two pointer apporach to find the middle of the list
            LinkedListNode slow = linkedList.root;
            LinkedListNode fast = linkedList.root;
            
            while (fast != null && fast.Next != null)
            {
                fast = fast.Next.Next;
                slow = slow.Next;
            }
            //slow is now in the middle
            //reverse all the nodes from slow until the end
            LinkedListNode lastHalfReversed = Reverse(slow.Next);
            if (lastHalfReversed == null)
                return;
            //cut the list in half
            slow.Next = null;
            LinkedListNode cur = linkedList.root;
            while (cur != null && lastHalfReversed != null)
            {
                LinkedListNode nextFirstHalf = cur.Next;
                LinkedListNode nextLastHalf = lastHalfReversed.Next;
                cur.Next = lastHalfReversed;
                lastHalfReversed.Next = nextFirstHalf;
                cur = nextFirstHalf;
                lastHalfReversed = nextLastHalf;
            }
        }
        public static void Compute()
        {
            //jagged array
            int[][] inputList = new int[][]{
                new int[]{1},
                new int[]{10, 20, -22, 21, -12},
                new int[]{1, 1, 1},
                new int[]{-2, -5, -6, -1, -4},
                new int[]{3, 1, 5, 7, -4, -2, -1, -6}
            };

            for (int i = 0; i < inputList.Length; i++)
            {
                LinkedList inputLinkedList = new LinkedList();
                inputLinkedList.CreateLinkedList(inputList[i]);
                Console.Write( (i + 1) + ".\tOriginal list: ");
                inputLinkedList.PrintListWithForwardArrowDots();
                ReorderList(inputLinkedList);
                Console.Write("\n\tAfter folding: ");
                inputLinkedList.PrintListWithForwardArrowDots();
                Console.WriteLine(new string('-', 100));
            }
        }
    }
}
