namespace UserSort;

class RowSumSort : MatrixSort {
    public override void Sort(ref double[,] matrix, IComparable comparator) {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);

        for (int i = 0; i < rows - 1; ++i) {
            for (int j = i + 1; j < rows; ++j) {
                if (comparator.Compare(GetSum(matrix, i), GetSum(matrix, j)) == -1) {
                    SwapRows(ref matrix, i, j);
                }
            }
        }
    }

    public double GetSum(double[,] matrix, int row) {
        int len = matrix.GetLength(1);
        double sum = 0;

        for (int i = 0; i < len; ++i) {
            sum += matrix[row, i];
        }

        return sum;
    }
}