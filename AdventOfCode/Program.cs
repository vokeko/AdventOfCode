using System;
using System.IO;
using System.Collections.Generic;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            uint day = 1;
            bool first = false;

            Console.WriteLine("Zadejte den (1-24)");
            uint number = Convert.ToUInt32(Console.ReadLine());
            if (number > 0 && number < 25)
                day = number;

            Console.WriteLine("Zadejte úkol (1 nebo 2)");
            if (Console.ReadKey().Key == ConsoleKey.D1 || Console.ReadKey().Key == ConsoleKey.F1)
                first = true;

            Console.WriteLine("T pro test");
            if (Console.ReadKey().Key == ConsoleKey.D1 || Console.ReadKey().Key == ConsoleKey.F1)
                test = true;

            switch(day)
            {
                case 1:
                    if (first)
                        DayOneFirst(test);
                    else
                        DayOneSecond(test);
                    break;
                case 2:
                    if (first)
                        DayTwoFirst(test);
                    else
                        DayTwoSecond(test);
                    break;
                case 3:
                    if (first)
                        DayThreeFirst(test);
                    else
                        DayThreeSecond(test);
                    break;
            }
        }
        static void DayOneFirst(bool test)
        {
            string path = "day1.txt";
            if (test)
                path = "day1_test.txt";
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            int vyskyty = 0;
            int posledni = 90000000;

            while (!string.IsNullOrWhiteSpace(line))
            {
                if (Convert.ToInt32(line) > posledni)
                {
                    vyskyty++;
                }
                posledni = Convert.ToInt32(line);
                line = reader.ReadLine();
            }
            Console.WriteLine(vyskyty);
        }
        static void DayOneSecond(bool test)
        {
            string path = "day1.txt";
            if (test)
                path = "day1_test.txt";
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            int lineCislo;
            int vyskyty = 0;
            List<int> tabulka1 = new List<int>();
            List<int> tabulka2 = new List<int>();
            List<int> tabulka3 = new List<int>();
            int posledniSoucet = 90000000;
            int nynejsiSoucet = 0;

            while (!string.IsNullOrWhiteSpace(line))
            {
                lineCislo = Convert.ToInt32(line);

                if (tabulka1.Count == 0 && tabulka2.Count == 0 && tabulka3.Count == 0)
                {
                    tabulka1.Add(lineCislo);
                }
                else if (tabulka2.Count == 0 && tabulka3.Count == 0)
                {
                    tabulka1.Add(lineCislo);
                    tabulka2.Add(lineCislo);
                }
                else
                {
                    tabulka1.Add(lineCislo);
                    tabulka2.Add(lineCislo);
                    tabulka3.Add(lineCislo);

                    if (tabulka1.Count == 3)
                    {
                        nynejsiSoucet = 0;
                        foreach (int num in tabulka1)
                        {
                            nynejsiSoucet = nynejsiSoucet + num;
                        }
                        tabulka1 = new List<int>();

                    }
                    else if (tabulka2.Count == 3)
                    {
                        nynejsiSoucet = 0;
                        foreach (int num in tabulka2)
                        {
                            nynejsiSoucet = nynejsiSoucet + num;
                        }
                        tabulka2 = new List<int>();
                    }
                    else if (tabulka3.Count == 3)
                    {
                        nynejsiSoucet = 0;
                        foreach (int num in tabulka3)
                        {
                            nynejsiSoucet = nynejsiSoucet + num;
                        }
                        tabulka3 = new List<int>();
                    }

                    if (nynejsiSoucet > posledniSoucet)
                    {
                        vyskyty++;
                    }
                    posledniSoucet = nynejsiSoucet;
                }

                line = reader.ReadLine();
            }
            Console.WriteLine(vyskyty);
        }

        static void DayTwoFirst(bool test)
        {

        }

        static void DayTwoSecond(bool test)
        {

        }

        static void DayThreeFirst(bool test)
        {

        }

        static void DayThreeSecond(bool test)
        {

        }
    }
}
