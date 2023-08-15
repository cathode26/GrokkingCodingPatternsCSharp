﻿using System;
using System.Collections.Generic;

namespace EducativeGrokkingCodingPatterns
{
    public class LinkedList
    {
        List<LinkedListNode> list = new List<LinkedListNode>();
        public LinkedListNode root = null;
        public void CreateLinkedList(int[] data)
        {
            for (int i = data.Length - 1; i >= 0; --i)
            {
                LinkedListNode cur = new LinkedListNode(data[i]);
                if (root == null)
                {
                    root = cur;
                }
                else
                {
                    cur.Next = root;
                    root = cur;
                }
                list.Insert(0, root);
            }
        }
        public void PrintListWithForwardArrowDots()
        {
            for (int i = 0; i < list.Count; ++i)
            {
                Console.Write(list[i].Data + " ");
                if (i < list.Count - 1)
                {
                    Console.Write(" →  ");
                }
                else
                {
                    Console.Write(" →  NULL");
                }
            }
            Console.WriteLine();
        }
        public int GetLength()
        {
            return list.Count;
        }
        public LinkedListNode GetNode(int pos)
        {
            LinkedListNode cur = root;
            int p = 0;
            while (cur.Next != null && p < pos)
            {
                p++;
                cur = cur.Next;
            }
            return cur;
        }
    }
    public class LinkedListNode
    {
        public int Data { get; set; }
        public LinkedListNode Next { get; set; }

        public LinkedListNode(int data)
        {
            Data = data;
        }
    }
}
