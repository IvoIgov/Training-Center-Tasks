namespace Training_Center_Task_2
{
    public class DiagonalMatrix<T> : BaseMatrix<T>
    {
        private List<int> diagonalIndexes = new List<int>();
        public DiagonalMatrix(int size) : base(size)
        {
            this.MatrixValues = base.MatrixValues;
            this.DiagonalIndexes = diagonalIndexes;
        }

        public List<int> DiagonalIndexes { get; set; }

        /// <summary>
        /// Creates a list of all diagonal indexes in the diagonal matrix.
        /// </summary>
        /// <param name="matrixSize"></param>
        /// <returns></returns>
        public List<int> CreateValidDiagonalIndexesList(int matrixSize)
        {
            for (int i = 0; i < matrixSize * matrixSize; i += matrixSize + 1)
            {
                DiagonalIndexes.Add(i);
            }
            return DiagonalIndexes;
        }

        /// <summary>
        /// Checks if the value input by the user is relevant to the value type of the matrix. 
        /// If the coordinates of the value are outside the diagonal, checks whether the value
        /// is the default for the data type
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <param name="value"></param>
        /// <exception cref="InvalidDataException"></exception>
        public void CheckValueRelevantToMatrixTypeAndDefaultType(int row, int col, T value)
        {
            var valueType = value.GetType().Name;
            var classType = typeof(T).Name;
            var indexContained = DiagonalIndexes.Contains((row * Size) + col);
            if (valueType != classType)
            {
                throw new InvalidDataException(ExceptionMessages.ValueTypeNotMatchingMatrixType);
            }
            if (indexContained = false && value.ToString() != default(T).ToString())
            {
                throw new InvalidDataException(ExceptionMessages.ValueTypeNotDefaultDiagonalMatrix);
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
