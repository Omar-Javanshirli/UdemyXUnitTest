using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UdemyUnitTest.APP
{
    public class CalculatorService : ICalculatorService
    {
        public int add(int x, int y)
        {
            if (x == 0 || y == 0)
                return 0;
            return x + y; 
        }

        public int multip(int x, int y)
        {
            if (x == 0)
                throw new Exception("a==0 olamaz");
            return x * y;
        }
    }
}
