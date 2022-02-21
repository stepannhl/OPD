using System;
using System.Linq;
using UserSort;
using UserCompare;

namespace UserMatrix;

public class Matrix {
    private ISortable _sortStrategy = new RowSumSort();
    private IComparable _compareStrategy = new AscendingCompare();
    private double[,] _data = new double[0, 0];
    public int Rows => this._data.GetLength(0);
    public int Cols => this._data.GetLength(1);

    public Matrix() : this(0) {}

    public Matrix(int size) : this(size, size) {}

    public Matrix(int rows, int cols) => GetEmpty(rows, cols);

    public Matrix(double[,] initData) {
        int rows = initData.GetLength(0);
        int cols = initData.GetLength(1);

        this._data = new double[rows, cols];
        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                this._data[i, j] = initData[i, j];
            }
        }
    }

    public void SetSortStrategy(int strategy) {
        switch (strategy) {
            case 1:
                this._sortStrategy = new RowSumSort();
                break;
            case 2:
                this._sortStrategy = new RowMaxSort();
                break;
            case 3:
                this._sortStrategy = new RowMinSort();
                break;
            default:
                break;
        }
    }

    public void SetCompareStrategy(int strategy) {
        switch (strategy) {
            case 1:
                this._compareStrategy = new AscendingCompare();
                break;
            case 2:
                this._compareStrategy = new DescendingCompare();
                break;
            default:
                break;
        }
    }

    public void Sort() {
        _sortStrategy.Sort(ref this._data, this._compareStrategy);
    }

    public static Matrix GetEmpty(int size) => GetEmpty(size, size);
    public static Matrix GetEmpty(int rows, int cols) {
        rows = Math.Max(0, rows);
        cols = Math.Max(0, cols);

        double[,] initData = new double[rows, cols];
        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                initData[i, j] = 0;
            }
        }
        return new Matrix(initData);
    }

    public override string ToString() {
        string[] rows = new string[this.Rows];
        for (int i = 0; i < this.Rows; ++i) {
            rows[i] = "";
            for (int j = 0; j < this.Cols; ++j) {
                rows[i] += $"{this._data[i, j]} ";
            }
        }

        return String.Join("\n", rows);
    }

    public static bool TryParse(string stringInput, out Matrix matrix) {
        matrix = new ();

        string[] itemRows = stringInput.Split(", ").ToArray();
        string[][] items = itemRows.Select(row => row.Split(" ").ToArray()).ToArray();

        int rows = itemRows.Length;
        int cols = items.Select(item => item.Length).Max();
        double[,] data = new double[rows, cols];

        for (int i = 0; i < rows; ++i) {
            for (int j = 0; j < cols; ++j) {
                double currVal = 0;
                bool parsed = j >= items[i].Length ? true : double.TryParse(items[i][j], out currVal);
                if (!parsed) return false;
                data[i, j] = currVal;
            }
        }
        matrix = new Matrix(data);
        return true;
    }

}