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

        public static void LeftShift()
        {
            // The << operator shifts its left-hand operand left by the number of bits defined by its right-hand operand.
            // The left-shift operation discards the high-order bits that are outside the range of the result type and sets the low-order empty
            // bit positions to zero, as the following example shows:
            
            uint x = 0b_1100_1001_0000_0000_0000_0000_0001_0001;
            Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2)}"); // 11001001000000000000000000010001

            uint y = x << 4;
            Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2)}"); // 10010000000000000000000100010000
        }

        public static void RightShift()
        {
            // The >> operator shifts its left-hand operand right by the number of bits defined by its right-hand operand.
            // The right-shift operation discards the low-order bits, as the following example shows:
            
            uint x = 0b_1001; 
            Console.WriteLine($"Before: {Convert.ToString(x, toBase: 2), 4}"); // 1001

            uint y = x >> 2;
            Console.WriteLine($"After:  {Convert.ToString(y, toBase: 2), 4}"); // 10
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