using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynamicArrays1
{
    internal class Program
    {
        static void Add(ref int[] array, ref int size, ref int capacity, int item)
        {
            if (size >= capacity)
            {
                Resize(ref array, ref size, ref capacity);
            }
            array[size] = item;
            size++;
        }

        static void Resize(ref int[] array, ref int size, ref int capacity)
        {
            capacity *= 2;
            int[] newArray = new int[capacity];
            Array.Copy(array, newArray, size);
            array = newArray;
        }

        static int Get(int[] array, int size, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапозона");
            }
            return array[index];
        }

        static void Display(int[] array, int size)
        {
            for (int i = 0; i < size; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
        }

        // Задание 1
        static void Remove(ref int[] array, ref int size, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапозона");
            }
            else
            {
                int[] newArray = new int[size - 1];


                for (int i = 0; i <= size - 1; i++)
                {
                    if (i < index)
                    {
                        newArray[i] = array[i];
                    }
                    else if (i == index)
                    {

                    }
                    else
                    {
                        newArray[i - 1] = array[i];
                    }
                }
                array = newArray;
                size = size - 1;
            }
        }

        // Задание 2
        /*
        static bool Contains(int[] array, int element)
        {
            foreach (int item in array) if (item == element) return true; return false;
        }
        */
        // Переделал, чтобы не учитывать пустые элементы
        static bool Contains(int[] array, int size, int element)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == element) return true;
            }
            return false;
        }


        // Задание 3
        static void Clear(ref int[] array, ref int size, ref int capacity)
        {
            array = new int[capacity];
            size = 0;
        }

        // Задание 4
        static void Insert(ref int[] array, ref int size, ref int capacity, int index, int element)
        {
            if (index < 0 || index > size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }

            if (size >= capacity)
            {
                Resize(ref array, ref size, ref capacity);
            }

            int[] newArray = new int[size + 1];

            for (int i = 0; i < size + 1; i++)
            {
                if (i < index)
                {
                    newArray[i] = array[i];
                }
                else if (i == index)
                {
                    newArray[i] = element;
                }
                else
                {
                    newArray[i] = array[i - 1];
                }
            }

            array = newArray;
            size++;
        }

        // Задание 5
        static int[] ToArray(int[] array, int size)
        {
            int[] newArray = new int[size];
            Array.Copy(array, newArray, size);
            return newArray;
        }


        // Задание 6
        static int IndexOf(int[] array, int size, int element)
        {
            for (int i = 0; i < size; i++)
            {
                if (array[i] == element) return i;
            }
            return -1;
        }

        // Задание 7
        static void Reverse(ref int[] array)
        {
            Array.Reverse(array);
        }

        // Задание 8
        static void Sort(ref int[] array)
        {
            Array.Sort(array);
        }

        // Задание 9
        static void CopyTo(int[] array, int size, ref int[] newArray)
        {
            Array.Copy(array, newArray, size);
        }

        // Задание 10
        static int GetCapacity(int[] array)
        {
            return array.Length;
        }


        // Задание 11
        static void ResizeTo(ref int[] array, ref int size, ref int capacity, int newCapacity)
        {
            capacity = newCapacity;
            int[] newArray = new int[capacity];
            Array.Copy(array, newArray, size);
            array = newArray;
        }

        // Задание 12
        static int GetLast(int[] array, int size)
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Массив пуст.");
            }
            return array[size - 1];
        }

        // Задание 13
        static void RemoveAt(ref int[] array, ref int size, int index)
        {
            if (index < 0 || index >= size)
            {
                throw new IndexOutOfRangeException("Индекс вне диапазона");
            }

            for (int i = index; i < size - 1; i++)
            {
                array[i] = array[i + 1];
            }

            size--;
        }

        // Задание 14
        static int[] GetSubArray(int[] array, int size, int start, int end)
        {
            int[] newArray = new int[end - start];

            for (int i = start; i < end; i++)
            {
                newArray[i - start] = array[i];
            }

            return newArray;
        }
        
        static int FindMax(int[] array, int size)
        {
            if (size == 0)
            {
                throw new InvalidOperationException("Массив пуст.");
            }
            int max = 0;
            for (int i = 0; i < size; i++)
            {
                if (i == 0) max = array[i];
                else if (array[i] > max) max = i;
            }
            return max;
        }



        static void Main(string[] args)
        {
            int initialCapacity = 4;
            int index = 2, element = 6;
            int[] dynamicArray = new int[initialCapacity];
            int size = 0;
            Random random = new Random();

            for (int i = 0; i < 10; i++)
            {
                Add(ref dynamicArray, ref size, ref initialCapacity, random.Next(1, 11));
            }
            Console.WriteLine("Элементы массива: ");
            Display(dynamicArray, size);

            Console.WriteLine($"\nЭлемент по индексу {index} - {Get(dynamicArray, size, index)}");
            Console.WriteLine("Текущий размер массива: " + size);

            // Задание 1
            Remove(ref dynamicArray, ref size, index);
            Console.WriteLine($"\nМассив после удаления элемента с индексом {index}:");
            Display(dynamicArray, size);

            // Задание 2
            if (Contains(dynamicArray, size, element)) Console.WriteLine($"\nЭлемент {element} содержится в данном массиве."); 
            else Console.WriteLine($"\nЭлемент {element} отсутсвует в данном массиве.");

            // Задание 3
            Clear(ref dynamicArray, ref size, ref initialCapacity);
            Console.WriteLine("\nМассив был очищен!");

            // Т.к. массив был очищен, для некст заданий заново заполняем и выводим 
            for (int i = 0; i < 10; i++)
            {
                Add(ref dynamicArray, ref size, ref initialCapacity, random.Next(1, 11));
            }
            Console.WriteLine("\nЭлементы нового массива - ");
            Display(dynamicArray, size);

            // Задание 4
            index = 4; element = 5;
            Insert(ref dynamicArray, ref size, ref initialCapacity, index, element);
            Console.WriteLine($"\nМассив с добавленным элементом {element} по индексу {index}:");
            Display(dynamicArray, size);

            // Задание 5
            int[] defaultArray = ToArray(dynamicArray, size);
            Console.WriteLine("\nОбычный массив, содержащий все элементы динамического массива:");
            foreach (int item in defaultArray) Console.Write($"{item} ");

            // Задание 6
            if (IndexOf(dynamicArray, size, element) != -1) Console.WriteLine($"\n\nЭлемент {element} содержится в данном массиве.");

            // Задание 7
            Reverse(ref dynamicArray);
            Console.WriteLine("\nМассив после реверсирования:");
            Display(dynamicArray, size);

            // Задание 8
            Sort(ref dynamicArray);
            Console.WriteLine("\nМассив после сортировки:");
            Display(dynamicArray, size);

            // Задание 9
            int[] copiedArray = new int[size];
            CopyTo(dynamicArray, size, ref copiedArray);
            Console.WriteLine("\nСкопированный динамический массив:");
            Display(copiedArray, size);

            // Задание 10
            Console.WriteLine($"\nТекущая вместимость массива: {GetCapacity(dynamicArray)}");

            // Задание 11
            int newCapacity = 26;
            ResizeTo(ref dynamicArray, ref size, ref initialCapacity, newCapacity);
            Console.WriteLine($"\nВместимость массива была увеличена, и теперь равна {initialCapacity}");

            // Задание 12
            Console.WriteLine($"\nПоследний элемеент в массиве: {GetLast(dynamicArray, size)}");

            // Задание 13
            index = 4;
            RemoveAt(ref dynamicArray, ref size, index);
            Console.WriteLine("Массив после удаления элемента по индексу с помощью RemoveAt:");
            Display(dynamicArray, size);

            // Задание 14
            int start = 3, end = 7;
            int[] newArray = GetSubArray(dynamicArray, size, start, end);
            Console.WriteLine($"\nНовый массив, содержащий элементы динамического массива в диапазоне ({start}-{end}):");
            foreach (int item in newArray) Console.Write($"{item} ");

            // Задание 15
            Console.WriteLine($"\nМаксимальный элемент в динамическом массиве: {FindMax(dynamicArray, size)}");

        }
    }
}
