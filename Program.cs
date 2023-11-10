using System;

namespace method4
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
            Previous = null;
            Next = null;
        }
        public T Data { get; }
        public DoublyNode<T> Previous;
        public DoublyNode<T> Next;
    }
    public class Deque<T>
    {
        DoublyNode<T> head;
        DoublyNode<T> tail;
        public DoublyNode<T> curr;
        public Deque(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            head = node;
            tail = node;
        }
        public void AddLast(T input)
        {
            DoublyNode<T> node = new DoublyNode<T>(input);
            node.Previous = tail;
            tail.Next = node;
            tail = node;
        }
        public void AddFirst(T input)
        {
            DoublyNode<T> node = new DoublyNode<T>(input);
            node.Next = head;
            head.Previous = node;
            head = node;
        }
        public void RemoveLast()
        {
            tail.Previous.Next = null;
            tail = tail.Previous;

        }
        public void RemoveFirst()
        {
            head.Next.Previous = null;
            head = head.Next;

        }
        public void Print()
        {
            if (head == null)
            {
                Console.WriteLine("Empty!");
                return;
            }
            curr = head;
            while (curr != null)
            {
                Console.Write(curr.Data.ToString() + " ");
                curr = curr.Next;
            }
        }
        public object Find(T find)
        {
            curr = head;
            int count = 1;
            while (curr != null)
            {
                if (curr.Data.Equals(find))
                {
                    break;
                }
                count++;
                curr = curr.Next;
            }
            return count;
        }
        public void Remove(int remove)
        {
            int sz = 0;
            curr = head;
            while (curr != null)
            {
                sz++;
                curr = curr.Next;
            }
            if (remove == 1)
            {
                RemoveFirst();
            }
            else if (remove == sz)
            {
                RemoveLast();
            }
            else
            {
                int count = 1;
                curr = head;
                while (curr != null && count != remove)
                {
                    curr = curr.Next;
                    count++;
                }
                curr.Previous.Next = curr.Next;
                curr.Next.Previous = curr.Previous;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Deque<int> deque = new Deque<int>(5);
            deque.AddFirst(4);
            deque.AddFirst(3);
            deque.AddLast(2);
            deque.AddLast(1);
            deque.Print(); Console.WriteLine();
            Console.WriteLine(deque.Find(4));
            deque.RemoveFirst();
            deque.RemoveLast();
            Console.WriteLine();
            deque.Print(); Console.WriteLine();
            deque.Remove(1);
            deque.Print();
        }
    }
}
