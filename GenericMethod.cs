using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class GenericMethod
    {
        public static void Show<T>(T tParam)
        {
            Console.WriteLine("This is {0}, parameter={1}, type={2}",
                typeof(GenericMethod), tParam.GetType().Name, tParam.ToString());
        }

        public static void ShowObject(object oP)
        {
            Console.WriteLine("This is {0}, parameter={1}, type={2}",
                typeof(CommonMethod).Name, oP.GetType().Name, oP);
        }
    }
}
