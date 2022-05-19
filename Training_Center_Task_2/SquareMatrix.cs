namespace Training_Center_Task_2
{
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        public SquareMatrix(int size) : base(size)
        {
            this.MatrixValues = base.MatrixValues;
        }

        /// <summary>
        /// Checks if the value input by the user is relevant to the value type of the matrix. 
        /// </summary>
        private void CheckValueRelevantToMatrixType(int row, int col, T value)
        {
            var valueType = value.GetType().Name;
            var classType = typeof(T).Name;
            if (valueType != classType)
            {
                throw new InvalidDataException(ExceptionMessages.ValueTypeNotMatchingMatrixType);
            }
        }
    }
}
