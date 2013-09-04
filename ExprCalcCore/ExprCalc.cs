using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExprCalc.Core.Functions;

namespace ExprCalc.Core
{
    public class ExprCalc
    {
        private  string expr;
        private string result;
        public string Result 
        {
            get
            {
                return result;
            }
        }
        public string Expr
        {
            get
            {
                return expr;
            }
            set
            {
                expr = value.Trim();
            }
        }

    }
}
