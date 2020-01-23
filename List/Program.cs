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
            CustomList<int> list1 = new CustomList<int>();
            CustomList<int> list2 = new CustomList<int>();
            list1.Add(5);
            list1.Add(6);
            list2.Add(7);
            list2.Add(8);

            list1 = list1 + list2;

            for(int i = 0; i < list1.Count; i++)
            {
                Console.WriteLine(list1[i]);
            }
            Console.ReadLine();
        }
    }
}
