namespace MedianOfTwoSortedArrays.MaximumGap;

public class CountingSort
{
    public int[] Sort(int[] a, int k)
    {
        int[] b = new int[a.Length];
        int[] c = new int[k + 1];

        for (int i = 0; i < a.Length; i++)
        {
            c[a[i]]++;
        }
        
        for (int i = 1; i < c.Length; i++)
        {
            c[i] += c[i - 1];
        }
        
        for (int i =  a.Length -1; i >= 0; i--)
        {
            b[c[a[i]] - 1] = a[i];
            c[a[i]]--;
        }

        return b;
    }
}