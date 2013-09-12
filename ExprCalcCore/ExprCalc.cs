using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using ExprCalc.Core.Functions;

namespace ExprCalc.Core
{
    public class ExprCalc
    {
        private string expr;
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
                expr = FormatExpr(value);
            }
        }

        /// <summary>
        /// 修正表达式格式
        /// </summary>
        /// <param name="expr">输入表达式</param>
        /// <returns>修正后的表达式</returns>
        private string FormatExpr(string expr)
        {
            expr = expr.Replace(" ", "");//去掉空格
            return expr;
        }

        /// <summary>
        /// 检查输入表达式是否正确
        /// </summary>
        private void CheckExpr()
        {
           
        }

        /// <summary>
        /// 表达式管理器
        /// </summary>
        private class ExprMgr
        {
            /// <summary>
            /// 字符类型
            /// </summary>
            enum CharType { ALPHABET,DIGIT,DOT,OPERATOR,BRACKET,PERCENT,SHARP,UNDEFINED}
            private string expr;
            private int index = 0;
            public ExprMgr(string expr)
            {
                this.expr = expr;
            }

            /// <summary>
            /// 字符类型
            /// </summary>
            /// <param name="c">检测字符</param>
            /// <returns>CharType结果</returns>
            private CharType GetCharType(char c)
            {
                if (char.IsDigit(c)) return CharType.DIGIT;
                if (char.IsLetter(c)) return CharType.ALPHABET;
                if (c == '.') return CharType.DOT;
                if (c == '%') return CharType.PERCENT;
                if (c == '#') return CharType.SHARP;
                if (c == '+' || c == '-' || c == '*' || c == '/' || c == '^' || c == '!') return CharType.OPERATOR;
                if (c == '(' || c == ')' || c == '[' || c == ']' || c == '{' || c == '}') return CharType.BRACKET;

                return CharType.UNDEFINED;
            }

            /// <summary>
            /// 读取下一组字符串
            /// </summary>
            /// <returns>一组类型相同的字符串</returns>
            private string Next()
            {
                //no data to read
                if (index >= expr.Length)
                {
                    return null;
                }

                //处理的表达式理论上要求是**正确**的
                //处理小数的时候复杂一点
                StringBuilder sb = new StringBuilder();
                
                char c = expr[index];
                CharType ct= GetCharType(c);

                if (ct == CharType.DOT)//发现小数点
                {
                    sb.Append(c);
                    index++;
                    c = expr[index];
                    if (GetCharType(c) == CharType.DIGIT)//如果小数点后面是数字，连接在一起
                    {
                        sb.Append(Next());
                        return sb.ToString();
                    }
                    else//否则只返回小数点
                    {
                        return sb.ToString();
                    }
                }

                //连续读取循环
                do{
                    sb.Append(c);
                    index++;
                    c = expr[index];
                } while (GetCharType(c) == ct);

                //数字的后面是小数点
                if (GetCharType(c) == CharType.DOT && ct == CharType.DIGIT)
                {
                    sb.Append(Next());//将后面的小数连接到前面的整数上
                }
                
                return sb.ToString();
            }
            private void ResetIndex()
            {
                index = 0;
            }
            public Stack<string> ToPostfix()
            {
                Stack<string> sExpr = new Stack<string>();
                Stack<string> sOp = new Stack<string>();
                //TODO
                return null;
            }
        }

        /// <summary>
        /// 测试用
        /// </summary>
        /// <returns></returns>
        public string Test()
        {
            return FunctionManager.Functions["log"].Calc(3,5).ToString();
        }

    }
}
