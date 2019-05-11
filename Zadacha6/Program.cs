using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha6
{
    class Program
    {
        static int position;
        static bool okey = false; // неубывающаяя/возрастает,если false
        static bool neMonoton = true;
        static void printMas(double[] array)//метод для печати элементов последовательности
        {
            if (array.Length == 0) return;
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.WriteLine($"{i + 1} элемент последовательности равен " + array[i]);
                }
            }
        } // печать последовательности
        static double Element(double[] array, int i) //получение элементов через рекурсию
        {
            if (i - 1 == array.Length) return array[i - 1];
            else 
                return array[i] = 0.7 * array[i - 1] - 0.2 * array[i - 2] + i * array[i - 3];
        }
        static void checkMas(double[] array)// выбираем нечётные элементы из последовательности и проверяем на монотонность
        {         
            int masLength=0;
            for (int i = 1; i < array.Length + 1; i++)
            {
                if (i % 2 != 0)
                {
                    masLength++;
                }
                else continue;
            } //кол-во нечётных индексов в массиве
            double[] massiv = new double[masLength];//массив нечётных индексов
            int b = 0;
            for (int i = 1; i < array.Length + 1; i++)
            {
                if (i % 2 != 0)// выбираем чётные элменты в массив
                {
                    massiv[b] = array[i-1];
                    b++;
                }
                else continue;
            }
            printMas(massiv);
            for(int i=1;i<massiv.Length;i++)
            {
                if (massiv[i-1]<massiv[i])
                {
                    okey = false;// возрастает
                    neMonoton = false;
                }
                else if (massiv[i - 1] > massiv[i])
                {
                    okey = true;// убывает
                    neMonoton = false;
                }
                else neMonoton = true;
            }
        } //проверка на монотонность
        static void Main(string[] args)
        {
            int a1, a2, a3, N;
            Console.Write("Введите элемент a1 = "); a1 = int.Parse(Console.ReadLine());
            Console.Write("Введите элемент a2 = "); a2 = int.Parse(Console.ReadLine());
            Console.Write("Введите элемент a3 = "); a3 = int.Parse(Console.ReadLine());
            Console.Write("Введите количество элементов последовательности N = "); N = int.Parse(Console.ReadLine());
            try
            {
                double[] mas = new double[N];
                mas[0] = a1;
                mas[1] = a2;
                mas[2] = a3;
                //for (int i = 3; i < N; i++) //без рекурсии
                //{
                //    mas[i] = 0.7 * mas[i - 1] - 0.2 * mas[i - 2] + i * mas[i - 3];// массив последовательности
                //}
                position = 3;
                while (position < mas.Length)
                {
                    Element(mas, position);//массив заданных элементов, индекс элмента с какого начинам получать остальные     
                    position++;
                }
                printMas(mas);

                Console.WriteLine();

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Массив элементов с нечётными индексами");
                Console.ResetColor();
                checkMas(mas);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("Неверный размер массива");
            }

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Определение монотонности");
            Console.ResetColor();       
            if (okey == false && neMonoton == false) Console.WriteLine("Монотонная неубывающая (возрастает)");
            else if (okey == true && neMonoton == false) Console.WriteLine("Монотонная убывающая (убывает)");
            else Console.WriteLine("Не монотонная");
            Console.ReadKey();
        }
    }
}
