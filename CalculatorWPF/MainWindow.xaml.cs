using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using CalculatorLibrary;

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string equasionInput = String.Empty;

        Display inputDisplay = new Display();
        Display answerDisplay = new Display();

        public MainWindow()
        {
            InitializeComponent();

            Button_0.DataContext = "0";
            Button_1.DataContext = "1";
            Button_2.DataContext = "2";
            Button_3.DataContext = "3";
            Button_4.DataContext = "4";
            Button_5.DataContext = "5";
            Button_6.DataContext = "6";
            Button_7.DataContext = "7";
            Button_8.DataContext = "8";
            Button_9.DataContext = "9";
            Button_Decimal.DataContext = ".";

            Button_Add.DataContext = "+";
            Button_Sub.DataContext = "-";
            Button_Mul.DataContext = "*";
            Button_Div.DataContext = "/";

            KeyData key_0 = new KeyData(Button_0.GetHashCode(), Button_0);
        }

        /// <summary>
        /// Number and Operator Click Event Logic.
        /// Basically appends chars to a string.
        /// </summary>
        private void Button_IN_Click(object sender, RoutedEventArgs e)
        {
            #region Testing Button Bindings
            var btn = e.Source as Button;
            Console.WriteLine($"{btn.DataContext} type: {btn.DataContext.GetType()}");
            #endregion

            #region Normal Operation
            string temp = CheckOperators(btn.DataContext as string);
            equasionInput += temp;
            Text_Input.Text += temp;
            #endregion
        }

        /// <summary>
        /// Checks for duplicate operators in the input stream.
        /// </summary>
        /// <param name="input">Pressed button as string.</param>
        /// <returns>Returns input if output is good. Returns empty if output is bad.</returns>
        private string CheckOperators(string input)
        {
            string[] ops = new string[] { "+", "-", "*", "/" };
            string dec = ".";

            if (equasionInput.Length != 0)
            {
                if (ops.Contains(equasionInput.Last().ToString()))
                {
                    if (!ops.Contains(input))
                    {
                        if (input == dec)
                        {
                            return "0" + input;
                        }
                        else
                        {
                            return input;
                        }
                    }
                    else
                    {
                        return String.Empty;
                    }
                }
                else
                {
                    return input;
                }
            }
            else if (!ops.Contains(input))
            {
                return input;
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// Starts calculation of the entered string then moves it to the history buffer.
        /// </summary>
        private void Button_Enter_Click(object sender, RoutedEventArgs e)
        {
            inputDisplay.Input = equasionInput;

            #region New Parser & Calculator Classes
            Parser parser = new Parser(equasionInput);
            parser.SplitInputString();
            Calculator calculator = new Calculator(parser.Numbers, parser.Operators);
            double output = calculator.OOPStart();
            answerDisplay.Input = output.ToString();
            equasionInput = String.Empty;
            #endregion

            inputDisplay.Next();
            answerDisplay.Next();
            OutputPrint();
            Text_Input.Clear();
        }

        /// <summary>
        /// Clears all previous inputs and history.
        /// </summary>
        private void Button_CA_Click(object sender, RoutedEventArgs e)
        {
            Text_Input.Clear();
            Text_Output_A.Clear();
            Text_Output_B.Clear();
            Text_Output_C.Clear();
            Text_Output_D.Clear();

            Answer_Output_A.Clear();
            Answer_Output_B.Clear();
            Answer_Output_C.Clear();
            Answer_Output_D.Clear();

            equasionInput = String.Empty;

            inputDisplay.Clear();
            answerDisplay.Clear();
        }

        private void Button_Back_Click(object sender, RoutedEventArgs e)
        {
            if (Text_Input.Text.Length != 0)
            {
                int lengthIN = equasionInput.Length;
                equasionInput = equasionInput.Remove(lengthIN - 1);
                Text_Input.Text = equasionInput;
            }
        }

        private void Button_Clear_Click(object sender, RoutedEventArgs e)
        {
            equasionInput = String.Empty;
            Text_Input.Clear();
        }

        /// <summary>
        /// Updates the TextBoxes on screen with the history buffers.
        /// </summary>
        private void OutputPrint()
        {
            Text_Output_A.Text = inputDisplay.DataList[3];
            Text_Output_B.Text = inputDisplay.DataList[2];
            Text_Output_C.Text = inputDisplay.DataList[1];
            Text_Output_D.Text = inputDisplay.DataList[0];

            Answer_Output_A.Text = answerDisplay.DataList[3];
            Answer_Output_B.Text = answerDisplay.DataList[2];
            Answer_Output_C.Text = answerDisplay.DataList[1];
            Answer_Output_D.Text = answerDisplay.DataList[0];
        }

        private void Button_Test_Click(Object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Test");
        }
    }

    public struct KeyData
    {
        int KeyCode { get; set; }
        Button ButtonData { get; set; }

        public KeyData(int keyCode, Button button)
        {
            KeyCode = keyCode;
            ButtonData = button;
        }
    }
}
