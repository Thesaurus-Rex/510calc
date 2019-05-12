using FluentAssertions;
using System;
using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    public class CalculatorTests
    {
        //success tests
        [Fact]
        public void Calculator_Add_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Add(first, second);
            result.Should().Be(24, "Because addition...");
        }


    [Fact]
        public void Calculator_Sub_Success()
        {
            var calc = new Calculator();
            var first = 10;
            var second = 5;
            var result = calc.Subtract(first, second);
            result.Should().Be(5, "Because subtraction");
        }


        [Fact]
        public void Calculator_Mult_Success()
        {
            var calc = new Calculator();
            var first = 12;
            var second = 12;
            var result = calc.Multiply(first, second);
            result.Should().Be(144, "Because multiplication...");
        }



 [Fact]
        public void Calculator_Div_Success()
        {
            var calc = new Calculator();
            var first = 10;
            var second = 5;
            var result = calc.Divide(first, second);
            result.Should().Be(2, "Because division");
        }

 [Fact]
        public void Calculator_Exp_Success()
        {
            var calc = new Calculator();
            var first = 10;
            var second = 5;
            var result = calc.Power(first, second);
            result.Should().Be(100000, "Because exponents");
        }


        [Fact]
        public void Calculator_Div_by_Zero()
        {
             var calc = new Calculator();
             var first = 12;
             var second = 0;
             Action fail = () => calc.Divide(first, second);
             fail.Should().Throw<Exception>().WithMessage("Value*");
        }
    }
    
}
