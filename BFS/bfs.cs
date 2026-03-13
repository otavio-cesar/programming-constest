
using System.Text;

namespace IsSameTree;

public class TreeNode
{
    public int val;
    public TreeNode left;
    public TreeNode right;
    public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
    {
        this.val = val;
        this.left = left;
        this.right = right;
    }
}

public class Solution
{
    public bool IsSameTree(TreeNode p, TreeNode q)
    {
        string a = getPath(p);
        string b = getPath(q);
        // Console.WriteLine($"a: {a}");
        // Console.WriteLine($"b: {b}");
        return a == b;
    }

    private string getPath(TreeNode p)
    {
        Queue<TreeNode> queue = new Queue<TreeNode>();

        queue.Enqueue(p);

        StringBuilder path = new StringBuilder();

        while (queue.Count > 0)
        {
            TreeNode node = queue.Dequeue();
            // Console.WriteLine(node?.val);
            path.Append(node?.val.ToString() ?? "null");

            if (node == null || (node.left == null && node.right == null))
            {
                continue;
            }
            var neighbor = node?.left;
            queue.Enqueue(neighbor);

            neighbor = node?.right;
            queue.Enqueue(neighbor);
        }

        return path.ToString();
    }
}

public partial class Program
{
    public static void Main()
    {
        Solution solution = new Solution();
        // p = [1,2,1], q = [1,1,2]
        // TreeNode p = new TreeNode(1, new TreeNode(2), new TreeNode(1));
        // TreeNode q = new TreeNode(1, new TreeNode(1), new TreeNode(2));

        //Input: p = [1,2], q = [1,null,2]
        TreeNode p = new TreeNode(1, new TreeNode(2));
        TreeNode q = new TreeNode(1, null, new TreeNode(2));
        
        bool result = solution.IsSameTree(p, q);
        
        Console.WriteLine($"{result}");
    }
}