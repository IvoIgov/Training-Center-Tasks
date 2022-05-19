using Training_Center_Task_2;
using static Training_Center_Task_2.BaseMatrix<int>;
public class Program
{
    public static void Main()
    {
        //Console.WriteLine("This is square matrix logic example");
        //Console.Write("Enter matrix size: ");
        //int matrixSquareSize = int.Parse(Console.ReadLine());

        ////logic can be added here to create a matrix based on user input for matrix type
        //var matrixSquare = new SquareMatrix<int>(matrixSquareSize);

        //Console.WriteLine("Enter values to fill in matrix in format 'row col value,row col value,...'.");
        //string[] valuesSquare = Console.ReadLine().Split(',').ToArray();

        ////var matrixSquareIndexes = new IndexerClassSquareMatrix<int>(matrixSquareSize);

        //foreach (var item in valuesSquare)
        //{
        //    string[] valueInfo = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
        //    int row = int.Parse(valueInfo[0]);
        //    int col = int.Parse(valueInfo[1]);
        //    int value = int.Parse(valueInfo[2]);
        //    matrixSquare[row, col] = value;
        //}

        Console.WriteLine("This is diagonal matrix logic example");
        Console.Write("Enter matrix size: ");
        int matrixDiagonalSize = int.Parse(Console.ReadLine());
        //logic can be added here to create a matrix based on user input for matrix type
        var matrixDiagonal = new DiagonalMatrix<int>(matrixDiagonalSize);

        //var validIndexesList = matrixDiagonal.CreateValidDiagonalIndexesList(matrixDiagonalSize);

        Console.WriteLine("Enter values to fill in matrix in format 'row col value,row col value,...'. Value shound be a whole number!");
        string[] valuesDiagonal = Console.ReadLine().Split(',').ToArray();
        foreach (var item in valuesDiagonal)
        {
            string[] valueInfo = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int row = int.Parse(valueInfo[0]);
            int col = int.Parse(valueInfo[1]);
            int value = int.Parse(valueInfo[2]);
        }
    }
}