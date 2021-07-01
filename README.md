# RomanNumerals
Console application to convert from roman numerals to arabic numerals

## Design
I take a DDD approach and modeled two value objects:

``RomanDigit`` holds the list of supported symbols and the their corresponding value.
``RomanNumber`` contains the logic of the string parser and the logic to compute the numeric value.
