namespace ValidPathBFS;

public class Solution
{
    public bool ValidPath(int n, int[][] edges, int source, int destination)
    {
        if (source == destination) return true;
        List<int>[] graph = new List<int>[n];

        for (int i = 0; i < n; i++)
            graph[i] = new List<int>();

        foreach (var e in edges)
        {
            graph[e[0]].Add(e[1]);
            graph[e[1]].Add(e[0]);
        }

        bool[] visited = new bool[n];
        Queue<int> q = new Queue<int>();

        q.Enqueue(source);
        visited[source] = true;

        while (q.Count > 0)
        {
            int node = q.Dequeue();

            if (node == destination)
                return true;

            foreach (int neighbor in graph[node])
            {
                if (!visited[neighbor])
                {
                    visited[neighbor] = true;
                    q.Enqueue(neighbor);
                }
            }
        }

        return false;
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