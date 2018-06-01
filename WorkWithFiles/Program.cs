using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HW_File
{
    class Program
    {
        /*Тема: Взаимодействие с файловой системой.

1.	В файле записана непустая последовательность целых чисел, являющихся числами Фибоначчи. Приписать еще столько же чисел этой последовательности.
2.	Сложить два целых числа А и В.
Входные данные
В единственной строке входного файла INPUT.TXT записано два натуральных числа через пробел.
Выходные данные
В единственную строку выходного файла OUTPUT.TXT нужно вывести одно целое число — сумму чисел А и В.

1.	Написать программу, читающую побайтно заданный файл и подсчитывающую число появлений каждого из 256 возможных знаков.
2.	С помощью класса StreamWriter записать в текстовый файл свое имя, фамилию и возраст. Каждая запись должна начинаться с новой строки.
*/

        static void Main(string[] args)
        {
            //Задача 1;
            //Fibonachi();

            //Задача2;
            //WriteNumber();
            //ReadNumber();

            //Задача3;
            Fio();

        }

        #region 1. Fibonachi
        public static void Fibonachi()
        {
            Console.WriteLine("До какого числа считать ряд Фибоначчи?");
            int number = Convert.ToInt32(Console.ReadLine());
            int num1 = 0;
            int num2 = 0;
            FileInfo f = new FileInfo(@"C:\Users\Arman\Documents\visual studio 2015\Projects\WorkWithFiles\Fibonachi.txt");

            using (FileStream fss = f.Open(FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fss, System.Text.Encoding.ASCII))
                {
                    string t = sr.ReadLine();
                    var m = t.Split(',');
                    num1 = int.Parse(m[0]);
                    num2 = int.Parse(m[1]);
                }
            }


            Console.Write("{0} ", num1);

            Console.Write("{0} ", num2);
            int sum = 0;

            while (number >= sum)
            {
                sum = num1 + num2;

                Console.Write("{0} ", sum);

                num1 = num2;
                num2 = sum;
            }
        }
        #endregion

        #region 2. Сложить два целых числа А и В.
        static string path = @"C:\Users\Arman\Documents\visual studio 2015\Projects\WorkWithFiles\INPUT.txt";

        public static void WriteNumber()
        {
            FileInfo fi = new FileInfo(path);

            Console.WriteLine("Enter first number");
            int n1 = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter second number");
            int n2 = Int32.Parse(Console.ReadLine());

            using (FileStream fs = fi.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {

                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.ASCII))
                {
                    sw.Write(n1);
                    sw.Write(" ");
                    sw.Write(n2);
                    Console.WriteLine("Numbers was written in INPUT.TXT");
                }
            }
        }

        public static void ReadNumber()
        {

            int summ = 0;

            FileInfo fi = new FileInfo(path);

            using (FileStream fss = fi.Open(FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fss, System.Text.Encoding.ASCII))
                {
                    string t = sr.ReadLine();
                    Console.WriteLine("File was read:  " + t);
                    var m = t.Split(' ');
                    int n01 = int.Parse(m[0]);
                    int n02 = int.Parse(m[1]);
                    summ = n01 + n02;
                    Console.WriteLine("Amount received " + summ);
                }
            }

            FileInfo fii = new FileInfo(@"C:\Users\Arman\Documents\visual studio 2015\Projects\WorkWithFiles\OUTPUT.txt");
            using (FileStream fs = fii.Open(FileMode.OpenOrCreate, FileAccess.Write)) // using заменяет открытие и зикрытие скобками
            {

                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.ASCII))
                {
                    sw.Write(summ);
                    Console.WriteLine("Sum was written in OUTPUT.TXT");
                }
            }

        }
        #endregion

        #region 3. С помощью класса StreamWriter записать в текстовый файл свое имя, фамилию и возраст.
        public static void Fio()
        {
            string path = @"C:\Users\Arman\Documents\visual studio 2015\Projects\WorkWithFiles\FIO.txt";

            FileInfo file = new FileInfo(path);

            Console.WriteLine("Enter your name");
            string name = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter surname name");
            string surname = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("Enter your age");
            string age = Console.ReadLine();
            Console.WriteLine();

            using (FileStream fs = file.Open(FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs, System.Text.Encoding.Default))
                {
                    sw.WriteLine(name);
                    sw.WriteLine(surname);
                    sw.WriteLine(age);
                    Console.WriteLine("Information was written in Fio.txt");
                }
            }
        }
        #endregion
    }
}
