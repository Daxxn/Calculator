using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLibrary
{
    /// <summary>
    /// Handles the Order of Operations.
    /// </summary>
    public class Calculator
    {
        #region - Fields
        private List<double> _numbers;
        private List<char> _operators;
        private Operation _calculation;
        #endregion

        #region - Constructors
        /// <summary>
        /// Blank Constructor.
        /// Doesn't run any code.
        /// </summary>
        public Calculator() { }

        /// <summary>
        /// Handles the input from the Parser.
        /// </summary>
        /// <param name="nums">Numbers from the parser (Doubles)</param>
        /// <param name="opers">Operators from the Parser (Chars)</param>
        public Calculator(List<double> nums, List<char> opers)
        {
            Numbers = nums;
            Operators = opers;
        }
        #endregion

        #region - Methods
        /// <summary>
        /// Executes the Order of Operations calculation.
        /// </summary>
        /// <returns>Returns the Answer. (Double)</returns>
        public double OOPStart()
        {
            if ( Numbers is null )
            {
                throw new Exception("Numbers is null.");
            }

            if ( Numbers.Count == 2 && Operators.Count == 1 )
            {
                return OrderOfOperationsSimple();
            }
            else if ( Numbers.Count > 2 && Operators.Count > 1 )
            {
                return OrderOfOperationsComplex(Numbers, Operators);
            }
            else
            {
                return Numbers[ 0 ];
            }
        }

        /// <summary>
        /// OOP for 2 numbers only.
        /// Only used Internally.
        /// </summary>
        /// <returns>OOP output (Double)</returns>
        private double OrderOfOperationsSimple()
        {
            Operation temp = new Operation(Numbers[0], Numbers[1], Operators[0]);
            return temp.selectOperation();
        }

        /// <summary>
        /// OOP for more than 2 numbers.
        /// Only used Internally.
        /// </summary>
        /// <param name="nums">Number List from Parser</param>
        /// <param name="ops">Operator List from Parser</param>
        /// <returns>Passes OOP answer through</returns>
        public static double OrderOfOperationsComplex(List<double> nums, List<char> ops)
        {
            double output = 0;
            List<double> tempNums = nums.ToList();
            List<char> tempOps = ops.ToList();

            while (tempNums.Count != 1)
            {
                for (int i = 0; i < tempOps.Count; i++)
                {
                    if (tempOps[i] == '/')
                    {
                        tempNums = OOPStep(tempNums, tempOps, i);
                        break;
                    }

                    else if (tempOps[i] == '*' && !tempOps.Contains('/'))
                    {
                        tempNums = OOPStep(tempNums, tempOps, i);
                        break;
                    }

                    else if (tempOps[i] == '-' && !tempOps.Contains('/') && !tempOps.Contains('*'))
                    {
                        tempNums = OOPStep(tempNums, tempOps, i);
                        break;
                    }

                    else if (tempOps[i] == '+' && !tempOps.Contains('/') && !tempOps.Contains('*') && !tempOps.Contains('-'))
                    {
                        tempNums = OOPStep(tempNums, tempOps, i);
                        break;
                    }
                }
            }

            if (tempNums.Count == 1)
            {
                output = tempNums[0];
            }

            return output;
        }

        /// <summary>
        /// Steps through the OOP procedure.
        /// Only used Internally.
        /// </summary>
        /// <param name="tempNums"> Pass tempNums through</param>
        /// <param name="tempOps">Pass tempOps through</param>
        /// <param name="index">Pass for loop index through</param>
        /// <returns>returns OOP answer</returns>
        private static List<double> OOPStep(List<double> tempNums, List<char> tempOps, int index)
        {
            Operation tempOperation = new Operation(tempNums[index], tempNums[index + 1], tempOps[index]);
            List<double> newNums = new List<double>();


            tempOps.RemoveAt(index);

            for (int j = 0; j < tempNums.Count; j++)
            {
                if (tempNums[j] == tempOperation.X)
                {
                    newNums.Add(tempOperation.selectOperation());
                }
                else if (tempNums[j] == tempOperation.Y)
                {
                    continue;
                }
                else if (tempNums[j] != tempOperation.X)
                {
                    newNums.Add(tempNums[j]);
                }
            }
            return newNums;
        }
        #endregion

        #region - Properties

        /// <summary>
        /// All numbers used for OOP.
        /// </summary>
        public List<double> Numbers
        {
            get { return _numbers; }
            set
            {
                _numbers = value;
            }
        }

        /// <summary>
        /// All Operators used for OOP.
        /// </summary>
        public List<char> Operators
        {
            get { return _operators; }
            set
            {
                _operators = value;
            }
        }

        /// <summary>
        /// Operation class reference.
        /// </summary>
        public Operation Calculation
        {
            get { return _calculation; }
            set
            {
                _calculation = value;
            }
        }
        #endregion
    }
}
