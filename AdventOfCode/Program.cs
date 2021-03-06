using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            bool test = false;
            uint day = 1;
            bool first = false;

            Console.WriteLine("Zadejte den (1-25)");
            uint number = Convert.ToUInt32(Console.ReadLine());
            if (number > 0 && number <= 25)
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
                        DayThreeSecond();
                    break;
                case 4:
                    if (first)
                        DayFourFirst(test);
                    else
                        DayFourSecond();
                    break;
                case 5:
                    DayFive(test, first);
                    break;
                case 6:
                    DaySix(test);
                    break;
                case 7:
                    DaySevenFirst(test);
                    break;
                case 11:
                    DayEleven(first);
                    break;
                case 14:
                    DayFourteen(test);
                    break;
                default:
                    Console.WriteLine("Není vybrán hotový den");
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

        static void DayThreeSecond()
        {

        }

        static void DayFourFirst(bool test)
        {
            string path = "day4.txt";
            if (test)
                path = "day4_test.txt";
            StreamReader reader = new StreamReader(path);

            int[] winningNumbers = Array.ConvertAll(reader.ReadLine().Split(','), int.Parse);
            List<BingoBoard> boards = new List<BingoBoard>();
            string line = reader.ReadLine();
            BingoBoard board = null;

            while (line != null)
            {
                if (line == "")
                {
                    if (board != null)
                        boards.Add(board);
                    board = new BingoBoard();
                }
                else
                {
                    List<Number> temporaryClassNumbers = new List<Number>();
                    string temporaryLine = line.Replace("  ", " ");
                    if (temporaryLine[0] == ' ')
                        temporaryLine = temporaryLine.Remove(0, 1);

                    foreach (int tempNumber in Array.ConvertAll(temporaryLine.Split(' '), int.Parse))
                    {
                        temporaryClassNumbers.Add(new Number(tempNumber));
                    }
                    board.Numbers.Add(temporaryClassNumbers);
                }
                line = reader.ReadLine();
            }
            boards.Add(board);

            BingoBoard winningBoard = null;
            int winningNumber = -1;

            foreach (int currentNumber in winningNumbers)
            {
                //num = winningNumber
                foreach (BingoBoard board1 in boards)
                {
                    //checks whether number is in any boards, if yes then it marks it
                    foreach (List<Number> numberList in board1.Numbers)
                    {
                        if (numberList.Contains(new Number(currentNumber)))
                        {
                            foreach (Number number in numberList)
                            {
                                if (number.Value == currentNumber)
                                    number.Marked = true;
                            }
                        }
                    }
                }

                //If bingo, then break and copy board
                foreach (BingoBoard board1 in boards)
                {
                    foreach (List<Number> numberList in board1.Numbers)
                    {
                        uint bingoLine = 0;
                        foreach (Number number in numberList)
                        {
                            if (number.Marked == true)
                                bingoLine++;
                        }
                        if (bingoLine == numberList.Count)
                            winningBoard = board1;
                    }

                    for (int x = 0; x < board1.Numbers.Count; x++)
                    {
                        uint bingoColumn = 0;

                        foreach (Number number in board1.Numbers[x])
                        {
                            if (number.Marked == true)
                                bingoColumn++;
                        }

                        if (bingoColumn == board1.Numbers.Count)
                            winningBoard = board1;
                    }
                }

                if (winningBoard != null)
                {
                    winningNumber = currentNumber;
                    break;
                }

            }
            //count number from bingoboard
            if (winningNumber >= 0)
            {
                Console.WriteLine("Vítězná deska: " + winningBoard);
                Console.WriteLine("Vítězné číslo: " + winningNumber);

                int total = 0;

                foreach (List<Number> numberList in winningBoard.Numbers)
                {
                    foreach (Number number in numberList)
                    {
                        if (number.Marked == false)
                        {
                            total += number.Value;
                        }
                    }
                }

                Console.WriteLine("Výsledek: " + total);
            }
            else
            {
                Console.WriteLine("Nic nevyhrálo?!?");
            }
            Console.ReadKey();
        }

        static void DayFourSecond()
        {

        }

        static void DayFive(bool test, bool first)
        {
            string path = "day5.txt";
            if (test)
                path = "day5_test.txt";
            StreamReader reader = new StreamReader(path);

            string line = reader.ReadLine();
            Dictionary<int[], int[]> fromTo = new Dictionary<int[], int[]>();
            int[,] board = new int[1000, 1000];
            int overlaps = 0;

            while (line != null)
            {
                string[] tempLine = line.Replace(" -> ", "-").Split('-');
                string[] tempFirst = tempLine[0].Split(',');
                string[] tempSecond = tempLine[1].Split(',');

                if (first && (tempFirst[0] == tempSecond[0] || tempFirst[1] == tempSecond[1]))
                     fromTo.Add(new int[] { Convert.ToInt32(tempFirst[0]), Convert.ToInt32(tempFirst[1]) }, new int[] { Convert.ToInt32(tempSecond[0]), Convert.ToInt32(tempSecond[1]) });
                //tahle linka je rozdíl solution mezi 5_1 a 5_2
                line = reader.ReadLine();
            }

            foreach (KeyValuePair<int[], int[]> pair in fromTo)
            {
                List<int[]> directions = convertDirections(pair);

                foreach (int[] moveHere in directions)
                {
                    board[moveHere[0], moveHere[1]]++;
                }
            }

            foreach (int value in board)
            {
                if (value > 1)
                    overlaps++;

            }
            //for (int y = 0; y < 20; y++)
            //{
            //    for (int x = 0; x < 20; x++)
            //    {
            //        Console.Write(board[x, y]);
            //    }
            //    Console.WriteLine("");
            //}
            //vypsání překrytí

            Console.WriteLine("Překrytí: " + overlaps);
        }

        static void DaySix(bool test)
        {
            Console.WriteLine("Počet dnů?");
            int days = Convert.ToInt32(Console.ReadLine());

            string path = "day6.txt";
            if (test)
                path = "day6_test.txt";
            StreamReader reader = new StreamReader(path);
            List<Fish> lanternFishList = new List<Fish>();

            foreach (int lanternFishNumber in Array.ConvertAll(reader.ReadLine().Split(','), int.Parse))
            {
                lanternFishList.Add(new Fish(lanternFishNumber));
            }

            for (int i = 0; i < days; i++)
            {
                List<Fish> fishChildren = new List<Fish>();

                foreach (Fish lanternFish in lanternFishList)
                {
                    Fish fishChild = lanternFish.CountAge();
                    if (fishChild != null)
                        fishChildren.Add(fishChild);
                }
                if (fishChildren.Count > 0)
                    lanternFishList.AddRange(fishChildren);
            }
            Console.WriteLine(string.Format("Za {0} dní je ryb:", days));
            Console.WriteLine(lanternFishList.Count);
        }

        static void DaySevenFirst(bool test)
        {
            string path = "day7.txt";
            if (test)
                path = "day7_test.txt";
            StreamReader reader = new StreamReader(path);

            int[] crabPositions = Array.ConvertAll(reader.ReadLine().Split(','), int.Parse);
            int max = crabPositions.Max();
            int min = crabPositions.Min();
            List<int> fuelCosts = new List<int>();

            for (int x = 0; x < max; x++)
            {
                int fuelCost = 0;
                if (x < min)
                    continue;

                foreach (int crabPosition in crabPositions)
                {
                    fuelCost += Math.Abs(crabPosition - x);
                }
                fuelCosts.Add(fuelCost);
            }

            if (fuelCosts.Count > 0)
            {
                Console.WriteLine("Nejvýhodnější cena:" + fuelCosts.Min());
            }
            else
            {
                Console.WriteLine("Chyba");
            }
        }

        static void DayEleven(bool first)
        {
            int steps = 90000;

            if (first)
            {
                Console.WriteLine("Zadejte počet kroků: ");
                steps = Convert.ToInt32(Console.ReadLine());
            }

            int flashes = 0;
            StreamReader reader1 = new StreamReader("day11.txt");
            string line = reader1.ReadLine();
            GlowSquid[,] board = new GlowSquid[10, 10];
            int y = 0;
            while (line != null)
            {
                int x = 0;
                foreach (char c in line)
                {
                    board[x, y] = new GlowSquid(x, y, int.Parse(Convert.ToString(c)));
                    x++;
                }
                y++;
                line = reader1.ReadLine();
            }

            for (int currentStep = 0; currentStep < steps; currentStep++)
            {
                foreach (GlowSquid squid in board)
                {
                    squid.AddOne(false);
                }

                foreach (GlowSquid squid in board)
                {
                    if (squid.Energy >= 10)
                    {
                        squid.AddOne(true);
                        flashes++;
                        var temp = flashThese(squid.X, squid.Y, board, flashes);
                        board = (GlowSquid[,])temp[0];
                        flashes = (int)temp[1];
                    }
                }
                bool synchro = true;
                foreach (GlowSquid squid in board)
                {
                    if (squid.Energy != 0)
                    {
                        synchro = false;
                        break;
                    }

                }
                if (synchro)
                {
                    steps = currentStep + 1;
                    break;
                }

            }

            for (int y2 = 0; y2 < 10; y2++)
            {
                for (int x2 = 0; x2 < 10; x2++)
                {
                    Console.Write(board[x2, y2].Energy);
                }
                Console.WriteLine("");
            }

            Console.WriteLine("");
            Console.WriteLine("Zablísknutí: " + flashes);
            Console.WriteLine("První synchronizace: " + steps);
        }

        static void DayFourteen(bool test)
        {
            string path = "day14.txt";
            if (test)
                path = "day14_test.txt";

            StreamReader reader = new StreamReader(path);
            string template = reader.ReadLine();
            reader.ReadLine();
            string line = reader.ReadLine();

            Console.WriteLine("Počet kroků? 10 pro part 1 40 part 2");
            int steps = Convert.ToInt32(Console.ReadLine());

            Dictionary<string, string> rules = new Dictionary<string, string>();
            Dictionary<char, int> elementRarity = new Dictionary<char, int>();

            while (line != null)
            {
                string[] tempLine = line.Replace(" -> ", "-").Split('-');
                rules.Add(tempLine[0], tempLine[1]);
                line = reader.ReadLine();
            }

            foreach (char c in template)
            {
                elementRarity = addToDictionary(c, elementRarity);
            }

            for (int i = 0; i < steps; i++)
            {
                for (int j = 0; j < template.Length - 1; j++)
                {
                    string substring = template.Substring(j, 2);
                    string insertElement = rules[substring];
                    if (insertElement != "")
                    {
                        j++;
                        template = template.Insert(j, insertElement);
                        elementRarity = addToDictionary(Convert.ToChar(insertElement), elementRarity);
                    }
                }
            }
            int min = elementRarity.Values.Min();
            int max = elementRarity.Values.Max();

            Console.WriteLine(template);
            Console.WriteLine();
            Console.WriteLine("Délka: " + template.Length);
            Console.WriteLine("Max: " + max);
            Console.WriteLine("Min: " + min);
            Console.WriteLine("Výsledek: " + (max - min));

            Console.ReadKey();
        }

        #region special functions

        static List<int[]> convertDirections(KeyValuePair<int[], int[]> pair)
        {
            List<int[]> convertedDirections = new List<int[]>();
            int x = pair.Key[0];
            int y = pair.Key[1];
            convertedDirections.Add(new int[2] { x, y });

            while (x != pair.Value[0] || y != pair.Value[1])
            {
                if (x < pair.Value[0])
                    x++;
                if (x > pair.Value[0])
                    x--;
                if (y < pair.Value[1])
                    y++;
                if (y > pair.Value[1])
                    y--;

                convertedDirections.Add(new int[2] { x, y });
            }

            return convertedDirections;
        }

        static List<int[]> calculateSpaces(int x, int y, GlowSquid[,] board)
        {
            List<int[]> validSpaces = new List<int[]>();

            for (int _y = y - 1; _y < y + 2; _y++)
            {

                for (int _x = x - 1; _x < x + 2; _x++)
                {
                    if ((_x != x || _y != y) && (_y >= 0 && _x >= 0 && _x < 10 && _y < 10))
                    {
                        validSpaces.Add(new int[] { _x, _y });
                    }
                }
            }

            return validSpaces;
        }

        static object[] flashThese(int x, int y, GlowSquid[,] board, int flashes)
        {
            List<int[]> spaces = calculateSpaces(x, y, board);
            foreach (int[] space in spaces)
            {
                if (board[space[0], space[1]].AddOne(true))
                {
                    flashes++;
                    object[] temp = flashThese(space[0], space[1], board, flashes);
                    board = (GlowSquid[,])temp[0];
                    flashes = (int)temp[1];
                }
            }
            return new object[] { board, flashes };
        }

        static Dictionary<char, int> addToDictionary(char c, Dictionary<char, int> dictionary)
        {
            if (dictionary.ContainsKey(c))
                dictionary[c]++;
            else
                dictionary.Add(c, 1);
            return dictionary;
        }

        #endregion
    }

    #region classes
    class GlowSquid
    {
        public int X { get; }
        public int Y { get; }
        public int Energy { get; private set; }
        public GlowSquid(int _x, int _y, int _energy)
        {
            X = _x;
            Y = _y;
            Energy = _energy;
        }
        public bool AddOne(bool flashed)
        {
            if (flashed && Energy == 0) return false;

            Energy++;

            if (flashed == false) return false;

            if (Energy >= 10)
            {
                Energy = 0;
                return true;
            }
            return false;
        }
    }
    #endregion
}
