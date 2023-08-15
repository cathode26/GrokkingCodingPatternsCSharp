using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
        Given the head of a singly linked list, return the middle node of the linked list. 
        If the number of nodes in the linked list is even, there will be two middle nodes, so return the second one.
     */

    class _02FastSlowPointer_03_MiddleOfLinkedList
    {
        //a->b->c->d
        //f
        //s
        //a->b->c->d
        //      f
        //   s
        //a->b->c->d
        //         f
        //      s

        /*
             a->b->c->d->e
             f
             s
             a->b->c->d->e
                   f
                s
             a->b->c->d->e
                         f
                   s
         * 
         * */

        
        static public LinkedListNode GetMiddleNode2(LinkedListNode root)
        {
            LinkedListNode slow = root;
            LinkedListNode fast = root;

            while(fast != null && fast.Next != null)
            {
                fast = fast.Next;
                fast = fast.Next;
                slow = slow.Next;
            }

            return slow;
        }
        
        //4:07pm    8/11/23
        static public LinkedListNode GetMiddleNode(LinkedListNode root)
        {
            LinkedListNode fast = root;
            LinkedListNode slow = root;

            while (fast != null && fast.Next != null)
            {
                fast = fast.Next;
                fast = fast.Next;
                slow = slow.Next;
            }
            return slow;
        }
        static public void Compute()
        {
            int[][] inputs = {
                new int[] {1, 2, 3, 4, 5},
                new int[] {1, 2, 3, 4, 5, 6},
                new int[] {3, 2, 1},
                new int[] {10},
                new int[] {1, 2}
              };


            for (int i = 0; i < inputs.Length; i++)
            {
                LinkedList linkedlist = new LinkedList();
                linkedlist.CreateLinkedList(inputs[i]);
                Console.WriteLine( i + 1 + ".\tInput:\t");
                linkedlist.PrintListWithForwardArrowDots();

                LinkedListNode middle = GetMiddleNode(linkedlist.root);
                Console.WriteLine("\tMiddle of the linked list: " + middle.Data);
                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
