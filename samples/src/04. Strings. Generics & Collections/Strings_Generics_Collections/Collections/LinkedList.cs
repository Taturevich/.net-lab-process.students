using System.Collections;
using System.Collections.Generic;

namespace Collections
{
    public class LinkedList<T> : IEnumerable<T>, ICollection<T>
    {
        private Node<T> head;

        private Node<T> current;

        public int Count { get; private set; }

        public bool IsReadOnly => false;

        public void Add(T item)
        {
            var newNode = new Node<T> { Value = item };
            if (head == null)
            {
                head = newNode;
                current = head;
            }
            else
            {
                current.Next = newNode;
                current = newNode;
            }

            Count++;
        }

        public bool Remove(T item)
        {
            Node<T> lastNode = null;
            Node<T> current = head;
            do
            {
                if (current.Value.Equals(item))
                {
                    if(head == current)
                    {
                        head = null;
                        Count--;
                        return true;
                    }

                    if (lastNode != null)
                    {
                        lastNode.Next = current.Next;
                    }

                    current = null;
                    Count--;
                    return true;
                }

                lastNode = current;
                current = current.Next;
            } while (current != null);

            return false;
        }

        public void Clear()
        {
            head = null;
            current = null;
        }
       
        public IEnumerator<T> GetEnumerator()
        {
            return new NodeEnumerator<T>(head);
        }
      
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Contains(T item)
        {
            foreach (var element in this)
            {
                if(element.Equals(item))
                {
                    return true;
                }
            }

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            if (array.Length >= arrayIndex && array.Length >= Count)
            {
                var index = arrayIndex;
                foreach (var item in this)
                {
                    array[index] = item;
                    index++;
                }
            }
        }
    }
}
