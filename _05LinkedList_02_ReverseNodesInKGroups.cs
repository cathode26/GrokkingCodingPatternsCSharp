using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
     * Reverse Nodes in k-Group
     * Statement:
        The task is to reverse the nodes in groups of k in a given linked list, where k
        is a positive integer, and at most the length of the linked list. If any remaining nodes 
        are not part of a group of k, they should remain in their original order.
        It is not allowed to change the values of the nodes in the linked list. 
        Only the order of the nodes can be modified.
    */
    internal class _05LinkedList_02_ReverseNodesInKGroups
    {
        public static void Reverse(LinkedListNode start, int k, LinkedListNode root)
        {
            LinkedListNode cur = start;
            LinkedListNode prev = null;
            int count = 0;
            while (count < k)
            {
                LinkedListNode next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
                count++;
            }

            //reconnect the beginning of the list
            if (root != null)
                root.Next = prev;
            //reconnect the end of the list
            start.Next = cur;
        }
        public static void ReverseKGroups(LinkedList inputLinkedList, int k)
        {
            LinkedListNode cur = inputLinkedList.root;
            LinkedListNode dummyNode = new LinkedListNode(-1);
            LinkedListNode prevGroupEnd = dummyNode;
            dummyNode.Next = cur;
            LinkedListNode groupBegin = inputLinkedList.root;

            int count = 0;
            while (cur != null)
            {
                count++;
                if (count == k)
                {
                    LinkedListNode nextGroup = cur.Next;
                    Reverse(groupBegin, k, prevGroupEnd);
                    prevGroupEnd = groupBegin;
                    count = 0;
                    cur = groupBegin;
                    groupBegin = nextGroup;
                }
                cur = cur.Next;
            }
            inputLinkedList.root = dummyNode.Next;
        }
        public static void Compute()
        {
            //Jagged Array
            int[][] inputList = new int[][]
            {
                new int[] {1, 2, 3, 4, 5, 6, 7, 8},
                new int[] {3, 4, 5, 6, 2, 8, 7, 7},
                new int[] {1, 2, 3, 4, 5},
                new int[] {1, 2, 3, 4, 5, 6, 7},
                new int[] {1}
            };

            int[] k = { 3, 2, 1, 7, 1 };

            for (int i = 0; i < inputList.Length; ++i)
            {
                LinkedList inputLinkedList = new LinkedList();
                inputLinkedList.CreateLinkedList(inputList[i]);

                Console.WriteLine( (i + 1) + ".\tLinked list: ");
                inputLinkedList.PrintListWithForwardArrowDots();

                Console.WriteLine( "\tReversed linked list with k:" + k[i] + " ");
                ReverseKGroups(inputLinkedList, k[i]);
                inputLinkedList.PrintListWithForwardArrowDots();
                Console.WriteLine( new string('-', 100));
            }
        }
    }
}
