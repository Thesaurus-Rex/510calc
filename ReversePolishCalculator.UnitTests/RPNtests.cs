
using System;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Generic;
using FileLogger;
using Xunit;
using FluentAssertions;
using FakeItEasy;
using FileLogger;

namespace ReversePolishCalculator
{
    [ExcludeFromCodeCoverage]
    public class RPNTests
    {



        [Fact]
        public void rpn_add_test()
        {
            var input = "12 + 12";
            var fakeLog = A.Fake<Logger>();
            var fakeCalc = A.Fake<Calculator>();
            var testRPN = new RpnEngine(fakeLog, fakeCalc);

            testRPN.CalculateRpn(input);
            A.CallTo(() => fakeCalc.Add(12, 12)).MustHaveHappened();
        }


        [Fact]
        public void rpn_sub_test()
        {
            var input = "10 - 5";
            var fakeLog = A.Fake<Logger>();
            var fakeCalc = A.Fake<Calculator>();
            var testRPN = new RpnEngine(fakeLog, fakeCalc);

            testRPN.CalculateRpn(input);
            A.CallTo(() => fakeCalc.Subtract(10, 5)).MustHaveHappened();
        }


        [Fact]
        public void rpn_mult_test()
        {
            var input = "12 * 12";
            var fakeLog = A.Fake<Logger>();
            var fakeCalc = A.Fake<Calculator>();
            var testRPN = new RpnEngine(fakeLog, fakeCalc);
            testRPN.CalculateRpn(input);

            A.CallTo(() => fakeCalc.Multiply(12, 12)).MustHaveHappened();
        }

        [Fact]
        public void rpn_div_test()
        {
            var input = "10 / 5";
            var fakeLog = A.Fake<Logger>();
            var fakeCalc = A.Fake<Calculator>();
            var testRPN = new RpnEngine(fakeLog, fakeCalc);

            testRPN.CalculateRpn(input);
            A.CallTo(() => fakeCalc.Divide(10, 5)).MustHaveHappened();
        }

        [Fact]
        public void rpn_exp_test()
        {
            var input = "10 ^ 5";
            var fakeLog = A.Fake<Logger>();
            var fakeCalc = A.Fake<Calculator>();
            var testRPN = new RpnEngine(fakeLog, fakeCalc);

            testRPN.CalculateRpn(input);
            A.CallTo(() => fakeCalc.Power(10, 5)).MustHaveHappened();
        }

    }

}
