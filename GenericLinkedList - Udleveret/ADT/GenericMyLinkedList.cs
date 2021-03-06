﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADT
{
    public class MyLinkedList<T> : IEnumerable
    {

        private class MyLinkedListEnumerator : IEnumerator
        {
            private readonly Node _head;
            private Node _current;
            private int _countIndex;

            public MyLinkedListEnumerator(Node head)
            {
                _head = head;
                _countIndex = 0;
            }

            public bool MoveNext()
            {
                _current = _countIndex > 0 ? _current.Next : _head;
                _countIndex++;

                return _current != null;
            }

            public void Reset()
            {
                _countIndex = 0;
            }

            private T Current => _current.Data;
            object IEnumerator.Current => Current;
        }
        private class Node
        {
            public T Data { get; }
            public Node Next { get; set; }

            public Node(T data)
            {
                Data = data;
            }
        }

        private Node _head;

        public int Count { get; private set; }
        public T First => ItemAt(0);

        public T Last => ItemAt(Count - 1);

        /// <summary>
        /// The Insert(Object data, int index = 0) method inserts data as a node in the list
        /// at the position indicated by index. 
        /// The list is 0-indexed. 
        /// Default value of index is 0.
        /// If index is 0 or less, the data is inserted at the start of the list.
        /// If index is equal to Count or higher, the data is inserted at the end of the list.
        /// </summary>
        public void Insert(T data, int index = 0)
        {
            Node n = new Node(data);

            // Adjust index, if necessary
            if (index > Count)
                index = Count;

            if (Count == 0 || index < 1)
            {
                n.Next = _head;
                _head = n;
            }
            else
            {
                Node position = _head;
                for (int i = 0; i < index - 1; i++)
                {
                    position = position.Next;
                }
                n.Next = position.Next;
                position.Next = n;
            }

            Count++;
        }

        /// <summary>
        /// The Append(T data) method appends data at the end of the list.
        /// </summary>
        public void Append(T data)
        {
            Insert(data, Count);
        }

        /// <summary>
        /// The Delete(int index = 0) method deletes the node in the list at the position indicated by index. 
        /// The list is 0-indexed. 
        /// Default value of index is 0.
        /// </summary>
        public void Delete(int index = 0)
        {
            if (Count > 0)
            {
                // Adjust index, if necessary
                if (index > Count)
                    index = Count;

                if (index < 1)
                    _head = _head.Next;
                else
                {
                    Node position = _head;
                    for (int i = 0; i < index - 1; i++)
                    {
                        position = position.Next;
                    }
                    position.Next = position.Next.Next;
                }

                Count--;
            }
        }

        /// <summary>
        /// The ItemAt(int index) method returns the data from the list at the position indicated by index. 
        /// The list is 0-indexed. 
        /// </summary>
        public T ItemAt(int index)
        {
            T result = default(T);
            if (index < Count && index >= 0)
            {
                Node position = _head;
                for (int i = 0; i < index; i++)
                {
                    position = position.Next;
                }
                result = (T)position.Data;
            }
            return (T) result;
        }

        /// <summary>
        /// The ToString() method returns a string representation of the whole list by concatenating 
        /// all the ToString()-values of each data object in the list.
        /// </summary>
        public override string ToString()
        {
            string result = "";
            Node pointernode = _head;
            while (pointernode != null)
            {
                result = result + pointernode.Data.ToString() + "\n";

                pointernode = pointernode.Next;
            }
            return result;
        }

        public IEnumerator GetEnumerator()
        {
            return new MyLinkedListEnumerator(_head);
        }
    }
}
