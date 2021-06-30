using System;
using System.Collections.Generic;
using System.Linq;

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

            var temporaryRomanNumber = new RomanNumber();

            var successiveRepetitionCount = 0;
            var repeatedChar = default(char);

            foreach(var c in text)
            {
                if (c == repeatedChar)
                {
                    successiveRepetitionCount++;
                }
                else
                {
                    repeatedChar = c;
                    successiveRepetitionCount = 1;
                }

                if(successiveRepetitionCount > 3)
                {
                    //No digit can be repeated more than 3 times in succession
                    return false;
                }
                else if (successiveRepetitionCount == 2 && 
                    (repeatedChar == 'V' || repeatedChar == 'L' || repeatedChar == 'D'))
                {
                    //V, L, D cannot be repeated
                    return false;
                }

                if(RomanDigit.TryParse(c, out var romanDigit))
                {
                    temporaryRomanNumber.AddDigit(romanDigit);
                }
                else
                {
                    return false;
                }
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
