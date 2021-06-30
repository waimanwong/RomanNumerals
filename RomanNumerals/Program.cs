using System;

namespace RomanNumerals
{
    class Program
    {
        static void Main(string[] args)
        {
           while(true)
            {
                Console.WriteLine("Please enter a roman number:");
                var text = Console.ReadLine();

                if(RomanNumber.TryParse(text, out var romanNumber))
                { 
                    Console.WriteLine(romanNumber.Value); 
                }
                else
                {
                    Console.WriteLine("Invalid text");
                }
            }
        }
    }
}
