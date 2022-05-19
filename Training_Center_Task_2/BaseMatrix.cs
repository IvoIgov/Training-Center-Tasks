namespace Training_Center_Task_2
{
    public abstract class BaseMatrix<T>
    {
        private int size;
        private T[] matrixValues = new T[] { };

        public delegate void ValueInMatrixChangedEventHandler(int row, int col, T value);
        public event ValueInMatrixChangedEventHandler ValueInMatrixChanged;

        public BaseMatrix(int size)
        {
            this.Size = size;
            matrixValues = new T[size * size];
            this.MatrixValues = matrixValues;
            ValueInMatrixChanged += OnValueInMatrixChanged;
        }
        public T[] MatrixValues { get; set; }

        public int Size
        {
            get { return this.size; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException(ExceptionMessages.NegativeOrZeroMatrixSize);
                }
                this.size = value;
            }
        }

        public virtual void OnValueInMatrixChanged(int row, int col, T value)
        {
            Console.WriteLine("Value in matrix is changed!");
        }
    }
}
