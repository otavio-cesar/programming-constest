using System;
public class Solution {
    public int MaxArea(int[] height) {
        int i = 0, j = height.Length - 1;
        int area = Math.Min(height[i], height[j]) * (j - i);
        int areaAux = -1;
        while (i < j)
        {
            if (height[i] < height[j])
            {
                i++;
            }
            else
            {
                j--;
            }
            areaAux = Math.Min(height[i], height[j]) * (j - i);
            if (area < areaAux)
                area = areaAux;
        }
        return area;
    }
}