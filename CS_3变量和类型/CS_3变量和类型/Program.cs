using System;

namespace CS_3变量和类型
{
    class Program
    {
        static void Main(string[] args)
        {
            int a = 10;
            object o = a;
            Console.WriteLine(o);
            int b = (int)o;
            Console.WriteLine(o);
            Console.ReadLine();
        }
    }
}
