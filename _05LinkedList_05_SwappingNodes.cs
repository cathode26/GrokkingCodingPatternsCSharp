using System;

namespace EducativeGrokkingCodingPatterns
{
    /*
     *  Swapping Nodes in a Linked List
        Statement
        Given the linked list and an integer, k, 
        return the head of the linked list after swapping the values of the 
        kth node from the beginning and the kth node from the end of the linked list.

        1->2->3->4->5->6->7->8->9        kth = 6
                       k
        1->2->3->4->5->6->7->8->9
                                        count = 9
                        9 - 6 + 1 = 4
                        the 4th node is the 6th node from the end

        
        1->2->3->4->5->6->7->8->9
              A  B  C  D
        3->6
        5->4
        ----
        6->5
        4->7

        There are 3 conditions to consider when swapping these nodes
        The nodes might be next to each other, if they are next to each other you need to also consider the order
        this creates two conditions
        The 3rd condition is if the nodes are seperated by at least 1 node
    */



    public class _05LinkedList_05_SwappingNodes
    {
        public static void MoveToKthNode(ref LinkedListNode kthNode, ref LinkedListNode kthPrevNode, int kth)
        {
            int count = 1;
            while (count < kth)
            {
                kthPrevNode = kthNode;
                kthNode = kthNode.Next;
                count++;
            }
        }
        public static void SwapNodes(LinkedListNode kth, LinkedListNode kthPrev, LinkedListNode ith, LinkedListNode ithPrev)
        {
            if (kth.Next == ith)
            {
                LinkedListNode ithNext = ith.Next;
                kthPrev.Next = ith;
                ith.Next = kth;
                kth.Next = ithNext;
            }
            else if (ith.Next == kth)
            {
                LinkedListNode kthNext = kth.Next;
                ithPrev.Next = kth;
                kth.Next = ith;
                ith.Next = kthNext;
            }
            else
            {
                LinkedListNode kthNext = kth.Next;
                LinkedListNode ithNext = ith.Next;
                kthPrev.Next = ith;
                ithPrev.Next = kth;
                ith.Next = kthNext;
                kth.Next = ithNext;
            }
        }
        public static void SwapNodes(LinkedList linkedList, int kth)
        {
            //need to get the kth node from the head
            //need to get the kth node from the end
            LinkedListNode dummy = new LinkedListNode(-1);
            dummy.Next = linkedList.root;

            //Get to the kth node
            LinkedListNode kthFromBeginPrev = dummy;
            LinkedListNode kthFromBegin = linkedList.root;
            MoveToKthNode(ref kthFromBegin, ref kthFromBeginPrev, kth);

            LinkedListNode lastNode = kthFromBegin;
            int count = kth;
            //Count the total amount of nodes
            while (lastNode.Next != null)
            {
                lastNode = lastNode.Next;
                count++;
            }

            //Now that we know how many nodes we have, calculate the node to reach from the end of the list
            int kthFromEndCount = count - kth + 1;
            //Get the kth node from the end
            LinkedListNode kthFromEndPrev = dummy;
            LinkedListNode kthFromEnd = linkedList.root;
            MoveToKthNode(ref kthFromEnd, ref kthFromEndPrev, kthFromEndCount);
            //now swap the nodes
            if(kthFromBegin != kthFromEnd)
                SwapNodes(kthFromBegin, kthFromBeginPrev, kthFromEnd, kthFromEndPrev);

            //now update the root
            linkedList.root = dummy.Next;
        }
        public static void Compute()
        {
            //jagged array
            int[][] inputList = new int[][]{
                new int[]{1, 2, 3, 4, 5, 6, 7},
                new int[]{6, 9, 3, 10, 7, 4, 6},
                new int[]{6, 9, 3, 4},
                new int[]{6, 2, 3, 6, 9},
                new int[]{6, 2}
            };
            int[] k = new int[]{ 2, 3, 2, 3, 1 };
            for (int i = 0; i < inputList.Length; i++)
            {
                LinkedList inputLinkedList = new LinkedList();
                inputLinkedList.CreateLinkedList(inputList[i]);
                Console.Write(( i + 1) + ".\tOriginal linked list is: ");
                inputLinkedList.PrintListWithForwardArrowDots();
                Console.WriteLine("\n\tk: " + k[i]);
                if (k[i] <= 0)
                {
                    Console.WriteLine( "\tThe expected 'k' to have value from 1 to length of the linked list only." );
                }
                else
                {
                    SwapNodes(inputLinkedList, k[i]);
                    Console.Write( "\tLinked list with swapped values: ");
                    inputLinkedList.PrintListWithForwardArrowDots();
                }
                Console.WriteLine( new string('-', 96));
            }
        }
    }
}
