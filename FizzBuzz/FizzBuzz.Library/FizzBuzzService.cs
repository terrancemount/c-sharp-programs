using System;

namespace FizzBuzz.Library
{
    public class FizzBuzzService
    {
        public string Print(int n)
        {   
            if(n % 5 == 0 &&  n % 3 == 0)
            {
                return "FizzBuzz";
            }
            else if(n % 3 == 0)
            {
                return "Fizz";
            }
            else if(n % 5 == 0 )
            {
                return "Buzz";
            }
            return n.ToString();
        }
    }
}
