using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyGeneric
{
    public class CommonMethod
    {
        /// <summary>
        /// 打印一个int值
        /// </summary>
        /// <param name="iParameter"></param>
        public static void ShowInt(int iParameter)
        {
            Console.WriteLine("This is {0}, parameter={1}, type={2}",
                typeof(CommonMethod).Name, iParameter.GetType().Name, iParameter);
        }

        public static void ShowString(string sParameter)
        {
            Console.WriteLine("This is {0}, parameter={1}, type={2}",
                typeof(CommonMethod).Name, sParameter.GetType().Name, sParameter);
        }

        public static void ShowObject(object oP)
        {
            Console.WriteLine("This is {0}, parameter={1}, type={2}",
                typeof(CommonMethod).Name, oP.GetType().Name, oP);
        }
    }
}
