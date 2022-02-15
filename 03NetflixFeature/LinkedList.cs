using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03NetflixFeature
{
    public class LinkedListNode
    {
        public int key;
        public int data;
        public LinkedListNode? next;
        public LinkedListNode? arbitraryPointer;

        public LinkedListNode(int data)
        {
            this.data = data;
            this.next = null;
        }

        public LinkedListNode(int key, int data)
        {
            this.key = key;
            this.data = data;
            this.next = null;
        }

        public LinkedListNode(int data, LinkedListNode next)
        {
            this.data = data;
            this.next = next;
        }

        public LinkedListNode(int data, LinkedListNode next, LinkedListNode arbitraryPointer)
        {
            this.data = data;
            this.next = next;
            this.arbitraryPointer = arbitraryPointer;
        }
    }

    public class LinkedList
    {
        public static LinkedListNode InsertAtHead(LinkedListNode head, int data)
        {
            LinkedListNode newNode = new(data);
            newNode.next = head;
            return newNode;
        }

        public static LinkedListNode InsertAtTail(LinkedListNode head, int data)
        {
            LinkedListNode newNode = new(data);
            if (head == null) return newNode;
            LinkedListNode temp = head;
            while (temp.next != null) temp = temp.next;
            temp.next = newNode;
            return head;
        }

        public static LinkedListNode InsertAtTail(LinkedListNode head, LinkedListNode node)
        {
            if (head == null) return node;
            LinkedListNode temp = head;
            while (temp.next != null)
            {
                temp = temp.next;
            }
            temp.next = node;
            return head;
        }

        public static LinkedListNode CreateLinkedList(List<int> lst)
        {
            LinkedListNode? head = null;
            LinkedListNode? tail = null;
            foreach(int num in lst)
            {
                LinkedListNode newNode = new(num);
                if (head == null) head = newNode;
                else tail.next = newNode;
                tail = newNode;
            }
            return head;
        }

        public static LinkedListNode CreateLinkedList(int[] arr)
        {
            LinkedListNode? head = null;
            LinkedListNode? tail = null;
            for (int i = 0; i < arr.Length; ++i)
            {
                LinkedListNode newNode = new(arr[i]);
                if (head == null) head = newNode;
                else tail.next = newNode;
                tail = newNode;
            }
            return head;
        }

        public static LinkedListNode CreateRandomList(int length)
        {
            LinkedListNode? listHead = null;
            Random gen = new();
            for (int i = 0; i < length; ++i) { listHead = InsertAtHead(listHead, gen.Next(100)); }
            return listHead;
        }

        public static List<int> ToList(LinkedListNode head)
        {
            List<int> lst = new();
            LinkedListNode temp = head;
            while (temp != null)
            {
                lst.Add(temp.data);
                temp = temp.next;
            }
            return lst;
        }

        public static void Display(LinkedListNode head)
        {
            LinkedListNode temp = head;
            while (temp != null)
            {
                Console.Write("{0}", temp.data);
                temp = temp.next;
                if (temp != null) Console.Write(", ");
            }
            Console.WriteLine("");
        }

        public static LinkedListNode MergeAlternating(LinkedListNode list1, LinkedListNode list2)
        {
            if (list1 == null) return list2;
            if (list2 == null) return list1;

            LinkedListNode head = list1;

            while (list1.next != null && list2 != null)
            {
                LinkedListNode temp = list2;
                list2 = list2.next;

                temp.next = list1.next;
                list1.next = temp;
                list1 = temp.next;
            }

            if (list1.next == null) list1.next = list2;
            return head;
        }

        static bool IsEqual(LinkedListNode list1, LinkedListNode list2)
        {
            if (list1 == list2) return true;
            while (list1 != null && list2 != null)
            {
                if (list1.data != list2.data) return false;
                list1 = list1.next;
                list2 = list2.next;
            }

            return list1 == list2;
        }
    }
}
