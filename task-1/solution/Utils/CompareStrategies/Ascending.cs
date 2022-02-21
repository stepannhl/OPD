namespace UserCompare;

class AscendingCompare : IComparable {
    public int Compare(double a, double b) {
        return -1 * a.CompareTo(b);
    }
}