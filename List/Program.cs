using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    class Program
    {
        static void Main(string[] args)
        {
            //Arrange
            CustomList<int> list = new CustomList<int>();
            list.Add(6);
            list.Add(8);
            list.Add(9);
            list.Add(8);
            list.Add(5);
            list.Add(4);
            list.Add(3);
            list.Add(2);
            list.Add(0);
            list.Add(1);
            list.Add(10);
            list.Add(11);
            list.Add(50);
            list.Sort();

            Console.WriteLine(list.ToString());
            Console.ReadLine();
        }
    }
}
