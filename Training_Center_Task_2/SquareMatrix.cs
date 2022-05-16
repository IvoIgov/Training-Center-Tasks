namespace Training_Center_Task_2
{
    public class SquareMatrix<T> : BaseMatrix<T>
    {
        public SquareMatrix(int size) : base(size)
        {
            this.MatrixValues = base.MatrixValues;
        }

        public void CheckValueRelevantToMatrixTypeAndDefaultType(int row, int col, T value)
        {
            var valueType = value.GetType().Name;
            var classType = typeof(T).Name;
            if (valueType != classType)
            {
                throw new InvalidDataException(ExceptionMessages.ValueTypeNotMatchingMatrixType);
            }
        }
        public T this[int row, int col]
        {
            get
            {
                return MatrixValues[(row * Size) + col];
            }
            set
            {
                if (row < 0 || row >= base.Size)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.RowOutOfRange);
                }
                if (col < 0 || col >= base.Size)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.ColOutOfRange);
                }
                MatrixValues[row * base.Size + col] = value;
            }
        }
    }
}
