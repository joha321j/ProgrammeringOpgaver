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
        public int Count { get; private set; }

        public void Insert(object objData)
        {
            Node nodeToInsert = new Node(objData);
            nodeToInsert.Next = Head;
            Head = nodeToInsert;
            Count++;
        }

        public void Insert(object objData, int index)
        {
            if (index == 0) 
            {
                Insert(objData);
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
                tempNode.Next = nodeToInsert;
                Count++;
            }
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
            string value = String.Empty;
            Node tempNode = Head;
            for (int i = 0; i < Count; i++)
            {
                value += tempNode.Data.ToString() +"\n";
                tempNode = tempNode.Next;
            }

            return value;
        }

        class Node
        {
            public Node Next { get; set; }
            public object Data { get; }

            public Node(object objData)
            {
                Data = objData;
                Next = null;
            }
        }

    }


}
