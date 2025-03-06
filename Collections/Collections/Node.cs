using System.Collections;
using System.Xml.Linq;

namespace Collections
{
    internal partial class Program
    {
        private class DoubleNode<T>
        {
            public DoubleNode(T data)
            {
               Data = data;
            }

            public T Data { get; set;}

            public DoubleNode<T> prevElement;
            public DoubleNode<T> nextElement;

        }
        public class DoubleLinkedNode<T> : IEnumerable<T>
        {
            DoubleNode<T> head;
            DoubleNode<T> tail;
            int countElem;

            public void Add(T data)
            {
                DoubleNode<T> node = new DoubleNode<T>(data);

                if (head == null)
                {
                    head = node;
                }
                else
                {
                    tail.nextElement = node;
                    node.prevElement = tail;
                }
                tail = node;
                countElem++;
            }

            public void AddFirst(T data)
            {
                DoubleNode<T> node = new DoubleNode<T>(data);
                DoubleNode<T> temp = head;
                node.nextElement = temp;
                head = node;

                if (countElem == 0)
                    head = tail;
                else
                    temp.prevElement = node;
                countElem++;
            }
            public bool Remove(T data)
            {
                DoubleNode<T> current = head;

                while (current != null)
                {
                    if (current.Data.Equals(data))
                    {
                        break;
                    }
                    current = current.nextElement;
                }

                if (current != null)
                {
                    if (current.prevElement != null) // Если элемент не первый
                    {
                        current.prevElement.nextElement = current.nextElement;
                    }
                    else
                    {
                        head = current.nextElement; // если первый, то запихиваем его в head
                    }
                    if (current.nextElement != null) // Если элемент не последний
                    {
                        current.nextElement.prevElement = current.prevElement;
                    }
                    else
                    {
                        tail = current.prevElement; // если последний, то запихиваем его в tail
                    }
                }
                countElem--;

                return true;
            }
            public void Display()
            {
                DoubleNode<T> current = head;
                while (current != null)
                {
                    Console.Write(current.Data + " <-> ");
                    current = current.nextElement;
                }
                Console.WriteLine("NULL");
            }

            public int Count { get { return countElem; } }
            public bool IsEmpty { get { return countElem == 0; } }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return ((IEnumerable)this).GetEnumerator();
            }

            IEnumerator<T> IEnumerable<T>.GetEnumerator()
            {
                DoubleNode<T> current = head;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.nextElement;
                }
            }

            public IEnumerable<T> BackEnumerator()
            {
                DoubleNode<T> current = tail;
                while (current != null)
                {
                    yield return current.Data;
                    current = current.prevElement;
                }
            }
        }
    }
}
