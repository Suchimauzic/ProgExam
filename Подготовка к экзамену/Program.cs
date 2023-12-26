using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Подготовка_к_экзамену
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Тут вызываем нужное задание
            Console.ReadKey();
        }

        static void zad2()
        {
            int[] course = new int[30];
            Random rnd = new Random();
            int min = 100, max = 0, minDay = 0, maxDay = 0;

            Console.WriteLine("Курс юаней за месяц");

            for (int i = 0; i < course.Length; i++)
            {
                course[i] = rnd.Next(7, 70);
                if (course[i] < min)
                {
                    min = course[i];
                    minDay = i + 1;
                }
                if (course[i] > max)
                {
                    max = course[i];
                    maxDay = i + 1;
                }
                Console.WriteLine((i + 1) + " день - " + course[i] + " рублей");
            }

            Console.WriteLine("Самый высокий курс был в этот день: " + maxDay + ", равнялся - " + max + " руб");
            Console.WriteLine("Самый низкий курс был в этот день: " + minDay + ", равнялся - " + min + " руб");

        }

        static void zad10()
        {
            int[,] grades = new int[25, 5];
            Random rnd = new Random();
            double am;

            Console.WriteLine("\t\tРусский язык\tМатематика\tБиология\tИстория\t\tХимия\t\tСреднее");

            for (int i = 0; i < 25; i++)
            {
                am = 0;

                Console.Write("Студент " + (i + 1) + "\t");

                for (int j = 0; j < 5; j++)
                {
                    grades[i, j] = rnd.Next(2, 6);
                    am += grades[i, j];
                    Console.Write(grades[i, j] + "\t\t");
                }

                Console.WriteLine(am / 5);

                Console.WriteLine();
            }
        }

        static void zad16()
        {
            string path = "Resources/numbers.txt";
            Random rnd = new Random();
            int numbs;
            int numb;
            List<int> list = new List<int>();
            StreamWriter sw;
            StreamReader sr;

            FileStream file = File.Open(path, FileMode.OpenOrCreate);
            file.Close();
            sw = new StreamWriter(path);

            Console.Write("Сколько цифр вы хотите видеть: ");
            numbs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numbs; i++)
            {
                sw.WriteLine(rnd.Next(-100, 101).ToString());
            }

            sw.Close();

            string[] lines = File.ReadAllLines(path);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
            path = "Resources/numbers2.txt";
            file = File.Open(path, FileMode.OpenOrCreate);
            file.Close();
            sw = new StreamWriter(path);
            foreach (string e in lines)
            {

                numb = int.Parse(e);
                
                if (numb % 2 == 0)
                    numb++;
                
                if (numb * 0.3 > 5)
                {
                    sw.WriteLine(numb * 0.3);
                }
            }
            sw.Close();
        }

        static void zad18()
        {
            Random rnd = new Random();
            int[] arr = new int[10];
            int[] indexes = new int[2];
            int numb;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(20);
                Console.Write(arr[i] + "\t");
            }

            Console.WriteLine("\r\nВведите ваше число: ");
            numb = int.Parse(Console.ReadLine());
            indexes = forZad18(arr, numb);

            if (indexes[0] == -1)
            {
                Console.WriteLine("Таких чисел нет");
            }
            else
            {
                Console.WriteLine($"Сумму числа {numb} можно составить из чисел под индексами {indexes[0]} и {indexes[1]}");
            }
        }

        static int[] forZad18(int[] arr, int numb)
        {
            int[] indexes = { -1, -1 };
            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = i; j < arr.Length; j++)
                {
                    if (arr[i] + arr[j] == numb)
                    {
                        indexes[0] = i;
                        indexes[1] = j;
                        return indexes;
                    }
                }
            }
            return indexes;
        }

        static void zad20()
        {
            Dictionary<char, int> dict = new Dictionary<char, int>();
            dict.Add('I', 1);
            dict.Add('V', 5);
            dict.Add('X', 10);
            dict.Add('L', 50);
            dict.Add('C', 100);
            dict.Add('D', 500);
            dict.Add('M', 1000);

            string line;
            int sum = 0;

            Console.Write("Введите число в римской системе счисления: ");
            line = Console.ReadLine().ToUpper();

            for (int i = 0; i < line.Length; i++)
            {
                if (i == line.Length - 1 || dict[line[i]] >= dict[line[i+1]])
                {
                    sum += dict[line[i]];
                }
                else
                {
                    sum -= dict[line[i]];
                }
            }

            Console.WriteLine("В арабской системе: " + sum);
        }

        static void zad21()
        {
            int[] arr = new int[100];
            Random rnd = new Random();
            bool sorting = true;
            int temp;

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(100);
                Console.Write(arr[i] + " ");
            }

            while (sorting)
            {
                sorting = false;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != arr.Length - 1)
                    {
                        if (arr[i] > arr[i + 1])
                        {
                            sorting = true;
                            temp = arr[i];
                            arr[i] = arr[i + 1];
                            arr[i + 1] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("\r\n");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }

            sorting = true;

            while (sorting)
            {
                sorting = false;

                for (int i = 0; i < arr.Length; i++)
                {
                    if (i != arr.Length - 1)
                    {
                        if (arr[i] < arr[i + 1])
                        {
                            sorting = true;
                            temp = arr[i + 1];
                            arr[i + 1] = arr[i];
                            arr[i] = temp;
                        }
                    }
                }
            }

            Console.WriteLine("\r\n");

            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        static void zad22()
        {
            List<int> list = new List<int>();
            Random rnd = new Random();
            bool check = false;
            bool finded = false;
            int numb;
            int find;
            int start, stop;
            byte index = 0;

            Console.WriteLine("Введите неотрицательное число до 100, которое неоходимо найти: ");
            find = int.Parse(Console.ReadLine());

            for (int i = 0; i < 100; i++)
            {
                numb = rnd.Next(100);
                foreach(int e in list)
                {
                    check = numb == e;
                    if (check)
                        break;
                }
                if (!check)
                {
                    list.Add(i);
                }
            }

            list.Sort();

            for (int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }

            start = 0;
            stop = list.Count - 1;

            int countIter = 0;

            while (!finded)
            {
                index = (byte)((start + stop) / 2);

                if (list[index] > (int)find)
                {
                    stop = index;
                }
                else if (list[index] < find)
                {
                    start = index;
                }
                else
                {
                    break;
                }
                
                if (countIter == 10)
                {
                    Console.WriteLine("\r\nТакого числа нет!");
                    return;
                }
                countIter++;
            }

            Console.WriteLine("\r\nВаше число находится под индексом " + index);
        }

        static void zad25()
        {
            const int COUNT = 21;
            int c;
            Random rnd = new Random();
            ConsoleColor[] col = { ConsoleColor.Red, ConsoleColor.Yellow, ConsoleColor.Green, ConsoleColor.DarkCyan };
            byte colNumb = 0;
            int time = 2000;

            while (true)
            {
                c = 0;
                Console.Clear();
                for (int i = 0; i < COUNT; i += 2)
                {
                    for (int j = 0; j < COUNT; j++)
                    {
                        if (j >= (int)(COUNT / 2) - c && j <= (int)(COUNT / 2) + c)
                        {
                            Console.Write('*');
                            if (rnd.Next(100) >= 80)
                            {
                                Console.ForegroundColor = col[colNumb];
                            }
                            else
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                            }
                        }
                        else
                        {
                            Console.Write(' ');
                        }
                    }
                    c += 1;
                    Console.WriteLine();
                }

                colNumb++;
                if (colNumb == col.Length)
                {
                    colNumb = 0;
                }

                Thread.Sleep(time);
                time -= 100;
                if (time <= 100)
                {
                    time -= 10;
                }
                if (time <= 20)
                {
                    time = 2000;
                }
            }
        }
        static void zad27()
        {
            Console.Write("Введите число: ");
            Console.WriteLine("Факториал числа: " + forZad27(int.Parse(Console.ReadLine())));
        }

        static long forZad27(int numb)
        {
            if (numb == 0)
            {
                return 0;
            }
            if (numb == 1)
            {
                return 1;
            }

            return numb * forZad27(numb - 1);
        }
        
        static void zad28()
        {
            int[,] arr = new int[5, 5];
            Random rnd = new Random();
            int sum = 0;

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    arr[j, i] = rnd.Next(100);
                    Console.Write(arr[j, i] + "\t");
                }
                Console.WriteLine();
            }

            for (int i = 0; i < 5; i++)
            {
                if (arr[i, i] % 2 == 0)
                {
                    sum += arr[i, i];
                }
            }

            Console.WriteLine(sum);
        }
    }
}
