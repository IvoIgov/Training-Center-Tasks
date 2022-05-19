using Training_Center_Task_2;
using static Training_Center_Task_2.BaseMatrix<int>;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("This is square matrix logic example");
        Console.Write("Enter matrix size: ");
        int matrixSquareSize = int.Parse(Console.ReadLine());

        var matrixSquare = new SquareMatrix<int>(matrixSquareSize);

        Console.WriteLine("Enter values to fill in matrix in format 'row col value,row col value,...'.");
        string[] valuesSquare = Console.ReadLine().Split(',').ToArray();


        foreach (var item in valuesSquare)
        {
            string[] valueInfo = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int row = int.Parse(valueInfo[0]);
            int col = int.Parse(valueInfo[1]);
            int value = int.Parse(valueInfo[2]);
        }

        //Writes final state of matrix
        Console.WriteLine(String.Join(' ', matrixSquare.MatrixValues));


        Console.WriteLine("This is diagonal matrix logic example");
        Console.Write("Enter matrix size: ");
        int matrixDiagonalSize = int.Parse(Console.ReadLine());

        var matrixDiagonal = new DiagonalMatrix<int>(matrixDiagonalSize);

        Console.WriteLine("Enter values to fill in matrix in format 'row col value,row col value,...'. Value should be a whole number!");
        string[] valuesDiagonal = Console.ReadLine().Split(',').ToArray();
        foreach (var item in valuesDiagonal)
        {
            string[] valueInfo = item.Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
            int row = int.Parse(valueInfo[0]);
            int col = int.Parse(valueInfo[1]);
            int value = int.Parse(valueInfo[2]);
        }

        //Writes final state of matrix
        Console.WriteLine(String.Join(' ', matrixDiagonal.MatrixValues));
    }
}