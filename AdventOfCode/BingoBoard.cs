using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class BingoBoard
    {
        public List<List<Number>> Numbers { get; set; }
        public BingoBoard()
        {
            Numbers = new List<List<Number>>();
        }
    }

    class Number
    {
        public int Value { get; }
        public bool Marked { get; set; }

        public Number(int value)
        {
            Marked = false;
            Value = value;
        }
    }
}
