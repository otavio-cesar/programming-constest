using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

// 
class Result
{

    /*
     * Complete the 'getWays' function below.
     *
     * The function is expected to return a LONG_INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER n
     *  2. LONG_INTEGER_ARRAY c
     */
    
    public static List<long> coins = new List<long>();
    public static long Max = 0;
    public static long[][] memo = new long [31375][];
    
    public static long getWays(int n, List<long> c)
    {
        coins = c;
        Max = n;
        
        for(int i = 0; i < memo.Length; i++)
        {
            memo[i] = new long[250];
            for(int j = 0; j < memo[i].Length; j++)
            {
                memo[i][j] = -1;
            } 
        } 
        
        return change((long)n, 0, 0);
    }
    
    private static long change(long n, int level, int min)
    {
        if (n < 0)
            return 0;
        
        if (n == 0)
            return 1;
        
        if (memo[n][level] != -1) return memo[n][level];
        
        long ans = 0;
        for(int i = min; i < coins.Count; i++)
        {
            ans += change(n - coins[i], level + 1, i); 
        }
        
        return memo[n][level] = ans; 
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);

        int m = Convert.ToInt32(firstMultipleInput[1]);

        List<long> c = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(cTemp => Convert.ToInt64(cTemp)).ToList();

        // Print the number of ways of making change for 'n' units using coins having the values given by 'c'

        long ways = Result.getWays(n, c);

        textWriter.WriteLine(ways);

        textWriter.Flush();
        textWriter.Close();
    }
}
