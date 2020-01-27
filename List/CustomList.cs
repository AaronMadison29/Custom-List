using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class CustomList<T> : IEnumerable where T : IComparable
    {
        T[] array;
        private int capacity;
        private int count;

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
            array = new T[4];
            capacity = 4;
            count = 0;
        }

        public T this[int index]
        {
            get
            {
                if (index > count - 1 || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                return array[index];
            }
            set
            {
                if (index > count - 1 || index < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                array[index] = value;
            }
        }

        public static CustomList<T> operator +(CustomList<T> baseList, CustomList<T> addition)
        {
            CustomList<T> temporary = new CustomList<T>();
            foreach (T value in baseList)
            {
                temporary.Add(value);
            }
            foreach (T value in addition)
            {
                temporary.Add(value);
            }
            return temporary;
        }

        public static CustomList<T> operator -(CustomList<T> baseList, CustomList<T> subtraction)
        {
            CustomList<T> temporary = baseList;
            foreach(T value in subtraction)
            {
                temporary.Remove(value);
            }
            return temporary;
        }

        public void Add(T value)
        {
            count++;
            if (count > capacity)
            {
                array = Copy();
            }

            array[count - 1] = value;
        }

        public bool Remove(T value)
        {
            bool isRemoved = false;

            for (int i = 0; i < count; i++)
            {
                if (array[i].Equals(value))
                {
                    if (count == 1)
                    {
                        array = new T[4];
                        isRemoved = true;
                        break;
                    }
                    array = CopyExcept(i);
                    isRemoved = true;
                    break;
                }
            }
            if (isRemoved)
            {
                count--;
                return true;
            }
            else
            {
                return false;
            }
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                stringBuilder.Append(array[i].ToString());
            }
            return stringBuilder.ToString();
        }

        public static CustomList<T> Zip(CustomList<T> firstList, CustomList<T> secondList)
        {
            CustomList<T> output = new CustomList<T>();
            int outputCounter = 0;
            int inputCounter = 0;

            while (outputCounter < secondList.Count + firstList.Count)
            {
                if (inputCounter < firstList.Count)
                {
                    output.Add(firstList.array[inputCounter]);
                    outputCounter++;
                }

                if (inputCounter < secondList.Count)
                {
                    output.Add(secondList[inputCounter]);
                    outputCounter++;
                }
                inputCounter++;
            }
            return output;
        }

        public T[] Sort()
        {
            if(count == 1)
            {
                return array;
            }

            bool swap = false;

            for (int i = 0; i < count - 1; i++)
            {
                if (array[i].CompareTo(array[i+1]) == 1)
                {
                    T temp = array[i];
                    array[i] = array[i + 1];
                    array[i + 1] = temp;
                    swap = true;

                }
            }

            if (swap)
            {
                return Sort();
            }
            else
            {
                return array;
            }
        }

        private T[] Copy()
        {
            capacity *= 2;

            T[] temporary = new T[capacity];

            for(int i = 0; i < count - 1; i++)
            {
                temporary[i] = array[i];
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
                temporary[counter] = array[i];
                counter++;
            }
            return temporary;
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < count; i++)
            {
                yield return array[i];
            }
        }
    }
}
