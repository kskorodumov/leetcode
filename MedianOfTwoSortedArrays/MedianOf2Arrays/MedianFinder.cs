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
        int astart = 0;
        int aend = nums1.Length - 1;
        int bstart = 0;
        int bend = nums2.Length - 1;
        int lesserPart;
        bool lesserPartIn1 = false;
        while (true)
        {
            int ind1 = astart + (aend - astart) / 2;
            int remainder1 = goal - ind1;
            int test = TestForLesser(nums2, nums1[ind1], remainder1);
            if (test == 0)
            {
                if (!evenLength)
                {
                    return nums1[ind1];
                }
                lesserPartIn1 = true;
                lesserPart = nums1[ind1];
                break;
            }

            if (test > 0)
            {
                aend = ind1;
            }
            else
            {
                if (astart == ind1)
                {
                    astart += 1;
                }
                else
                {
                    astart = ind1;
                }
            }
            
            int ind2 = bstart + (bend - bstart) / 2;
            int remainder2 = goal - ind2;
            test = TestForLesser(nums1, nums2[ind2], remainder2);
            
            if (test == 0)
            {
                if (!evenLength)
                {
                    return nums2[ind2];
                }
                lesserPart = nums2[ind2];
                break;
            }

            if (test > 0)
            {
                bend = ind2;
            }
            else
            {
                if (bstart == ind2)
                {
                    bstart += 1;
                }
                else
                {
                    bstart = ind1;
                }
            }
        }
        //================
        if (!lesserPartIn1)
        {
            astart = 0;
            aend = nums1.Length - 1;
        }

        if (lesserPartIn1)
        {
            bstart = 0;
            bend = nums2.Length - 1;
        }
        goal += 1;
        while (true)
        {
            int ind1 = astart + (aend - astart) / 2;
            int remainder1 = goal - ind1;
            int test = TestForLesser(nums2, nums1[ind1], remainder1);
            if (test == 0)
            {
                return (double)(lesserPart + nums1[ind1]) / 2;
            }

            if (test > 0)
            {
                aend = ind1;
            }
            else
            {
                if (astart == ind1 && astart != nums1.Length - 1)
                {
                    astart += 1;
                }
                else
                {
                    astart = ind1;
                }
            }
            
            int ind2 = bstart + (bend - bstart) / 2;
            int remainder2 = goal - ind2;
            test = TestForLesser(nums1, nums2[ind2], remainder2);
            
            if (test == 0)
            {
                return (double)(lesserPart + nums2[ind2]) / 2;
            }

            if (test > 0)
            {
                bend = ind2;
            }
            else
            {
                if (bstart == ind2 && bstart != nums2.Length - 1)
                {
                    bstart += 1;
                }
                else
                {
                    bstart = ind1;
                }
            }
        }
    }

    
    private static double FindMedian(int[] a)
    {
        return a.Length % 2 == 0 ? (double)(a[(a.Length - 1) / 2] + a[(a.Length - 1) / 2 + 1]) / 2 : a[(a.Length - 1) / 2];
    }
    
    public static int TestForLesser(int[] a, int x, int goal)
    {
        if (a.Length == 1)
        {
            if (a[0] <= x && goal == 1) return 0;
            if (a[0] > x && goal == 0) return 0;

            if (a[0] > x) return -1;
            return 1;
        }

        if (goal == 0)
        {
            if (a[0] >= x) return 0;
            return 1;
        }

        if (goal >= a.Length)
        {
            if (goal == a.Length)
            {
                if (a[a.Length - 1] <= x) return 0;
                return -1;
            }

            return 1;
        }
        if (a[goal - 1] <= x && a[goal] >= x)
        {
            return 0;
        }

        if (a[goal - 1] > x)
        {
            return -1;// x is too small
        }

        return 1; // x is too big
    }
} 