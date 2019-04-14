using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zadacha6
{
    class Program
    {
        static void printMas(double[] array)//метод для печати элементов последовательности
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i + 1} элемент последовательности равен " + array[i]);
            }
        } // печать последовательности
        static bool checkMas(double[] array)// выбираем нечётные элементы из последовательности и проверяем на монотонность
        {
            bool okey = false;
            double[] massiv = new double[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                if (i % 2 != 0) massiv[i] = array[i];
                else continue;
            }
            massiv = massiv.Where(x => x != 0).ToArray();
            for (int i = 0; i < massiv.Length;)
            {
                Console.WriteLine(massiv[i]);
                if (massiv[i] < massiv[i + 1])
                {
                    okey = true;
                    break;
                }
                else
                {
                    okey = false;
                    break;
                }
            }
            return okey;
         } //проверка на монотонность
        static void Main(string[] args)
        {
            int a1, a2, a3, N;
            Console.Write("Введите элемент a1 = "); a1 = int.Parse(Console.ReadLine());
            Console.Write("Введите элемент a2 = "); a2 = int.Parse(Console.ReadLine());
            Console.Write("Введите элемент a3 = "); a3 = int.Parse(Console.ReadLine());
            Console.Write("Введите количество элементов последовательности N = "); N = int.Parse(Console.ReadLine());
            double[] mas = new double[N];
            mas[0] = a1;
            mas[1] = a2;
            mas[2] = a3;
            for(int i = 3;i<N;i++)
            {
                mas[i] = 0.7 * mas[i - 1] - 0.2 * mas[i - 2] + i *mas[i - 3];// массив последовательности
            }
            printMas(mas);
            if (checkMas(mas) == true) Console.WriteLine("Неубывающая");
            else Console.WriteLine("Убывающая");
        }
    }
}
