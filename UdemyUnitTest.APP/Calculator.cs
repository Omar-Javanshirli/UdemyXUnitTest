using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyUnitTest.APP
{
    public class Calculator
    {
        private readonly ICalculatorService _calculatorService;

        public Calculator(ICalculatorService calculatorService)
        {
            this._calculatorService= calculatorService;
        }

        public int add(int x, int y)
        {
            return _calculatorService.add(x, y);
        }

        public int multip(int x,int y)
        {
            return _calculatorService.multip(x, y);
        }
    }
}
