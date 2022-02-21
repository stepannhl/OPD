namespace UserCompare;

class DescendingCompare : IComparable {
    public int Compare(double a, double b) {
        return a.CompareTo(b);
    }   
}