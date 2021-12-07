using System;
using System.Collections.Generic;
using System.Text;

namespace AdventOfCode
{
    class Fish
    {
        public int Age { get; private set; }
        public Fish(int age)
        {
            Age = age;
        }
        public Fish()
        {
            Age = 8;
        }
        public Fish CountAge()
        {
            switch (Age)
            {
                case 0:
                    Age = 6;
                    return new Fish();
                default:
                    Age--;
                    break;
            }
            return null;
        }
    }
}
