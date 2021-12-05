using System;

namespace CS_6结构
{
    struct Point
    {
        public int x, y;
        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Point a = new Point(10, 10);
            Point b = a;
            a.x = 20;
            Console.WriteLine(b.x);
            Console.ReadLine();
        }
    }
}
