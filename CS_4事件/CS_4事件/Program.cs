using System;

namespace CS_5事件
{
    public class List<T>
    {
        T[] items;
        int count;
        const int defaultCapacity = 4;

        public event EventHandler Changed;
        protected virtual void OnChanged()
        {
            if (Changed != null) Changed(this, EventArgs.Empty);
        }

        public int Capacity
        {
            get
            {
                return items.Length;
            }
            set
            {
                if (value < count) value = count;
                if (value != items.Length)
                {
                    T[] newItems = new T[value];
                    Array.Copy(items, 0, newItems, 0, count);
                    items = newItems;
                }
            }
        }
        public List(int capacity = defaultCapacity)
        {
            items = new T[capacity];
        }
        public void Add(T item)
        {
            if (count == Capacity) Capacity = count * 2;
            items[count] = item;
            count++;
            OnChanged();
        }
        public T this[int index]
        {
            get
            {
                return items[index];
            }
            set
            {
                items[index] = value;
                OnChanged();
            }
        }
    }
    public class Program
    {
        static int changeCount;
        static void ListChanged(object sender, EventArgs e)
        {
            changeCount++;
        }
        static void Main()
        {
            List<string> names = new List<string>();
            names.Changed += new EventHandler(ListChanged);
            names.Add("Liz");
            names.Add("Martha");
            names.Add("Beth");
            Console.WriteLine(changeCount);     // Outputs "3"
            Console.ReadLine();
        }
    }
}
