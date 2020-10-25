using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorLibrary
{
    public class Parser
    {

        #region - Fields
        private string _input;
        private List<double> _numbers;
        private List<char> _operators;
        #endregion

        #region - Constructors
        public Parser() { }
        /// <summary>
        /// New Parser that will split the input stream into a Calculator class understandable input stream.
        /// </summary>
        /// <param name="input">Takes the MainWindow.XAML input string</param>
        public Parser(string input)
        {
            Input = input;
        }
        #endregion

        #region - Methods
        /// <summary>
        /// Runs the Number and Operator splitter methodss
        /// </summary>
        public void SplitInputString()
        {
            SplitNumbers();
            SplitOperators();
        }

        /// <summary>
        /// Splits the numbers from the input string and parses them into Doubles.
        /// Only used internally, Call SplitInputString().
        /// </summary>
        private void SplitNumbers()
        {
            try
            {
                string[] splitNums = Input.Split('+', '-', '*', '/');

                foreach (var item in splitNums)
                {
                    if (Numbers == null)
                    {
                        Numbers = new List<double>();
                    }
                    Numbers.Add(Double.Parse(item));
                }
            }
            catch (Exception)
            {
                Numbers = null;
            }
        }

        /// <summary>
        /// Splits the Input stream into operators that the Calculator class can use.
        /// Only used Internally, Call SplitInputString().
        /// </summary>
        private void SplitOperators()
        {
            char[] operators = new char[] { '+', '-', '/', '*' };

            for (int i = 0; i < Input.Length; i++)
            {
                for (int j = 0; j < operators.Length; j++)
                {
                    if (operators[j] == Input[i])
                    {
                        if (Operators == null)
                        {
                            Operators = new List<char>();
                        }
                        Operators.Add(Input[i]);
                    }
                }
            }
        }
        #endregion

        #region - Properties
        /// <summary>
        /// Input string from MainWindow.XAML
        /// </summary>
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
            }
        }

        /// <summary>
        /// Output numbers used for calculation.
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
        /// Output operators used for calculation.
        /// </summary>
        public List<char> Operators
        {
            get { return _operators; }
            set
            {
                _operators = value;
            }
        }
        #endregion
    }
}
