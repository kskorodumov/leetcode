namespace MedianOfTwoSortedArrays.MultiSet;

public class MultiSet
{
    private class Val
    {
        public int Value;

        public Val(int value)
        {
            Value = value;
        }
    }

    private List<Val> _list = new();
    private Dictionary<int, (Val, int)> _dictionary = new();
    public bool Add(int value)
    {
        _list.Add(new Val(value));
        // if ()
        return true;
    }

    public bool Remove(int value)
    {
        return false;
    }

    public int GetRandom()
    {
        return 0;
    }
}