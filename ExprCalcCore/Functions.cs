using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExprCalc.Core.Functions;

namespace ExprCalc.Core
{
    /// <summary>
    /// 函数接口
    /// </summary>
    internal interface IFunction
    {
        /// <summary>
        /// 获取函数名称
        /// </summary>
        /// <returns>函数名字符串</returns>
        string GetName();

        /// <summary>
        /// 获取参数个数
        /// </summary>
        /// <returns>参数个数</returns>
        int GetParamCount();

        /// <summary>
        /// 计算函数的值
        /// </summary>
        /// <param name="args">参数表</param>
        /// <returns>函数的值</returns>
        double Calc(params double[] args);

    }

    /// <summary>
    /// 函数管理器
    /// </summary>
    internal static class FunctionManager
    {
        private readonly static Dictionary<string, IFunction> functions;

        /// <summary>
        /// 不区分大小写的比较器
        /// </summary>
        /// <typeparam name="?"></typeparam>
        private class FuncComp: IEqualityComparer<string>
        {

            #region IEqualityComparer<string> 成员

            public bool Equals(string x, string y)
            {
                return x.Equals(y, StringComparison.CurrentCultureIgnoreCase);
            }

            public int GetHashCode(string obj)
            {
                return obj.ToString().ToLower().GetHashCode();
            }

            #endregion
        }
        /// <summary>
        /// 初始化管理器内容
        /// </summary>
        static FunctionManager()
        {
            functions = new Dictionary<string, IFunction>(new FuncComp());
            functions.Add("sin", new Sin());
            functions.Add("cos", new Cos());
            functions.Add("tan", new Tan());
            functions.Add("lg", new Lg());
            functions.Add("ln", new Ln());
            functions.Add("log", new Log());
        }
        /// <summary>
        /// 获取一个只读函数集合
        /// </summary>
        public static Dictionary<string, IFunction> Functions
        {
            get
            {
                return functions;
            }
        }
    }
}

/*
 * 定义计算器的各种函数
 */
namespace ExprCalc.Core.Functions
{

    /// <summary>
    /// sin函数
    /// </summary>
    class Sin : IFunction
    {

        #region IFunction 成员

        public string GetName()
        {
            return "sin";
        }

        public int GetParamCount()
        {
            return 1;
        }

        public double Calc(params double[] args)
        {
            if (args.Length != GetParamCount())
            {
                throw new ArgumentException(string.Format("function \"{0}\" requires {1} parameter(s), but found {2} of them", GetName(), GetParamCount(), args.Length));
            }
            return Math.Sin(args[0]);
        }

        #endregion
    }
    /// <summary>
    /// cos函数
    /// </summary>
    class Cos : IFunction
    {

        #region IFunction 成员

        public string GetName()
        {
            return "cos";
        }

        public int GetParamCount()
        {
            return 1;
        }

        public double Calc(params double[] args)
        {
            if (args.Length != GetParamCount())
            {
                throw new ArgumentException(string.Format("function \"{0}\" requires {1} parameter(s), but found {2} of them", GetName(), GetParamCount(), args.Length));
            }
            return Math.Cos(args[0]);
        }

        #endregion
    }
    /// <summary>
    /// tan函数
    /// </summary>
    class Tan : IFunction
    {

        #region IFunction 成员

        public string GetName()
        {
            return "tan";
        }

        public int GetParamCount()
        {
            return 1;
        }

        public double Calc(params double[] args)
        {
            if (args.Length != GetParamCount())
            {
                throw new ArgumentException(string.Format("function \"{0}\" requires {1} parameter(s), but found {2} of them", GetName(), GetParamCount(), args.Length));
            }
            return Math.Tan(args[0]);
        }

        #endregion
    }
    /// <summary>
    /// ln函数
    /// </summary>
    class Ln : IFunction
    {

        #region IFunction 成员

        public string GetName()
        {
            return "ln";
        }

        public int GetParamCount()
        {
            return 1;
        }

        public double Calc(params double[] args)
        {
            if (args.Length != GetParamCount())
            {
                throw new ArgumentException(string.Format("function \"{0}\" requires {1} parameter(s), but found {2} of them", GetName(), GetParamCount(), args.Length));
            }
            return Math.Log(args[0]);
        }

        #endregion
    }
    /// <summary>
    /// lg函数
    /// </summary>
    class Lg : IFunction
    {

        #region IFunction 成员

        public string GetName()
        {
            return "lg";
        }

        public int GetParamCount()
        {
            return 1;
        }

        public double Calc(params double[] args)
        {
            if (args.Length != GetParamCount())
            {
                throw new ArgumentException(string.Format("function \"{0}\" requires {1} parameter(s), but found {2} of them", GetName(), GetParamCount(), args.Length));
            }
            return Math.Log10(args[0]);
        }

        #endregion
    }
    /// <summary>
    /// log函数
    /// </summary>
    class Log : IFunction
    {

        #region IFunction 成员

        public string GetName()
        {
            return "log";
        }

        public int GetParamCount()
        {
            return 2;
        }

        public double Calc(params double[] args)
        {
            if (args.Length != GetParamCount())
            {
                throw new ArgumentException(string.Format("function \"{0}\" requires {1} parameter(s), but found {2} of them", GetName(), GetParamCount(), args.Length));
            }
            return Math.Log(args[0], args[1]);
        }

        #endregion
    }
}
