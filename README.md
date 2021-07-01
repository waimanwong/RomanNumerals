# RomanNumerals
Console application to convert from roman numerals to arabic numerals.

It supports [Vinculum notation](https://en.wikipedia.org/wiki/Roman_numerals#Vinculum) by using '_', eg: _I means 1000, _V 5000, ...

## Design
I take a DDD approach and modeled two [value objects](https://lostechies.com/jimmybogard/2007/12/03/dealing-with-primitive-obsession/):

``RomanDigit`` holds the list of supported symbols, the their corresponding value and the maximum successive repetition count.

``RomanNumber`` contains the logic of the string parser and the logic to compute the numeric value.

The first version supported 1 ```char``` symbol and a roman digit holds the symbol as one ```char```.

Then I added the vinculum notation. A refactoring was necessary to support symbol as a ```string``` as well as the parsing of the input text.
