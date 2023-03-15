namespace MaximumGap;

public class RadixSort
{
    public int[] Sort(int[] a)
    {
        int max = 0;

        for (int j = 0; j < a.Length; j++)
        {
            if (a[j] > max) max = a[j];
        }

        var bas = 10;
        int maxDig = (int)Math.Ceiling(Math.Log(max, bas));

        return DigitSort(a, bas, maxDig);
    }

    private int[] DigitSort(int[] a, int bas, int maxDig)
    {
        var b = a;
        int pow = 1;

        for (int i = 1; i <= maxDig; i++)
        {
            
            b = DigitSortInternal(b, pow*bas, pow, bas);
            pow *= bas;
        }
        
        return b;
    }
    
    private int[] DigitSortInternal(int[] a, int mod, int div, int k)
    {
        var b = new int[a.Length];
        var c = new int[k];
        
        for (int i = 0; i < a.Length; i++)
        {
            c[a[i] % mod / div]++;
        }
        
        for (int i = 1; i < c.Length; i++)
        {
            c[i] += c[i - 1];
        }
        
        for (int i =  a.Length -1; i >= 0; i--)
        {
            b[c[a[i] % mod / div] - 1] = a[i];
            c[a[i] % mod / div]--;
        }
        
        return b;
    }
}