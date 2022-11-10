/* Lab_06_3_Recursive.cs
 * Якубовський Владислав
 * Лабораторна робота № 6.3 
 * Опрацювання одновимірних масивів ітераційними та рекурсивними способами (рекурсивний спосіб).
 * Варіант 24 */
using System;

namespace AP_Lab_06_3_Recursive
{
    public class Lab_06_3_Recursive
    {
        readonly static Random random = new Random();

        // Функція знаходження найбільшого парного числа в масиві цілих чисел за допомогою звичайних функцій.
        public static int EvenMaximumByRegularFunctions(int[] array, int[] evenArray, int ii = 0, int jj = 0)
        {
            if (ii < array.Length)
            {
                if (array[ii] % 2 == 0 && array[ii] != 0)
                {
                    evenArray[jj] = array[ii];

                    return EvenMaximumByRegularFunctions(array, evenArray, ++ii, ++jj);
                }

                return EvenMaximumByRegularFunctions(array, evenArray, ++ii, jj);
            }

            else
            {
                ReverseSortArrayOfInt(ref evenArray);

                return evenArray[0];
            }
        }

        // Функція знаходження найбільшого парного числа в масиві цілих чисел за допомогою шаблонів функцій.
        public static int EvenMaximumByTemplates(int[] array, int[] evenArray, int ii = 0, int jj = 0)
        {
            if (ii < array.Length)
            {
                if (array[ii] % 2 == 0 && array[ii] != 0)
                {
                    evenArray[jj] = array[ii];

                    return EvenMaximumByTemplates(array, evenArray, ++ii, ++jj);
                }

                return EvenMaximumByTemplates(array, evenArray, ++ii, jj);
            }

            else
            {
                ReverseSortArray(ref evenArray);

                return evenArray[0];
            }
        }

        // Функція, яка рахує кількість парних елементів.
        public static int CountEvenElements(int[] array, int ii = 0, int count = 0)
        {
            if (ii < array.Length)
            {
                if (array[ii] % 2 == 0 && array[ii] != 0)
                    return CountEvenElements(array, ++ii, ++count);

                else return CountEvenElements(array, ++ii, count);
            }

            else return count;
        }

        static void GenerateArray(ref int[] array, int ii = 0)
        {
            if (ii < array.Length)
            {
                array[ii] = random.Next(-100, 100);

                GenerateArray(ref array, ++ii);
            }
        }

        // Звичайна функція форматного виведення масиву цілих чисел.
        static void DisplayArrayOfInt(int[] array, int ii = 0)
        {
            if (ii < array.Length)
            {
                Console.Write(((ii == 0) ? "{ " : "") + $"{array[ii]}" + ((ii < array.Length - 1) ? ", " : "") + ((ii == array.Length - 1) ? " }\n" : ""));

                DisplayArrayOfInt(array, ++ii);
            }
        }

        // Шаблон функції форматного виведення масиву будь-яких типів даних.
        static void DisplayArray<SomeType>(SomeType[] array, int ii = 0)
        {
            if (ii < array.Length)
            {
                Console.Write(((ii == 0) ? "{ " : "") + $"{array[ii]}" + ((ii < array.Length - 1) ? ", " : "") + ((ii == array.Length - 1) ? " }\n" : ""));

                DisplayArray(array, ++ii);
            }                
        }

        // Звичайна функція зворотнього сортування масиву цілих чисел.
        static void ReverseSortArrayOfInt(ref int[] array, int ii = 0, bool wasSwapped = false)
        {
            for (int jj = 0; jj < array.Length - 1; jj++)
                if (array[jj] < array[jj + 1])
                {
                    (array[jj], array[jj + 1]) = (array[jj + 1], array[jj]);

                    wasSwapped = true;
                }

            if (!wasSwapped) return;

            if (ii < array.Length - 1) 
                ReverseSortArrayOfInt(ref array, ++ii);
        }

        // Шаблон функції зворотнього сортування масиву будь-яких типів даних.
        static void ReverseSortArray<SomeType>(ref SomeType[] array, int ii = 0, bool wasSwapped = false) where SomeType : IComparable<SomeType>
        {
            for (int jj = 0; jj < array.Length - 1; jj++)
                if (array[jj].CompareTo(array[jj + 1]) < 0)
                {
                    (array[jj], array[jj + 1]) = (array[jj + 1], array[jj]);

                    wasSwapped = true;
                }

            if (!wasSwapped) return;

            if (ii < array.Length - 1) 
                ReverseSortArray(ref array, ++ii);
        }

        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Console.Write("Введіть розмір масиву: ");

            int size = int.Parse(Console.ReadLine());

            int[] array = new int[size];

            GenerateArray(ref array);

            Console.Write("Спосіб 1. Звичайні функції.\nЗгенерований масив: "); DisplayArrayOfInt(array);
            Console.Write("Максимум з парних чисел: " + (EvenMaximumByRegularFunctions(array, new int[CountEvenElements(array)]) == 0 ? "парних чисел немає!" :
                EvenMaximumByRegularFunctions(array, new int[CountEvenElements(array)]).ToString()));

            Console.ReadLine();

            Console.Write("Спосіб 2. Шаблони функцій.\nЗгенерований масив: "); DisplayArray(array);
            Console.Write($"Максимум з парних чисел: " + (EvenMaximumByTemplates(array, new int[CountEvenElements(array)]) == 0 ? "парних чисел немає!" :
                EvenMaximumByTemplates(array, new int[size]).ToString()));

            Console.ReadLine();
        }
    }
}
