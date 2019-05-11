using FluentAssertions;
using Xunit;
using System.Diagnostics.CodeAnalysis;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    public class CalculatorTests
    {
        [Fact]
        public void Calculator_Add_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Add(first, second);
            result.Should().Be(24, "Because addition...");
        }
    }
}
