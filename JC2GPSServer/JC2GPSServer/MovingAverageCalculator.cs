using System;

namespace Drew.Util
{
    /// <summary>
    /// Calculates a moving average value over a specified window.  The window size must be specified
    /// upon creation of this object.
    /// </summary>
    /// <remarks>Authored by Drew Noakes, February 2005.  Use freely, though keep this message intact and
    /// report any bugs to me.  I also appreciate seeing extensions, or simply hearing that you're using
    /// these classes.  You may not copyright this work, though may use it in commercial/copyrighted works.
    /// Happy coding.
    ///
    /// Updated 29 March 2007.  Added a Reset() method.</remarks>
    public sealed class MovingAverageCalculator
    {
        private readonly int _windowSize;
        private readonly float[] _values;
        private int _nextValueIndex;
        private float _sum;
        private int _valuesIn;

        /// <summary>
        /// Create a new moving average calculator.
        /// </summary>
        /// <param name="windowSize">The maximum number of values to be considered
        /// by this moving average calculation.</param>
        /// <exception cref="ArgumentOutOfRangeException">If windowSize less than one.</exception>
        public MovingAverageCalculator(int windowSize)
        {
            if (windowSize < 1)
                throw new ArgumentOutOfRangeException("windowSize", windowSize, "Window size must be greater than zero.");

            _windowSize = windowSize;
            _values = new float[_windowSize];

            Reset();
        }

        /// <summary>
        /// Updates the moving average with its next value, and returns the updated average value.
        /// When IsMature is true and NextValue is called, a previous value will 'fall out' of the
        /// moving average.
        /// </summary>
        /// <param name="nextValue">The next value to be considered within the moving average.</param>
        /// <returns>The updated moving average value.</returns>
        /// <exception cref="ArgumentOutOfRangeException">If nextValue is equal to float.NaN.</exception>
        public float NextValue(float nextValue)
        {
            if (float.IsNaN(nextValue))
                throw new ArgumentOutOfRangeException("nextValue", "NaN may not be provided as the next value.  It would corrupt the state of the calculation.");

            // add new value to the sum
            _sum += nextValue;

            if (_valuesIn < _windowSize)
            {
                // we haven't yet filled our window
                _valuesIn++;
            }
            else
            {
                // remove oldest value from sum
                _sum -= _values[_nextValueIndex];
            }

            // store the value
            _values[_nextValueIndex] = nextValue;

            // progress the next value index pointer
            _nextValueIndex++;
            if (_nextValueIndex == _windowSize)
                _nextValueIndex = 0;

            return _sum / _valuesIn;
        }

        /// <summary>
        /// Gets a value indicating whether enough values have been provided to fill the
        /// speicified window size.  Values returned from NextValue may still be used prior
        /// to IsMature returning true, however such values are not subject to the intended
        /// smoothing effect of the moving average's window size.
        /// </summary>
        public bool IsMature
        {
            get { return _valuesIn == _windowSize; }
        }

        /// <summary>
        /// Clears any accumulated state and resets the calculator to its initial configuration.
        /// Calling this method is the equivalent of creating a new instance.
        /// </summary>
        public void Reset()
        {
            _nextValueIndex = 0;
            _sum = 0;
            _valuesIn = 0;
        }
    }
}