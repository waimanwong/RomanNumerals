using FluentAssertions;
using System;
using Xunit;

namespace RomanNumerals.UniTests
{
    public class RomanDigitTests
    {
        [Theory]
        [InlineData('I', 1)]
        [InlineData('V', 5)]
        [InlineData('X', 10)]
        [InlineData('L', 50)]
        [InlineData('C', 100)]
        [InlineData('D', 500)]
        [InlineData('M', 1000)]
        public void TryParse_Should_Return_True_For_Valid_Symbols(char symbol, int expectedValue)
        {
            //Arrange

            //Act
            var isValidRomanDigit = RomanDigit.TryParse(symbol, out var romanDigit);

            //Assert
            isValidRomanDigit.Should().BeTrue();
            romanDigit.Value.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData('i')]
        [InlineData('a')]
        [InlineData('z')]
        public void TryParse_Should_Return_False_For_Invalid_Symbols(char invalidSymbol)
        {
            //Arrange

            //Act
            var isValidRomanDigit = RomanDigit.TryParse(invalidSymbol, out var romanDigit);

            //Assert
            isValidRomanDigit.Should().BeFalse();
            romanDigit.Should().BeNull();
        }

        [Fact]
        public void LessOrEqualTo_Operator_Should_Compare_RomanDigits()
        {
            //Arrange
            RomanDigit.TryParse('I', out var small);
            RomanDigit.TryParse('C', out var large);

            //Act and assert
            (small <= large).Should().BeTrue();
        }

        [Fact]
        public void GreaterOrEqualTo_Operator_Should_Compare_RomanDigits()
        {
            //Arrange
            RomanDigit.TryParse('I', out var small);
            RomanDigit.TryParse('C', out var large);

            //Act and assert
            (large >= small).Should().BeTrue();
        }

        [Fact]
        public void ImplicitConversion_Should_Convert_To_String()
        {
            //Arrange
            RomanDigit.TryParse('D', out var one);

            //Act
            string text = one;

            //Assert
            text.Should().Be("D");
        }

        [Theory]
        [InlineData('I', 1)]
        [InlineData('V', 5)]
        [InlineData('X', 10)]
        [InlineData('L', 50)]
        [InlineData('C', 100)]
        [InlineData('D', 500)]
        [InlineData('M', 1000)]
        public void ImplicitConversion_Should_Convert_To_Int(char symbol, int expectedValue)
        {
            //Arrange
            RomanDigit.TryParse(symbol, out var digit);

            //Act
            int actualValue = digit;

            //Assert
            actualValue.Should().Be(expectedValue);
        }
    }
}
