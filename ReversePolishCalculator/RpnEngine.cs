using System;
using System.Collections.Generic;
using FileLogger;

namespace ReversePolishCalculator
{
    public class RpnEngine
    {
        private readonly Stack<decimal> _stack;
        private readonly Calculator _calculator;
        private Logger _log;

        public RpnEngine()
        {
            _stack = new Stack<decimal>();
            _calculator = new Calculator();
            _log = new Logger(eLogLevel.Debug);
        }

        public RpnEngine(Logger fake_log, Calculator fake_calc) //with args
        {
            _stack = new Stack<decimal>();
            _calculator = fake_calc;
            _log = fake_log;
        }
                               
        public void CalculateRpn(string arg ="NOPE")
        {
            if (arg == "NOPE")
                arg = System.Console.ReadLine();

            var input = arg;
            _stack.Clear();
            _log.Trace(input);


            var rpnTokens = input.Split(' ');
            string op="%";  

            foreach (var rpnToken in rpnTokens)
            {
                _log.Debug(rpnToken);
                if (decimal.TryParse(rpnToken, out decimal number))
                { _stack.Push(number); }
                else
                { op = rpnToken; }
            }
                    switch (op)
                    {
                        case "^":
                            var stackNumber = _stack.Pop();
                            _stack.Push(_calculator.Power(_stack.Pop(), stackNumber));
                            break;
                        case "*":
                            _stack.Push(_calculator.Multiply(_stack.Pop(), _stack.Pop()));
                            break;
                        case "/":
                            stackNumber = _stack.Pop();
                            _stack.Push(_calculator.Divide(_stack.Pop(), stackNumber));
                            break;
                        case "+":
                            _stack.Push(_calculator.Add(_stack.Pop(), _stack.Pop()));
                            break;
                        case "-":
                            stackNumber = _stack.Pop();
                            _stack.Push(_calculator.Subtract(_stack.Pop(), stackNumber));
                            break;
                        default:
                            var message = $"Could not parse [{op}]";
                            _log.Fatal(message);
                            throw new ArgumentException(message, nameof(op));
                    }
                            

            var result = _stack.Pop();
            _log.Debug($"Result of calculation is [{result}]");
            //NOT WRITE TO CONSOLE MAKE OUTPUT OPTIONS FAKE 
            Console.WriteLine(result);
        }
    }
}
