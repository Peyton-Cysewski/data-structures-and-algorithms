﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedListLibrary
{
    public class LinkedList
    {
        public Node Head { get; set; }
        public Node Current { get; set; }

        public LinkedList()
        {
            Head = null;
            Current = Head;
        }

        /// <summary>
        /// Inserts a new node with an O(1) operation into linkedList
        /// </summary>
        /// <param name="value">value to be strored in the node</param>
        public void Insert(int value)
        {
            Current = Head;
            // create teh new node that needs to be added
            Node node = new Node(value);
            node.Next = Head;
            Head = node;
        }

        /// <summary>
        /// Finds a specific value in the linked list
        /// O(n) time efficiency
        /// </summary>
        /// <param name="value">searchable value</param>
        /// <returns>response if it exists</returns>
        public bool Includes(int value)
        {
            Current = Head;
            // While loop
            // traverse the linked list and do the comparison
            while (Current != null)
            {
                // check if it's equal to the given value
                if (Current.Value == value)
                {
                    return true;
                }

                // move to the next one
                Current = Current.Next;
            }

            return false;
        }

        /// <summary>
        /// Overriding current behavior of tostring method to output all values in the linked list as a string 
        /// </summary>
        /// <returns>a string containing all the values of the linked list</returns>
        public override string ToString()
        {
            Current = Head;
            // StringBuilder class. 
            // why would you use Stringbuilder over string concatination??

            StringBuilder sb = new StringBuilder();

            // start constructing sb
            while (Current != null)
            {
                sb.Append($"{Current.Value} -> ");
                Current = Current.Next;
            }

            sb.Append("NULL");

            return sb.ToString();
        }

        /// <summary>
        /// Appends a new node to the end of a linked list
        /// </summary>
        /// <param name="value">the value of the new node</param>
        public void Append(int value)
        {
            Current = Head;
            Node newNode = new Node(value);
            newNode.Next = null;
            Node last = Current;
            while (Current != null)
            {
                last = Current;
                Current = Current.Next;
            }
            last.Next = newNode;
        }

        /// <summary>
        /// Creates a node and inserts it directly before the desired value. If no value is found an exception is thrown.
        /// </summary>
        /// <param name="search">the value to insert the new node in front of</param>
        /// <param name="value">the value of the new node</param>
        public void InsertBefore(int search, int value)
        {
            Current = Head;
            Node newNode = new Node(value);
            Node last = Current;
            int counter = 0;
            while (Current.Value != search && Current != null)
            {
                last = Current;
                Current = Current.Next;
                counter++;
            }
            newNode.Next = Current;
            if (counter == 0)
            {
                Head = newNode;
            }
            else
            {
                last.Next = newNode;
            }
        }


        /// <summary>
        /// Creates a node and inserts it directly after the desired value. If no value is found an exception is thrown.
        /// </summary>
        /// <param name="search">The value to insert the new node after</param>
        /// <param name="value">The value of the new node</param>
        public void InsertAfter(int search, int value)
        {
            Current = Head;
            Node newNode = new Node(value);
            Node last = Current;
            int counter = 0;
            while (Current.Value != search && Current != null)
            {
                last = Current;
                Current = Current.Next;
                counter++;
            }
            newNode.Next = Current.Next;
            Current.Next = newNode;
        }

        /// <summary>
        /// Takes a value k and returns the value of the node that is k number nodes from the end. Argument is zero based.
        /// </summary>
        /// <param name="k">Targeted index of the node counting backwards from zero from the end of the list</param>
        /// <returns>Value of targeted node</returns>
        public int kthFromEnd(int k)
        {
            Current = Head;
            int counter = 0;
            while (Current != null)
            {
                Current = Current.Next;
                counter++;
            }
            int numFromStart = 0;
            if (k < 0 && Math.Abs(k) < counter + 1)
                numFromStart = Math.Abs(k);
            else if (k >= 0 && k < counter)
                numFromStart = counter - k;
            else
                throw new Exception("Reference is out of bounds of the length of the list.");
            Current = Head;
            counter = 1;
            while (counter < numFromStart)
            {
                Current = Current.Next;
                counter++;
            }
            return Current.Value;
        }
    }
}