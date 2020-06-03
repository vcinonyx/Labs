using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{

    public class DLinkedList
    {
        Node Head;
        Node Tail;
    
        public int Count { get; private set; }

        public void Add(double data)
        {
            Node node = new Node(data);

            if (Head == null)
                Head = node;
            
            else
            {
                Tail.Next = node;
                node.Previous = Tail;
            }
            Tail = node;
            Count++;
        }


        public void AddFirst(double data)
        {
            Node node = new Node(data);
            Node temp = Head;
            node.Next = temp;
            Head = node;
            if (Count == 0)
                Tail = Head;
            else
                temp.Previous = node;
            Count++;
        }


        public void Clear()
        {
            Head = null;
            Tail = null;
            Count = 0;
        }
        
        
        public bool Delete(double data)
        {
            Node current = Head;

            while (current != null)
            {
                if (current.Data.Equals(data))
                    break;
                current = current.Next;
            }



            if (current != null)
            {
                if (current.Next != null)
                {
                    current.Next.Previous = current.Previous; 
                }

                else
                {
                    Tail = current.Previous;
                }

                if (current.Previous != null)
                {
                    current.Previous.Next = current.Next;
                }

                else
                {
                    Head = current.Next;
                }
                
                Count--;
                return true;
            }

            return false;
        }


        public void DeleteNodesAfterMax()
        {
            
            Node max = FindMaxNode();
            Node current = Head;

            while (current != max)
            {
                current = current.Next;
            }

            current = current.Next;
            
            while (current != null)
            {
                Delete(current.Data);
                current = current.Next;
            }
        }


        public IEnumerator GetEnumerator()
        {
            Node current = Head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }


        public IEnumerable BackEnumerator()
        {
            Node current = Tail;
            while (current != null)
            {
                yield return current.Data;
                current = current.Previous;
            }
        }


        public double Sum()
        {
            Node current = Head;
            double sum = 0d;
            
            while (current != null)
            {
                sum += current.Data;
                current = current.Next;
            }
            return sum;
        }
        

        public int LessThanAvg()
        {
            Node current = Head;
            int counter = 0;
            double data;
            double sum = Sum();
            double avg = sum / Count;

            while (current != null)
            {
                data = current.Data;

                if (data < avg) counter++;
                current = current.Next;
            }

            return counter;
        }

        public double FindMax()
        {
            return FindMaxNode().Data;
        }


        private Node FindMaxNode()
        {
            Node current = Head;
            Node max = current;
            
            while (current != null)
            {
                if (max.Data <= current.Data)   max = current;
                current = current.Next;
            }

            return max;
        }



        private class Node
        {
            public double Data { get; set; }
            public Node Previous { get; set; }
            public Node Next { get; set; }

            public Node(double data)
            {
                Data = data;
            }
        }

    }

}