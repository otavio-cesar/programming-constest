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
    
    public static bool[][] calculated = new bool[52][];
    public static long[][] table = new long[52][];
    
    public static long getWays(int n, List<long> c)
    {
        
        for (int i = 0; i < 52; i++)
        {
            calculated[i] = new bool[252];
            table[i] = new long[252];
        }
        return change(0, n, c);
    }
    
    private static long change(int n, int m, List<long> coins)
    {
        if (m < 0) return 0;
        if (n >= coins.Count()) return 0;
        if (m == 0) return 1;
        
        if (calculated[n][m] == false)
        {
            table[n][m] = 
                change(n, (int)(m - coins.ElementAt(n)), coins) + change(n + 1, m, coins);
            calculated[n][m] = true;
        }
        return table[n][m]; 
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
