namespace MedianOfTwoSortedArrays.MedianOf2Arrays;

public class MedianFinder
{
    public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length == 0)
        {
            return FindMedian(nums2);
        }

        if (nums2.Length == 0)
        {
            return FindMedian(nums1);
        }
        bool evenLength = (nums1.Length + nums2.Length) % 2 == 0;
        int goal = evenLength ? (nums1.Length + nums2.Length) / 2 - 1 : (nums1.Length + nums2.Length) / 2;
        bool t = false;

        int lesserPart = 0;
        int nnb = (nums2.Length - 1) / 2;
        int na = CountLesserElements(nums1, nums2[nnb], 0, nums1.Length - 1, goal - nnb);
        int resa = na + nnb;
        if (resa == goal)
        {
            if (evenLength)
            {
                lesserPart = nums2[nnb];
                t = true;
            }
            else
            {
                return nums2[nnb];
            }
        }
        
        int nna = (nums1.Length - 1) / 2;
        int nb = CountLesserElements(nums2, nums1[nna], 0, nums2.Length - 1, goal - nna);
        int resb = nb + nna;
        if (resb == goal)
        {
            if (evenLength)
            {
                lesserPart = nums1[nna];
                t = true;
            }
            else
            {
                return nums1[nna];
            }
        }
        int astart = 0;
        int aend = nums1.Length - 1;
        int bstart = 0;
        int bend = nums2.Length - 1;

        if (!t)
        {
            do
            {
                if (resa < goal)
                {
                    bstart += (bend - bstart) / 2 + 1;
                }
                else
                {
                    bend -= (bend - bstart) / 2 + 1;
                }
            
                if (resb < goal)
                {
                    astart += (aend - astart) / 2 + 1;
                }
                else
                {
                    aend -= (aend - astart) / 2 + 1;
                }

                nna = astart + (aend - astart) / 2;
                nnb = bstart + (bend - bstart) / 2;
                na = CountLesserElements(nums1, nums2[nnb], astart, aend, goal - nnb);
                resa = na + nnb;
                if (resa == goal)
                {
                    if (evenLength)
                    {
                        lesserPart = nums2[nnb];
                        break;
                    }
                    return nums2[nnb];
                }
                nb = CountLesserElements(nums2, nums1[nna], bstart, bend, goal - nnb);
                resb = nb + nna;
                if (resb == goal)
                {
                    if (evenLength)
                    {
                        lesserPart = nums1[nna];
                        break;
                    }
                    return nums1[nna];
                }
            }
            while (true);
        }
        astart = 0;
        aend = nums1.Length - 1;
        bstart = 0;
        bend = nums2.Length - 1;
        
        nnb = (nums2.Length - 1) / 2;
        na = CountBiggerElements(nums1, nums2[nnb], 0, nums1.Length - 1);
        resa = na + bend - nnb;
        if (resa == goal)
        {
            return (double)(nums2[nnb] + lesserPart) / 2;
        }
        
        nna = (nums1.Length - 1) / 2;
        nb = CountBiggerElements(nums2, nums1[nna], 0, nums2.Length - 1);
        resb = nb + aend - nna;
        if (resb == goal)
        {
            return (double)(nums1[nna] + lesserPart) / 2;
        }

        
        do
        {
            if (resa > goal)
            {
                
                bstart += (bend - bstart) / 2 + 1;
            }
            else
            {
                bend -= (bend - bstart) / 2 + 1;
            }
            
            if (resb > goal)
            {
                astart += (aend - astart) / 2 + 1;
            }
            else
            {
                aend -= (aend - astart) / 2 + 1;
                
            }

            nna = astart + (aend - astart) / 2;
            nnb = bstart + (bend - bstart) / 2;
            na = CountBiggerElements(nums1, nums2[nnb], astart, aend);
            resa = na + nums2.Length - nnb - 1;
            if (resa == goal)
            {
                return (double)(nums2[nnb] + lesserPart) / 2;
            }
            nb = CountBiggerElements(nums2, nums1[nna], bstart, bend);
            resb = nb + nums1.Length - nna - 1;
            if (resb == goal)
            {
                return (double)(nums1[nna] + lesserPart) / 2;
            }
        }
        while (true);
    }

    public static int CountLesserElements(int[] a, double x, int start, int end, int goal)
    {
        int startcopy = start;
        int endcopy = end;
        int l = end - start + 1;
        int k = start + l / 2;

        if (start > end) return 0;
        if (l == 1)
        {
            return a[k] <= x ? start + 1 : start;
        }
        if (l == 2)
        {
            k -= 1;
        }
        while (!(a[k] <= x && a[k + 1] >= x))
        {
            if (a[k] >= x)
            {
                if (k == startcopy) return startcopy;
                end = k;
                k = start + (k - start) / 2;
            }
            else
            {
                if (k + 1 == endcopy) return endcopy + 1;
                start = k;
                k = end - (end - k) / 2;
            }
        }

        if (a[k] != x) return k + 1;

        while (k != goal)
        {
            if (k < goal)
                k++;
            else
                k--;
            
            if (a[k] != x) break;
        }

        return k;
    }
    
    public static int CountBiggerElements(int[] a, double x, int start, int end)
    {
        int startcopy = start;
        int endcopy = end;
        int l = end - start + 1;
        int k = start + l / 2;

        if (start > end) return 0;
        if (l == 1)
        {
            if (x <= a[start])
            {
                return a.Length - start;
            }
            return a.Length - start - 1;
        }
        if (l == 2)
        {
            k -= 1;
        }
        while (!(a[k] <= x && a[k + 1] >= x))
        {
            if (a[k] >= x)
            {
                if (k == startcopy) return endcopy - startcopy + 1;
                end = k;
                k = start + (k - start) / 2;
            }
            else
            {
                if (k + 1 == endcopy) return 0;
                start = k;
                k = end - (end - k) / 2;
            }
        }

        if (a[k] != x) return endcopy - k;

        while (k > 0 && a[k] == x)
        {
            k--;
        }

        return endcopy - k;
    }

    private static double FindMedian(int[] a)
    {
        return a.Length % 2 == 0 ? (double)(a[(a.Length - 1) / 2] + a[(a.Length - 1) / 2 + 1]) / 2 : a[(a.Length - 1) / 2];
    }
} 