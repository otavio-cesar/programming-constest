namespace ValidPath;

public class UnionFind
{
    private int[] parent;

    public UnionFind(int n)
    {
        parent = new int[n];

        for (int i = 0; i < n; i++)
            parent[i] = i;
    }

    public int Find(int x)
    {
        if (parent[x] != x)
            parent[x] = Find(parent[x]);

        return parent[x];
    }

    public void Union(int a, int b)
    {
        int rootA = Find(a);
        int rootB = Find(b);

        if (rootA != rootB)
            parent[rootA] = rootB;
    }
}

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination) return true;
        UnionFind uf = new UnionFind(n);

        foreach (var edge in edges)
        {
            uf.Union(edge[0], edge[1]);
        }
        return uf.Find(source) == uf.Find(destination);
    }
}

public partial class Program
{
    public static void Main()
    {
        Solution solution = new Solution();

        //Input: n = 3, edges = [[0,1],[1,2],[2,0]], source = 0, destination = 2
        // int n = 3;
        // int[][] edges = new int[3][];
        // edges[0] = new int[] {0, 1};
        // edges[1] = new int[] {1, 2};
        // edges[2] = new int[] {2, 0};
        // int source = 0;
        // int destination = 2;

        // Input: n = 6, edges = [[0,1],[0,2],[3,5],[5,4],[4,3]], source = 0, destination = 5
        int n = 6;
        int[][] edges = new int[5][];
        edges[0] = new int[] { 0, 1 };
        edges[1] = new int[] { 0, 2 };
        edges[2] = new int[] { 3, 5 };
        edges[3] = new int[] { 5, 4 };
        edges[4] = new int[] { 4, 3 };
        int source = 0;
        int destination = 5;

        bool result = solution.ValidPath(n, edges, source, destination);

        Console.WriteLine(result);
    }
}