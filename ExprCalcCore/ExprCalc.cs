using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExprCalc.Core
{
    public class ExprCalc
    {
        private  string expr;
        private string result;
        public string Result { get; }
        public string Expr
        {
            get;
            set
            {
                expr = value.Trim();
            }
        }


    }
}
