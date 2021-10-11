using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NumberSequence
{
    public class NumberSequenceGenerator
    {
        private List<int> _sequence;
        private List<int> _new_sequence;
        private bool _isSequence = false;

        public bool ValidateSingleSpaceSeparatedNumbers(string numberString)
        {
            var pattern = @"^\d+(\s\d+)*$";
            return Regex.IsMatch(numberString, pattern);
        }

        public string FirstLongestIncreasingSequence(string numberString)
        {
            try
            {
                if (!ValidateSingleSpaceSeparatedNumbers(numberString))
                    throw new ArgumentException("Only single white space separated numbers string allowed!");

                var currentIndex = 0;
                _sequence = new List<int>();
                _new_sequence = new List<int>();
                _isSequence = false;
                var numberSequence = numberString.Split(' ').Select(number => Convert.ToInt32(number)).ToList();
                var maxPossibleIndex = numberSequence.Count() - 1;

                while (currentIndex < maxPossibleIndex)
                {
                    var currentNumber = numberSequence[currentIndex];
                    var nextNumber = numberSequence[++currentIndex];

                    if (currentNumber < nextNumber)
                    {
                        _isSequence = true;
                        _new_sequence.Add(currentNumber);
                        if (_isSequence && currentIndex == maxPossibleIndex)
                        {
                            AddNumberInSequence(nextNumber);
                        }
                    }
                    else
                    {
                        if (_isSequence)
                        {
                            AddNumberInSequence(currentNumber);
                        }
                        _new_sequence.Clear();
                    }
                }

                if (_sequence.Any())
                    return string.Join(' ', _sequence.Select(n => n.ToString()).ToArray());

                return string.Empty;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void AddNumberInSequence(int number)
        {
            _new_sequence.Add(number);
            _isSequence = false;
            if (_sequence.Count() < _new_sequence.Count())
                _sequence = _new_sequence.ToList();
        }
    }
}
