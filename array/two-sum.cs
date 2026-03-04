namespace TwoSum;

public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        Dictionary<int, List<int>> values = new Dictionary<int, List<int>>();
        for (int i = 0; i < nums.Length; i++)
        {
            if (!values.ContainsKey(nums[i]))
            {
                values[nums[i]] = new List<int>();
            }
            values[nums[i]].Add(i);
        }

        for (int i = 0; i < nums.Length; i++)
        {
            if (values.TryGetValue(target - nums[i], out List<int> indices))
            {
                foreach (int index in indices)
                {
                    if (index == i)
                        continue;
                    return [i, index];
                }
            }
        }
        throw new ArgumentException("No two sum solution");
    }
}

public partial class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        int[] nums = { 3,3 };
        int target = 6;

        int[] result = solution.TwoSum(nums, target);

        Console.WriteLine($"[{string.Join(", ", result)}]");
    }
}