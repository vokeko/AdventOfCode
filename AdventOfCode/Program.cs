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
            if (number > 0 && number < 4)
                day = number;

            Console.WriteLine("Zadejte úkol (P pro první)");
            if (Console.ReadKey().Key == ConsoleKey.P )
                first = true;

            Console.WriteLine();
            Console.WriteLine("T pro test");
            if (Console.ReadKey().Key == ConsoleKey.T)
                test = true;

            Console.WriteLine();

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
            Console.ReadKey();
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
            string path = "day2.txt";
            if (test)
                path = "day2_test.txt";
            StreamReader reader = new StreamReader(path);
            long depth = 0;
            long position = 0;
            string[] splitLine;
            string line = reader.ReadLine();

            while (line != null)
            {
                splitLine = line.Split(" ");
                switch (splitLine[0])
                {
                    case "forward":
                        position += Convert.ToInt64(splitLine[1]);
                        break;
                    case "up":
                        depth -= Convert.ToInt64(splitLine[1]);
                        break;
                    case "down":
                        depth += Convert.ToInt64(splitLine[1]);
                        break;
                }
                line = reader.ReadLine();
            }
            Console.WriteLine("Pozice: " + position);
            Console.WriteLine("Hloubka: " + depth);
            Console.WriteLine("Výsledek: " + (position * depth));
        }

        static void DayTwoSecond(bool test)
        {
            string path = "day2.txt";
            if (test)
                path = "day2_test.txt";
            StreamReader reader = new StreamReader(path);
            long depth = 0;
            long position = 0;
            string[] splitLine;
            long aim = 0;
            string line = reader.ReadLine();

            while (line != null)
            {
                splitLine = line.Split(" ");
                switch (splitLine[0])
                {
                    case "forward":
                        position += Convert.ToInt64(splitLine[1]);
                        depth += aim * Convert.ToInt64(splitLine[1]);
                        break;
                    case "up":
                        aim -= Convert.ToInt64(splitLine[1]);
                        break;
                    case "down":
                        aim += Convert.ToInt64(splitLine[1]);
                        break;
                }
                line = reader.ReadLine();
            }
            Console.WriteLine("Pozice: " + position);
            Console.WriteLine("Hloubka: " + depth);
            Console.WriteLine("Namíření: " + aim);
            Console.WriteLine("Výsledek: " + (position * depth));
        }

        static void DayThreeFirst(bool test)
        {
            string path = "day3.txt";
            if (test)
                path = "day3_test.txt";
            StreamReader reader = new StreamReader(path);

            string readLine = reader.ReadLine();
            string gamma = "";
            string epsilon = "";
            List<char[]> lines = new List<char[]>();
            while (readLine != null)
            {
                lines.Add(readLine.ToCharArray());
                readLine = reader.ReadLine();
            }

            for (int i = 0; i < lines[0].Length; i++)
            {
                int ones = 0;

                for (int j = 0; j < lines.Count; j++)
                {
                    if (lines[j][i] == '1')
                        ones++;
                }

                if (ones > lines.Count/2)
                {
                    gamma += "1";
                    epsilon += "0";
                }
                else
                {
                    gamma += "0";
                    epsilon += "1";
                }
            }

            int gammaInt = Convert.ToInt32(gamma, 2);
            int epsilonInt = Convert.ToInt32(epsilon, 2);
            Console.WriteLine("Gamma: " + gammaInt);
            Console.WriteLine("Epsilon: " + epsilonInt);
            Console.WriteLine("Spotřeba energie: " + (gammaInt * epsilonInt));
        }

        static void DayThreeSecond(bool test)
        {

        }
    }
}
