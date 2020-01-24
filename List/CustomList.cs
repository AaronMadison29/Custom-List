using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List
{
    public class CustomList<T>: IComparer<T>
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

        public static CustomList<T> operator +(CustomList<T> thisList, CustomList<T> addition)
        {
            for (int i = 0; i < addition.Count; i++)
            {
                thisList.Add(addition[i]);
            }
            return thisList;
        }

        public static CustomList<T> operator -(CustomList<T> thisList, CustomList<T> subtraction)
        {
            for (int i = 0; i < subtraction.Count; i++)
            {
                thisList.Remove(subtraction[i]);
            }
            return thisList;
        }

        public CustomList()
        {
            array = new T[4];
            capacity = 4;
            count = 0;
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

        public CustomList<T> Zip(CustomList<T> secondList)
        {
            CustomList<T> output = new CustomList<T>();
            int outputCounter = 0;
            int inputCounter = 0;

            while (outputCounter < secondList.Count + count)
            {
                if (inputCounter < count)
                {
                    output.Add(array[inputCounter]);
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
                if (Compare(array[i], array[i+1]) == 1)
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

        public int Compare(T x, T y)
        {
            if(x is int)
            {
                if (Convert.ToInt32(x) > Convert.ToInt32(y))
                {
                    return 1;
                }
                else if (Convert.ToInt32(x) < Convert.ToInt32(y))
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else if(x is string)
            {
                if (x.ToString().CompareTo(y.ToString()) == 1)
                {
                    return 1;
                }
                else if (x.ToString().CompareTo(y.ToString()) == -1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else if(x is bool)
            {
                if (Convert.ToBoolean(x).CompareTo(Convert.ToBoolean(y)) == 1)
                {
                    return 1;
                }
                else if (Convert.ToBoolean(x).CompareTo(Convert.ToBoolean(y)) == -1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            else if(x is char)
            {
                if (Convert.ToChar(x).CompareTo(Convert.ToChar(y)) == 1)
                {
                    return 1;
                }
                else if (Convert.ToChar(x).CompareTo(Convert.ToChar(y)) == -1)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            return 0;
        }
    }
}
