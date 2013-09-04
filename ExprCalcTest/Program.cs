using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExprCalc.Core;

namespace ExprCalc.Core
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FunctionManager.GetFunc("sin").Calc(2));
        }
    }
}
