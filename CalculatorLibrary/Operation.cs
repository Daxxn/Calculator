using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    /// <summary>
    /// Only used in the Calculator class to store an operation.
    /// I could probably use this in other projects.
    /// Uses Dynamic Type selection.
    /// </summary>
    public class Operation
    {
        #region - Fields
        private dynamic _x;
        private dynamic _y;
        private char _op;
        #endregion

        #region - Constructors
        public Operation() { }
        /// <summary>
        /// Selects simple math operations.
        /// Dynamic Types.
        /// </summary>
        /// <param name="x">Dynamic. Use with care.</param>
        /// <param name="y">Dynamic. Use with care.</param>
        /// <param name="op">Char, selects simple math operation</param>
        public Operation(dynamic x, dynamic y, char op)
        {
            X = x;
            Y = y;
            Op = op;
        }
        #endregion

        #region - Methods
        /// <summary>
        /// does the simple 2-number calculation.
        /// </summary>
        /// <returns>Returns the selected operation.</returns>
        public double selectOperation()
        {
            if (Op == '/')
            {
                return Div();
            }
            else if (Op == '*')
            {
                return Mul();
            }
            else if (Op == '-')
            {
                return Sub();
            }
            else if (Op == '+')
            {
                return Add();
            }
            else if(Op == '%')
            {
                return Perc();
            }
            else
            {
                throw new Exception("No Operator Found");
            }
        }

        public dynamic Add()
        {
            return X + Y;
        }

        public dynamic Sub()
        {
            return X - Y;
        }

        public dynamic Mul()
        {
            return X * Y;
        }

        public dynamic Div()
        {
            return X / Y;
        }

        public dynamic Perc()
        {
            return X / Y * 100;
        }
        #endregion

        #region - Properties
        public dynamic X
        {
            get { return _x; }
            set
            {
                _x = value;
            }
        }

        public dynamic Y
        {
            get { return _y; }
            set
            {
                _y = value;
            }
        }

        /// <summary>
        /// Must be + , - , * , / , %
        /// </summary>
        public char Op
        {
            get { return _op; }
            set
            {
                _op = value;
            }
        }
        #endregion
    }
}
