using UnityEngine;

namespace DefaultNamespace
{
    public class BitwiseOperationHacks
    {
        int Add(int a, int b) 
        { 
            while (b != 0) 
            { 
                int c = a & b;   
                a = a ^ b;  
                b = c << 1; 
            } 
            return a; 
        }

        int Subtract(int a, int b)
        {
            { 
                while (b != 0) 
                { 
                    int borrow = (~a) & b; 
                    a = a ^ b; 
                    b = borrow << 1; 
                } 
                return a; 
            } 
        }
        
        int Multiply(int n, int m) 
        {   
            int answer = 0; 
            int count = 0; 
            while (m != 0) 
            { 
                if (m % 2 == 1)               
                    answer += n << count; 
                count++; 
                m /= 2; 
            } 
            return answer; 
        }

        void Division()
        {
            int remainder = 0; 
 
            int division(int dividend, int divisor) 
            { 
                int quotient = 1; 
                int neg = 1; 
    
                if ((dividend > 0 && divisor < 0) || (dividend < 0 && divisor > 0)) 
                    neg = -1; 
 
                // Convert to positive 
                int tempdividend = Mathf.Abs((dividend < 0) ? -dividend : dividend); 
                int tempdivisor = Mathf.Abs((divisor < 0) ? -divisor : divisor); 
 
                if (tempdivisor == tempdividend) 
                { 
                    remainder = 0; 
                    return 1 * neg; 
                } 
                else if (tempdividend < tempdivisor) 
                { 
                    if (dividend < 0) 
                        remainder = tempdividend * neg; 
                    else 
                        remainder = tempdividend; 
                    return 0; 
                } 
    
                while (tempdivisor << 1 <= tempdividend) 
                { 
                    tempdivisor = tempdivisor << 1; 
                    quotient = quotient << 1; 
                } 
 
                // Call division recursively 
                if (dividend < 0) 
                    quotient = quotient * neg + division(-(tempdividend - tempdivisor), divisor); 
                else 
                    quotient = quotient * neg + division(tempdividend - tempdivisor, divisor); 
                return quotient; 
            }
        }

        void CounterWrapping(object screen)
        {
            // for( int x = 0, u = 0; x < screen.width; x++, u++ )
            // {
            //     for( int y = 0, v = 0; y < screen.height; y++, v++ )
            //     {
            //         int colour = image.getPixel( u, v );
            //         screen.setPixel( x, y, colour );
            //
            //         // Make sure we don't go outside the image boundary.
            //         if( u >= image.width )
            //             u = 0;
            //         if( v >= image.height )
            //             v = 0;
            //     }
            // }
        }        
        
        void CounterWrapping2(object screen)
        {
            // Assumes image dimensions are powers of 2.
            // object image;
            // int widthMask = image.width - 1;
            // int heightMask = image.height - 1;
            //
            // for( int x = 0; x < screen.width; x++ )
            // {
            //     for( int y = 0; x < screen.height; y++ )
            //     {   
            //         int colour = image.getPixel( x & widthMask, y & heightMask );
            //         screen.setPixel( x, y, colour );
            //     }
            // } 
        }

        void SwapValues(int x, int y)
        {
            var temp = x;
            var X = y;
            var Y = temp;
            
            x ^= y;
            y ^= x;
            x ^= y;
        }

        bool haveSameSign(int x, int y)
        {
            bool haveSameSign = 0 <= (x ^ y);
            return haveSameSign;
        }

        void FindMinAndMax(int x, int y)
        {
            int max = x ^ ((x ^ y) & -((x < y)?1:0));
            int min = y ^ ((x ^ y) & -((x < y)?1:0));
        }
        
    }
}