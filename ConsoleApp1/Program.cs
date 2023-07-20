int[] d = { 1, 2, 5, 4, 3, 2, 1, 3, 3, 2, 1 };

var s = new Solution();

s.Candy(d);

public class Solution {
    public int Candy(int[] ratings) {
        if (ratings.Length == 1)
        {
            return 1;
        }
        int res = 0;
        // int i = 1;
        // 1 0 2 => 2 1 2
        // 1 2 2 => 1 2 1
        // 1 2 5 4 3 2 1 3 3 2 1 => 1 2 5 4 3 2 1 2 3 2 1
        List<(int start, int end)> up = new();
        List<(int start, int end)> down = new();

        int startUp = -1;
        int startDown = -1;
        for (int i = 1; i < ratings.Length; i++)
        {
            if (ratings[i] <= ratings[i - 1])
            {
                if (startUp != -1)
                {
                    up.Add((startUp, i - 1));
                }

                startUp = -1;
            }else
            {
                if (startUp == -1)
                {
                    startUp = i - 1;
                }
            }

            if (ratings[i] >= ratings[i - 1])
            {
                if (startDown != -1)
                {
                    down.Add((startDown, i - 1));
                }

                startDown = -1;
            }else
            {
                if (startDown == -1)
                {
                    startDown = i - 1;
                }
            }
        }

        return 0;
    }
}