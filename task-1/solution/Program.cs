using System;
using UserMatrix;

namespace Task1;

internal class Programm {
    public static void Main(string[] args) {
        string sortMenu = "1 - RowSumSort\n2 - RowMaxSort\n3 - RowMinSort\nq - выход\n";
        string compMenu = "1 - Ascending\n2 - Descending\nq - выход\n";
        string initData = "";
        int option = 0;

        var matrix = new Matrix();

        do {
            Console.WriteLine("Введите матрицу в формате . ., . ., ...");
            initData = Console.ReadLine();
        } while (!Matrix.TryParse(initData, out matrix));

        while (true) {
            option = GetOption(sortMenu);
            if (option == -1) return;
            matrix.SetSortStrategy(option);

            option = GetOption(compMenu);
            if (option == -1) return;
            matrix.SetCompareStrategy(option);

            matrix.Sort();

            Console.WriteLine($"Отсортированная матрица:\n{matrix}\nНажмите любую кнопку чтобы продолжить...\n");
            Console.ReadKey();
        }
    }

    public static int GetOption(string menuOption) {
        while (true) {
            Console.Clear();
            Console.WriteLine(menuOption);
            string option = Console.ReadLine();
            int res = 0;

            if (option == "q") return -1;
            if (int.TryParse(option, out res)) return res;
        }
    }
}