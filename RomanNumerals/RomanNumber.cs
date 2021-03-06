using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RomanNumerals
{
    public class RomanNumber
    {
        private readonly List<RomanDigit> _romanDigits;

        public static bool TryParse(string text, out RomanNumber romanNumber)
        {
            romanNumber = null;

            if (string.IsNullOrEmpty(text))
            {
                return false;
            }

            var sanitizedText = text.Trim();

            var temporaryRomanNumber = new RomanNumber();

            var successiveRepetitionCount = 0;
            var repeatedSymbol = string.Empty;

            var symbolBuilder = new StringBuilder();

            foreach(var c in sanitizedText)
            {
                symbolBuilder.Append(c);

                if (c == '_') 
                {
                    continue;
                }

                var symbol = symbolBuilder.ToString();

                if(RomanDigit.TryParse(symbol, out var romanDigit))
                {
                    //Count repetition
                    if (symbol == repeatedSymbol)
                    {
                        successiveRepetitionCount++;
                    }
                    else
                    {
                        repeatedSymbol = symbol;
                        successiveRepetitionCount = 1;
                    }

                    //Check repetition of the digit against the maximul allowed
                    if (successiveRepetitionCount > romanDigit.MaxSucessiveRepetition)
                    {   
                        return false;
                    }
                    
                    temporaryRomanNumber.AddDigit(romanDigit);
                }
                else
                {
                    return false;
                }

                symbolBuilder.Clear();
            }
            romanNumber = temporaryRomanNumber;

            return true;
        }

        private RomanNumber()
        {
            _romanDigits = new List<RomanDigit>();
        }

        public void AddDigit(RomanDigit romanDigit)
        {
            _romanDigits.Add(romanDigit);
        }

        public override string ToString()
        {
            return string.Join(
                separator: "",
                value: this._romanDigits.Select(d => d.ToString()).ToArray());
        }

        /// <summary>
        /// Returns the corresponding integer value of the roman number. 
        /// </summary>
        public int Value  
        {
            get
            {
                var total = 0;

                for (int i = 0; i < _romanDigits.Count; i++)
                {
                    var currentRomanDigit = _romanDigits[i];

                    var isLastRomanDigit = (i == _romanDigits.Count - 1);

                    if (isLastRomanDigit)
                    {
                        total += currentRomanDigit;
                    }
                    else
                    {
                        var nextRomanDigit = _romanDigits[i + 1];
                        if (currentRomanDigit >= nextRomanDigit)
                        {
                            //Additive notation
                            total += currentRomanDigit;
                        }
                        else
                        {
                            //Substrative notation
                            total += (nextRomanDigit - currentRomanDigit);

                            //skip the next roman digit as it is already taken into account.
                            i++; 
                        }
                    }
                }

                return total;
            }
        }
    }
}
