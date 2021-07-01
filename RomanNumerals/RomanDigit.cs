using System;
using System.Collections.Generic;

namespace RomanNumerals
{
    public class RomanDigit
    {
        private static Dictionary<string, int> ConversionTable = new Dictionary<string, int>
        {
            { "I", 1 },
            { "V", 5 },
            { "X", 10 },
            { "L", 50 },
            { "C", 100 },
            { "D", 500 },
            { "M", 1000 },
            // Vinculum system
            { "_I", 1_000 },
            { "_V", 5_000 },
            { "_X", 10_000 },
            { "_L", 50_000 },
            { "_C", 100_000 },
            { "_D", 500_000 },
            { "_M", 1_000_000 },
        };

        public static bool TryParse(string text, out RomanDigit romanDigit)
        {
            romanDigit = null;

            if (ConversionTable.ContainsKey(text))
            {
                romanDigit = new RomanDigit(text);
            }

            return romanDigit != null;
        }

        public string Symbol { get; }

        public int Value => ConversionTable[this.Symbol];

        private RomanDigit(string text)
        {
            this.Symbol = text;
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
            return this.Symbol;
        }
    }
}
