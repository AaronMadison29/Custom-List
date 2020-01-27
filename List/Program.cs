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
            CustomList<int> list = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            CustomList<int> list3;

            list.Add(5);
            list.Add(8);
            list.Add(9);
            list.Add(7);
            list2.Add(5);
            list2.Add(8);
            list2.Add(9);
            list2.Add(3);

            list3 = list - list2;

            CustomList<string> list1 = new CustomList<string>()
            {
                "carrot",
                "fox",
                "explorer"
            };

            string x = list1[0];

            Console.WriteLine(x);
            Console.ReadLine();
        }
    }
}
