using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class NodeEnumerator<T> : IEnumerator<T>
    {
        private Node<T> head;

        private Node<T> current;

        public NodeEnumerator(Node<T> head)
        {
            if(head == null)
            {
                throw new ArgumentNullException(nameof(head));
            }

            this.head = head;
        }

        public T Current => current.Value;

        object IEnumerator.Current => Current;

        public void Dispose()
        {
            
        }

        public bool MoveNext()
        {
            if(current == null)
            {
                current = head;
                return true;
            }
           
            if (current.Next != null)
            {
                current = current.Next;
                return true;
            }

            return false;
        }

        public void Reset()
        {
            current = head;
        }
    }
}
