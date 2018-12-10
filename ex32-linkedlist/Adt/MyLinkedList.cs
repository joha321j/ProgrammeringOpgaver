using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Adt
{
    public class MyLinkedList
    {
        private Node Head { get; set; }
        private Node Tail { get; set; }
        public int Count { get; private set; }

        public void Insert(object objData)
        {
            Node nodeToInsert = new Node(objData);

            if (Head == null)
            {
                Head = nodeToInsert;
            }
            if (Tail != null)
            {
                Tail.Next = nodeToInsert;   
            }
            nodeToInsert.Previous = Tail;
            Tail = nodeToInsert;
            Count++;
        }

        public void Insert(object objData, int index)
        {
            if (index == Count) 
            {
                Insert(objData);
            }
            else if (index == 0)
            {
                InsertAtBeginning(objData);
            }
            else
            {
                Node nodeToInsert = new Node(objData);
                Node tempNode = Head;
                for (int i = 0; i < index - 1; i++)
                {
                    tempNode = tempNode.Next;
                }

                nodeToInsert.Next = tempNode.Next;
                nodeToInsert.Previous = tempNode;
                tempNode.Next = nodeToInsert;
                Count++;
            }
        }

        private void InsertAtBeginning(object objData)
        {
            Node nodeToInsert = new Node(objData);
            nodeToInsert.Next = Head;
            Head = nodeToInsert;
            Count++;

        }

        public void Delete()
        {
            Head = Head.Next;
            Count--;    
        }

        public void Delete(int index)
        {
            
            if (index == 0)
            {
                Delete();
            }
            else
            {
                Node tempNode = Head;
                for (int i = 0; i < index-1; i++)
                {
                    tempNode = tempNode.Next;
                }

                tempNode.Next = tempNode.Next.Next;
                Count--;
            }

        }

        public object ItemAt(int index)
        {
            Node returnNode = Head;
            for (int i = 0; i < index; i++)
            {
                returnNode = returnNode.Next;
            }

            return returnNode.Data;
        }

        public override string ToString()
        {
            string value = string.Empty;
            Node tempNode = Head;
            for (int i = 0; i < Count; i++)
            {
                value += tempNode.Data +"\n";
                tempNode = tempNode.Next;
            }

            return value;
        }

        public void Reverse()
        {
            Node tempNode = Head;
            for (int i = 0; i < Count - 1; i++)
            {
                Node tempNodeTwo = tempNode.Next;
                Node tempNodeThree = tempNodeTwo.Next;
                tempNodeTwo.Next = tempNodeTwo.Previous;
                tempNodeTwo.Previous = tempNodeThree;
                tempNode.Next = tempNodeThree;
                tempNode.Previous = tempNodeTwo;
            }

            Head = Tail;
            Tail = tempNode;
        }

        public void Swap(int i)
        {
            Node tempNode = Head;
            for (int j = 0; j < i; j++)
            {
                tempNode = tempNode.Next;
            }
            Node tempNodeTwo = tempNode.Next;

            object tempObj = tempNode.Data;
            tempNode.Data = tempNodeTwo.Data;
            tempNodeTwo.Data = tempObj;
        }

        class Node
        {
            internal Node Next { get; set; }
            internal Node Previous { get; set; }
            public object Data { get; set; }

            public Node(object objData)
            {
                Data = objData;
                Next = null;
                Previous = null;
            }
        }

        public string FremOgTilbage()
        {
            string resultString = ToString();
            Reverse();
            Node tempNode = Head;
            Delete();

            resultString += ToString();

            Insert(tempNode.Data, 0);

            Reverse();

            return resultString;
        }
    }
}
