namespace Training_Center_Task_2
{
    public abstract class BaseMatrix<T>
    {
        private int size;
        private T[] matrixValues = new T[] {};

        public BaseMatrix(int size)
        {
            this.Size = size;
            matrixValues = new T[size * size];
            this.MatrixValues = matrixValues;
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
    }
}
