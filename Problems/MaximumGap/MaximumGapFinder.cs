namespace MedianOfTwoSortedArrays.MaximumGap;

public class MaximumGapFinder
{
    public int MaximumGap(int[] nums)
    {
        int min = nums[0];
        int max = nums[0];

        for (int i = 1; i < nums.Length; i++)
        {
            min = Math.Min(min, nums[i]);
            max = Math.Max(max, nums[i]);
        }

        int range = max - min + 1;
        float delta = (float)range / nums.Length;
        
        
        return 0;
    }
}