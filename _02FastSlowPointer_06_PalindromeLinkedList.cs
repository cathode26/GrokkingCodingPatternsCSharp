using System;

namespace EducativeGrokkingCodingPatterns
{

    /*
    
    *  A B C B A
       s
       f
       A B C B A
         s
           f
       A B C B A
           s   
               f

   ---------------------

       A B C C B A
       s
       f
       A B C C B A
         s
           f

       A B C C B A
           s   
               f

       A B C C B A
             s 
                 f  
   */

    /*
     * Statement
        Given the head of a linked list, your task is to check whether the linked list is a palindrome or not.Return TRUE if the linked list is a palindrome; otherwise, return FALSE.

    To solve this problem use fast and slow pointers.
    Move the fast and slow pointers and the slow pointer will be in the middle and the fast pointer will be at the end of the list
    Break the list in half before the slow pointer
    Reverse the list from the slow pointer to the fast pointer.
    Compare the two lists
    Restore the two lists

*/

    class _02FastSlowPointer_06_PalindromeLinkedList
    {
        //     A->B->C
        /*     prev = null
         *     A = cur
         *     next = A->next
         *     A->next = prev 
         *     cur = next
         * 
         */

        static public LinkedListNode ReverseLinkedList2(LinkedListNode root)
        {
            LinkedListNode prev = null;
            LinkedListNode cur = root;
            while(cur != null)
            {
                LinkedListNode next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
            }
            return prev;
        }
        static public bool Palindrome2(LinkedListNode root)
        {
            if (root == null || root.Next == null)
                return true;

            LinkedListNode endFirst = root;
            LinkedListNode slow = root;
            LinkedListNode fast = root;

            while(fast.Next != null)
            {
                endFirst = slow;
                slow = slow.Next;
                fast = fast.Next;
                //So we dont go past the end of the list
                if(fast.Next != null)
                    fast = fast.Next;
            }

            //now the fast node is at the end node and the slow node is in the center
            //Split the list in half
            endFirst.Next = null;

            //reverse the linked list
            LinkedListNode list2 = ReverseLinkedList(slow);
            LinkedListNode list1 = root;

            //Now compare the 2 lists and see if they match
            bool isPalindrome = true;
            while(list1 != null && list2 != null)
            {
                if (list1.Data != list2.Data)
                {
                    isPalindrome = false;
                    break;
                }
                list1 = list1.Next;
                list2 = list2.Next;
            }

            //reverse the reversed list
            ReverseLinkedList(fast);

            //reconnect the lists
            endFirst.Next = slow;

            return isPalindrome;
        }
        static public LinkedListNode ReverseLinkedList(LinkedListNode root)
        {
            //reverse the linked list
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
        
        //7:20 pm 8/11/23
        static public bool Palindrome(LinkedListNode root)
        {
            bool isPalindrome = false;

            LinkedListNode prev = root;
            LinkedListNode slow = root;
            LinkedListNode fast = root;

            //fast and slow pointer to find the middle with slow
            while (fast != null && fast.Next != null)
            {
                prev = slow;
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            //split the list
            prev.Next = null;

            LinkedListNode back = ReverseLinkedList(slow);
            slow = back;
            LinkedListNode front = root;

            while (back.Next != null && front.Next != null && back.Data == front.Data)
            {
                back = back.Next;
                front = front.Next;
            }

            if (back.Data == front.Data)
                isPalindrome = true;

            slow = ReverseLinkedList(slow);
            prev.Next = slow;

            return isPalindrome;
        }

        static public void Compute()
        {
            int[][] inputs = {
                new int[] {2, 4, 6, 4, 2},
                new int[] {0, 3, 5, 5, 0},
                new int[] {9, 7, 4, 4, 7, 9},
                new int[] {5, 4, 7, 9, 4, 5},
                new int[] {5, 9, 8, 3, 8, 9, 5}
              };


            for (int i = 0; i < inputs.Length; i++)
            {

                LinkedList linkedList = new LinkedList();
                linkedList.CreateLinkedList(inputs[i]);


                Console.WriteLine(i + 1 + ".\tLinked List:" );
                linkedList.PrintListWithForwardArrowDots();

                if (Palindrome(linkedList.root) == true)
                    Console.WriteLine("\tIs it a palindrome? Yes");
                else
                    Console.WriteLine("\tIs it a palindrome? No");


                Console.WriteLine("-------------------------------------------");
            }
        }
    }
}
