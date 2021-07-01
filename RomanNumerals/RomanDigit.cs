using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals
{
    public class RomanDigit
    {
        private static List<RomanDigit> RomanDigits = new List<RomanDigit>()
        {
            new RomanDigit("I", 1, 3),
            new RomanDigit("V", 5, 1),
            new RomanDigit("X", 10, 3),
            new RomanDigit("L", 50, 1),
            new RomanDigit("C", 100, 3),
            new RomanDigit("D", 500, 1),
            new RomanDigit("M", 1000, 3),
            new RomanDigit("_I", 1_000, 3),
            new RomanDigit("_V", 5_000, 1),
            new RomanDigit("_X", 10_000, 3),
            new RomanDigit("_L", 50_000, 1),
            new RomanDigit("_C", 100_000, 3),
            new RomanDigit("_D", 500_000, 1),
            new RomanDigit("_M", 1_000_000, 3)
        };

        private static Dictionary<string, RomanDigit> RomanDigitsPerSymbol = RomanDigits.ToDictionary(
            keySelector: digit => digit.Symbol,
            elementSelector: digit => digit);

        public static bool TryParse(string text, out RomanDigit romanDigit)
        {
            romanDigit = null;

            if (RomanDigitsPerSymbol.ContainsKey(text))
            {
                romanDigit = RomanDigitsPerSymbol[text];
            }

            return romanDigit != null;
        }

        public string Symbol { get; }

        public int Value { get; }

        public int MaxSucessiveRepetition { get; }

        private RomanDigit(string symbol, int value, int maxSuccessiveRepetition)
        {
            this.Symbol = symbol;
            this.Value = value;
            this.MaxSucessiveRepetition = maxSuccessiveRepetition;
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
