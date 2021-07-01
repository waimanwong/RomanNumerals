using FluentAssertions;
using Xunit;

namespace RomanNumerals.UniTests
{
    public class RomanNumberTests
    {   
        [Theory]
        [InlineData("acdef")]
        public void TryParse_Should_Return_False_For_Invalid_Text(string invalidText)
        {
            //Arrange 

            //Act
            var isValidRomanNumber = RomanNumber.TryParse(invalidText, out RomanNumber romanNumber);

            //Assert
            isValidRomanNumber.Should().BeFalse();
            romanNumber.Should().BeNull();
        }

        [Theory]
        [InlineData("I")]
        [InlineData("MMXXI")]
        public void TryParse_Should_Return_True_For_Valid_Text(string validText)
        {
            //Arrange 

            //Act
            var isValidRomanNumber = RomanNumber.TryParse(validText, out RomanNumber romanNumber);

            //Assert
            isValidRomanNumber.Should().BeTrue();
            romanNumber.ToString().Should().Be(validText);
        }

        [Theory]
        [InlineData("III", 3)]
        [InlineData("VI" , 6)]
        [InlineData("VII", 7)]
        [InlineData("XI", 11)]
        [InlineData("XVI", 16)]
        [InlineData("LXV", 65)]
        public void Value_Should_Should_Support_Additive_Notation(string text, int expectedValue)
        {
            //Arrange 
            RomanNumber.TryParse(text, out RomanNumber romanNumber);

            //Act
            var actualValue = romanNumber.Value;

            //Assert
            actualValue.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("XIV", 14)]
        [InlineData("XXIX", 29)]
        [InlineData("CLIX", 159)]
        public void Value_Should_Should_Support_Substractive_Notation(string text, int expectedValue)
        {
            //Arrange 
            RomanNumber.TryParse(text, out RomanNumber romanNumber);

            //Act
            var actualValue = romanNumber.Value;

            //Assert
            actualValue.Should().Be(expectedValue);
        }

        [Theory]
        [InlineData("XXXX")]
        [InlineData("XIIII")]
        [InlineData("MMMM")]
        public void TryParse_Should_Return_False_When_Digits_Are_Repeated_More_Than_Three_Times(string text)
        {
            //Arrange 
            
            //Act
            var isValid = RomanNumber.TryParse(text, out RomanNumber romanNumber);

            //Assert
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("VV")]
        [InlineData("LL")]
        [InlineData("DD")]
        public void TryParse_Should_Return_False_When_V_Or_L_Or_D_Are_Repeated_In_Succession(string text)
        {
            //Arrange 

            //Act
            var isValid = RomanNumber.TryParse(text, out RomanNumber romanNumber);

            //Assert
            isValid.Should().BeFalse();
        }

        [Fact]
        public void TryParse_Should_Return_False_When_Underscore_Is_Repeated_In_Succession()
        {
            //Arrange 
            var text = "__C";

            //Act
            var isValid = RomanNumber.TryParse(text, out RomanNumber romanNumber);

            //Assert
            isValid.Should().BeFalse();
        }

        [Theory]
        [InlineData("_X_V")]
        [InlineData("_C_L_V")]
        public void TryParse_Should_Return_True_For_Vinculum_System_Form(string text)
        {
            //Arrange 
            
            //Act
            var isValid = RomanNumber.TryParse(text, out RomanNumber romanNumber);

            //Assert
            isValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("_X_V", 15_000)]
        [InlineData("_C_L_V", 155_000)]
        [InlineData("_I_VDCXXVII", 4_627)]
        [InlineData("_X_X_V", 25_000)]
        [InlineData("_X_X_VCDLIX", 25_459)]
        [InlineData("_M_M_M_C_M_X_C_I_XCMXCIX", 3_999_999)] //largest vinculum number
        public void Value_Should_Support_Vinculum_System_Form(string text, int expectedValue)
        {
            //Arrange 
            RomanNumber.TryParse(text, out RomanNumber romanNumber);

            //Act
            var actualValue = romanNumber.Value;

            //Assert
            actualValue.Should().Be(expectedValue);
        }
    }
}
