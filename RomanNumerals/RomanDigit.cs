using System;
using System.Collections.Generic;

namespace RomanNumerals
{
    public class RomanDigit
    {
        private static Dictionary<char, int> ConversionTable = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        public static bool TryParse(char c, out RomanDigit romanDigit)
        {
            romanDigit = null;

            if (ConversionTable.ContainsKey(c))
            {
                romanDigit = new RomanDigit(c);
            }

            return romanDigit != null;
        }

        public char Symbol { get; }

        public int Value => ConversionTable[this.Symbol];

        private RomanDigit(char c)
        {
            this.Symbol = c;
        }

        public static bool operator <= (RomanDigit left, RomanDigit right) 
            => left.Value <= right.Value;
        
        public static bool operator >= (RomanDigit left, RomanDigit right)
            => left.Value >= right.Value;

        public static implicit operator string (RomanDigit romanDigit) 
            => romanDigit.ToString();

        public static implicit operator int(RomanDigit romanDigit)
            => romanDigit.Value;

        public override string ToString()
        {
            return new string(new[] { this.Symbol });
        }
    }
}
