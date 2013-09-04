using System;
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
    public interface IFunction
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

    public static class FunctionManager
    {
        private readonly static IFunction[] functions ={
                                           new Sin(),
                                           new Cos(),
                                           new Tan(),
                                           new Ln(),
                                           new Lg(),
                                           new Log(),
                                      };
        /// <summary>
        /// 获得所有函数对象的只读数组
        /// </summary>
        public static IFunction[] Functions
        {
            get
            {
                return functions;
            }
        }

        /// <summary>
        /// 通过函数名称获得函数对象
        /// </summary>
        /// <param name="name">函数名称</param>
        /// <returns>函数对象</returns>
        public static IFunction GetFunc(string name)
        {
            foreach (IFunction item in functions)
            {
                if (item.GetName().Equals(name, StringComparison.CurrentCultureIgnoreCase))
                {
                    return item;
                }
            }
            return null;
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
            return Math.Log(args[0], args[1]);
        }

        #endregion
    }
}
