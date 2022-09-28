using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class MyDelegate
    {
        public delegate void MyDelegateInt(int number);
        public delegate void MyDelegateString(string number);
        public delegate T MyDelegateString<T>(T tNumber);

        public void ShowInt(int n)
        {
            Console.WriteLine("Hello world, int :{0}", n);
        }

        public void ShowString(string s)
        {
            Console.WriteLine("Hello world, string :{0}", s);
        }
    }
}
