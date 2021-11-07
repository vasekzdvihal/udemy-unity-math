using System;

namespace DefaultNamespace
{
    public class BitwiseOperations
    {
        public static void Complement()
        {
            // The ~ operator produces a bitwise complement of its operand by reversing each bit:
            uint a = 0b_0000_1111_0000_1111_0000_1111_0000_1100;
            uint b = ~a;
            Console.WriteLine(Convert.ToString(b, 2)); // 11110000111100001111000011110011
        }

        public static void LogicalAND()
        {
            // The & operator computes the bitwise logical AND of its integral operands:
            uint a = 0b_1111_1000; 
            uint b = 0b_1001_1101; 
            uint c = a & b;
            Console.WriteLine(Convert.ToString(c, 2)); // 10011000
        }

        public static void LogicalExclusiveOR()
        {
            // The ^ operator computes the bitwise logical exclusive OR, also known as the bitwise logical XOR, of its integral operands:
            uint a = 0b_1111_1000;
            uint b = 0b_0001_1100;
            uint c = a ^ b;
            Console.WriteLine(Convert.ToString(c, toBase: 2)); // 11100100
        }

        public static void LogicalOR()
        {
            // The | operator computes the bitwise logical OR of its integral operands:
            uint a = 0b_1010_0000;
            uint b = 0b_1001_0001;
            uint c = a | b;
            Console.WriteLine(Convert.ToString(c, toBase: 2)); // 10110001
        }

        public static void WithCompound()
        {
            uint INITIAL_VALUE = 0b_1111_1000;

            uint a = INITIAL_VALUE;
            a &= 0b_1001_1101; 
            Display(a);  // output: 10011000

            a = INITIAL_VALUE;
            a |= 0b_0011_0001; 
            Display(a);  // output: 11111001

            a = INITIAL_VALUE;
            a ^= 0b_1000_0000;
            Display(a);  // output: 1111000

            a = INITIAL_VALUE;
            a <<= 2;
            Display(a);  // output: 1111100000

            a = INITIAL_VALUE;
            a >>= 4;
            Display(a);  // output: 1111

            void Display(uint x) => Console.WriteLine($"{Convert.ToString(x, toBase: 2), 8}");
        }
    }
}