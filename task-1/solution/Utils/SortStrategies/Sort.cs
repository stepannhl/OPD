namespace UserSort;

abstract class MatrixSort : ISortable {
    protected static void Swap(ref double a, ref double b) {
        double temp = a;
        a = b;
        b = temp;
    }
    protected static void SwapRows(ref double[,] matrix, int a, int b) {
        for (int i = 0; i < matrix.GetLength(1); ++i) {
            Swap(ref matrix[a, i], ref matrix[b, i]);
        }
    }

    public abstract void Sort(ref double[,] matrix, IComparable comparator);
}