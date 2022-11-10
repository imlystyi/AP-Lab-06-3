/* Lab_06_3_Iterative.cs
 * Якубовський Владислав
 * Лабораторна робота № 6.3 
 * Опрацювання одновимірних масивів ітераційними та рекурсивними способами (ітераційний спосіб).
 * Варіант 24 */
using System;

namespace AP_Lab_06_3_Iterative
{
    public class Lab_06_3_Iterative
    {
        readonly static Random random = new Random();

        // Функція знаходження найбільшого парного числа в масиві цілих чисел за допомогою звичайних функцій.
        public static int EvenMaximumByRegularFunctions(int[] array)
        {
            int[] evenArray = new int[CountEvenElements(array)];

            for (int ii = 0, jj = 0; ii < array.Length; ii++)
                if (array[ii] % 2 == 0 && array[ii] != 0)
                {
                    evenArray[jj] = array[ii];

                    jj++;
                }

            ReverseSortArrayOfInt(ref evenArray);

            return evenArray[0];
        }

        // Функція знаходження найбільшого парного числа в масиві цілих чисел за допомогою шаблонів функцій.
        public static int EvenMaximumByTemplates(int[] array)
        {
            int[] evenArray = new int[CountEvenElements(array)];

            for (int ii = 0, jj = 0; ii < array.Length; ii++)
                if (array[ii] % 2 == 0 && array[ii] != 0)
                {
                    evenArray[jj] = array[ii];

                    jj++;
                }
            
            ReverseSortArray(ref evenArray);

            return evenArray[0];
        }

        static int[] GenerateArray(int size)
        {
            int[] generatedArray = new int[size];

            for (int ii = 0; ii < size; ii++)
                generatedArray[ii] = random.Next(-100, 100);

            return generatedArray;
        }

        // Звичайна функція форматного виведення масиву цілих чисел.
        static void DisplayArrayOfInt(int[] array)
        {
            for (int ii = 0; ii < array.Length; ii++)
                Console.Write(((ii == 0) ? "{ " : "") + $"{array[ii]}" + ((ii < array.Length - 1) ? ", " : "") + ((ii == array.Length - 1) ? " }\n" : ""));
        }

        // Шаблон функції форматного виведення масиву будь-яких типів даних.
        static void DisplayArray<SomeType>(SomeType[] array)
        {
            for (int ii = 0; ii < array.Length; ii++)
                Console.Write(((ii == 0) ? "{ " : "") + $"{array[ii]}" + ((ii < array.Length - 1) ? ", " : "") + ((ii == array.Length - 1) ? " }\n" : ""));
        }

        // Звичайна функція зворотнього сортування масиву цілих чисел.
        static void ReverseSortArrayOfInt(ref int[] array)
        {
            bool wasSwapped;

            for (int ii = 0; ii < array.Length; ii++)
            {
                wasSwapped = false;

                for (int jj = 0; jj < array.Length - 1; jj++)
                    if (array[jj] < array[jj + 1])
                    {
                        (array[jj], array[jj + 1]) = (array[jj + 1], array[jj]);

                        wasSwapped = true;
                    }

                if (!wasSwapped) return;
            }
        }

        // Шаблон функції зворотнього сортування масиву будь-яких типів даних.
        static void ReverseSortArray<SomeType>(ref SomeType[] array) where SomeType : IComparable<SomeType>
        {
            bool wasSwapped;

            for (int ii = 0; ii < array.Length; ii++)
            {
                wasSwapped = false;

                for (int jj = 0; jj < array.Length - 1; jj++)
                    if (array[jj].CompareTo(array[jj + 1]) < 0)
                    {
                        (array[jj], array[jj + 1]) = (array[jj + 1], array[jj]);

                        wasSwapped = true;
                    }

                if (!wasSwapped) return;
            }
        }

        // Функція, яка рахує кількість парних елементів.
        static int CountEvenElements(int[] array)
        {
            int count = 0;

            for (int ii = 0; ii < array.Length; ii++)
                if (array[ii] % 2 == 0 && array[ii] != 0) count++;

            return count;
        }
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.Default;

            Console.Write("Введіть розмір масиву: ");

            int size = int.Parse(Console.ReadLine());

            int[] array = GenerateArray(size); 

            Console.Write("Спосіб 1. Звичайні функції.\nЗгенерований масив: "); DisplayArrayOfInt(array);
            Console.Write("Максимум з парних чисел: " + (EvenMaximumByRegularFunctions(array) == 0 ? "парних чисел немає!" : 
                EvenMaximumByRegularFunctions(array).ToString()));

            Console.ReadLine();

            Console.Write("Спосіб 2. Шаблони функцій.\nЗгенерований масив: "); DisplayArray(array);
            Console.Write($"Максимум з парних чисел: " + (EvenMaximumByTemplates(array) == 0 ? "парних чисел немає!" : 
                EvenMaximumByTemplates(array).ToString()));

            Console.ReadLine();
        }
    }
}
