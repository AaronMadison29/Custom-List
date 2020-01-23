﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class CustomList<T>
    {
        T[] list;
        private int capacity;
        private int count;

        public T this[int index]
        {
            get
            {
                if(index > count - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                return list[index];
            }
            set
            {
                if (index > count - 1 || index < 0)
                {
                    throw new IndexOutOfRangeException();
                }
                list[index] = value;
            }
        }

        public static CustomList<T> operator +(CustomList<T> thisList, CustomList<T> addition)
        {
            for (int i = 0; i < addition.Count; i++)
            {
                thisList.Add(addition[i]);
            }
            return thisList;
        }

        public int Capacity
        {
            get
            {
                return capacity;
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

        public CustomList()
        {
            list = new T[4];
            capacity = 4;
            count = 0;
        }

        public void Add(T value)
        {
            count++;
            if(count > capacity)
            {
                list = Copy();
            }

            list[count - 1] = value;
        }

        public bool Remove(T value)
        {
            for(int i = 0; i < count; i++)
            {
                if (list[i].Equals(value))
                {
                    if(count == 1)
                    {
                        list = new T[4];
                        return true;
                    }
                    list = CopyExcept(i);
                    count--;
                    return true;
                }
            }
            return false;
        }

        public string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for(int i = 0; i < count; i++)
            {
                stringBuilder.Append(list[i].ToString());
            }
            return stringBuilder.ToString();
        }

        private T[] Copy()
        {
            capacity *= 2;

            T[] temporary = new T[capacity];

            for(int i = 0; i < count - 1; i++)
            {
                temporary[i] = list[i];
            }

           return temporary;
        }

        private T[] CopyExcept(int index)
        {
            int counter = 0;
            int newCount = count;
            T[] temporary = new T[capacity];
            if(index == count - 1)
            {
                newCount--;
            }
            for (int i = 0; i < newCount; i++)
            {
                if(i == index)
                {
                    i++;
                }
                temporary[counter] = list[i];
                counter++;
            }
            return temporary;
        }
    }
}
