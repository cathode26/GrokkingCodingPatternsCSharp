using System;

namespace EducativeGrokkingCodingPatterns
{

    /*
     *  Reverse Nodes in Even Length Groups
        Let's solve the Reverse Nodes in Even Length Groups problem using the In-place Reversal of a Linked List pattern.

        Statement
        Given the head of a linked list, the nodes in it are assigned to each group in a sequential manner. 
        The length of these groups follows the sequence of natural numbers. 
        Natural numbers are positive whole numbers denoted by 
        (1,2,3,4...).

        In other words:

        The 1st node is assigned to the first group.
        The 2nd and 3rd nodes are assigned to the second group.
        The 4th 5th, and 6th nodes are assigned to the third group, and so on.
        Your task is to reverse the nodes in each group with an even number of nodes and return the head of the modified linked list.
    */

    public class _05LinkedList_06_ReverseNodesEvenGroups
    {
        public static void ReverseKNodes(LinkedListNode start, LinkedListNode beforeStart, int count)
        {
            int curCount = 0;
            LinkedListNode cur = start;
            LinkedListNode prev = null;

            while (curCount < count)
            {
                LinkedListNode next = cur.Next;
                cur.Next = prev;
                prev = cur;
                cur = next;
                curCount++;
            }
            //reconnect the start 
            beforeStart.Next = prev;
            //reconnect the end
            start.Next = cur;
        }
        public static void ReverseEvenLengthGroups(LinkedList linkedList)
        {
            int group = 1;
            LinkedListNode cur = linkedList.root;
            LinkedListNode prevGroupEnd = null;
            while (cur != null && cur.Next != null)
            {
                int nodeCount = 1;
                while (nodeCount < group && cur.Next != null)
                {
                    nodeCount++;
                    cur = cur.Next;
                }

                //this is the beginning of the group, when it is reversed it will become the end of the group

                if (nodeCount % 2 == 0)
                {
                    LinkedListNode nextGroupEnd = prevGroupEnd.Next;
                    ReverseKNodes(prevGroupEnd.Next, prevGroupEnd, nodeCount);
                    prevGroupEnd = nextGroupEnd;
                    cur = prevGroupEnd.Next;
                }
                else
                {
                    prevGroupEnd = cur;
                    cur = cur.Next;
                }
                group++;
            }
        }
        public static void Compute()
        {
            int[][] inputList = new int[][]
            {
                new int[]{1, 2, 3, 4},
                new int[]{10, 11, 12, 13, 14},
                new int[]{15},
                new int[]{16, 17},
                new int[]{16, 17,18,19,20,21,22,23,24,25},
                new int[]{16, 17,18,19,20,21,22,23},
                new int[]{16, 17,18,19,20,21,22,23,24}

            };

            for (int i = 0; i < inputList.Length; i++)
            {
                LinkedList inputLinkedList = new LinkedList();
                inputLinkedList.CreateLinkedList(inputList[i]);
                Console.Write((i + 1) + ".\tIf we reverse the even length groups of the linked list:\t");
                inputLinkedList.PrintListWithForwardArrowDots();
                ReverseEvenLengthGroups(inputLinkedList);
                Console.Write("\n\n\twe will get:\t");
                inputLinkedList.PrintListWithForwardArrowDots();
                Console.WriteLine(new string('-', 100));
            }

        }
    }
}
