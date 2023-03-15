namespace MultiSet;

public class MultiSet
{
    private class ValueLinks
    {
        public Stack<ListNode> Indices = new ();
        public ValueLinks(ListNode node)
        {
            Indices.Push(node);
        }
    }

    private class ListNode
    {
        public int Value;
        public int Index;

        public ListNode(int value, int index)
        {
            Value = value;
            Index = index;
        }
    }

    private readonly Dictionary<int, ValueLinks?> _dic = new();
    private readonly List<ListNode> _list = new();
    private readonly Random _random = new();
    
    public bool Add(int val)
    {
        ListNode node = new ListNode(val, _list.Count);
        ValueLinks? v;
        if (_dic.TryGetValue(val, out v))
        {
            v.Indices.Push(node);
            _list.Add(node);
            return false;
        }

        
        v = new ValueLinks(node);
        _list.Add(node);
        _dic.Add(val, v);
        return true;
    }

    public bool Remove(int val)
    {
        if (_dic.TryGetValue(val, out ValueLinks? v))
        {
            ListNode node = v.Indices.Pop();
            ListNode t = _list[^1];//wtf
            _list[node.Index] = t;
            t.Index = node.Index;
            _list.RemoveAt(_list.Count - 1);
            if (v.Indices.Count == 0)
            {
                _dic.Remove(val);
            }

            return true;
        }

        return false;
    }

    public int GetRandom()
    {
        int index = _random.Next(_list.Count);
        return _list[index].Value;
    }
}