using System;
using System.Collections.Generic;
using System.Linq;

namespace CalculatorLibrary
{
    /// <summary>
    /// Handles the old text equasions and rolls them down the TextBoxes.
    /// </summary>
    public class Display
    {
        #region - Fields
        private List<string> _dataList = new List<string>(4);
        private string _input = String.Empty;
        #endregion

        #region - Constructors
        public Display()
        {
            Initialize();
        }
        public Display(string input)
        {
            Input = input;
            Initialize();
        }
        #endregion

        #region - Methods
        /// <summary>
        ///  Adds empty strings to the DataList and adds the first input.
        ///  Only used internally.
        /// </summary>
        private void Initialize()
        {
            for (int i = 1; i <= 3; i++)
            {
                DataList.Add(String.Empty);
            }
            DataList.Add(Input);
        }

        /// <summary>
        /// Moves the DataList by removing the first index and adding the input to the end.
        /// </summary>
        public void Next()
        {
            // For some reason if the DataList is below the 4-data count,
            // No big deal. just adds to the DataList.
            if (DataList.Count < 4)
            {
                DataList.Add(Input);
            }
            // This is the desired conditional.
            // Removes the old data and adds the new data.
            else if (DataList.Count == 4)
            {
                DataList.RemoveAt(0);
                DataList.Add(Input);
            }
            else
            {
                // Should never get here.
                // Watch for the list getting cleared randomly.
                // Indicates a bug.
                DataList.Clear();
                Initialize();
            }
        }

        /// <summary>
        /// Emptys the DataList and puts 4 empty strings in.
        /// </summary>
        public void Clear()
        {
            Input = String.Empty;
            DataList.Clear();
            Initialize();
        }
        #endregion

        #region - Properties
        /// <summary>
        /// 4-data list used to move equasion strings down.
        /// </summary>
        public List<string> DataList
        {
            get { return _dataList; }
            set
            {
                _dataList = value;
            }
        }

        /// <summary>
        /// The data to be put onto the end of the DataList.
        /// </summary>
        public string Input
        {
            get { return _input; }
            set
            {
                _input = value;
            }
        }
        #endregion
    }
}
