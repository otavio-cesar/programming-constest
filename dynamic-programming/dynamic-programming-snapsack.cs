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
     * Complete the 'unboundedKnapsack' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts following parameters:
     *  1. INTEGER k
     *  2. INTEGER_ARRAY arr
     */
    public static long[][] reachable = new long [2001][];
    
    public static int unboundedKnapsack(int k, List<int> arr)
    {
        for(int i = 0; i < reachable.Length; i++)
        {
            reachable[i] = new long[2001];
            for(int j = 0; j < reachable[i].Length; j++)
            {
                reachable[i][j] = -1;
            } 
        } 
        
        pack(k, 0, k, arr);
        
        // Print DP
        // for(int i = 0; i < 15; i++)
        // {
        //     var s = "";
        //     for(int j = 0; j < 17; j++)
        //     {
        //         s+=" "+reachable[i][j];
        //     } 
        //     System.Console.WriteLine(s);
        // }
        
        for(int i = 0; i <= k; i++)
        {
            for(int j = 2000; j >= 0; j--)
            {
                // System.Console.WriteLine($"L{i}C{j}E{reachable[i][j]}");
                if(reachable[i][j] != -1) return k-i;
            } 
        } 
        
        return 0;
    }
    
    private static long pack(int n, int level, int k, List<int> arr)
    {
        if (n < 0)
            return int.MaxValue;
        
        if (n == 0)
        {
            reachable[n][level] = n;
            return k;
        }
        
        if (reachable[n][level] != -1) return reachable[n][level];
        reachable[n][level] = n;
        
        long ans = 0;
        for(int i = 0; i < arr.Count; i++)
        {
            pack(n - arr[i], level + 1, k, arr); 
        }
        
        return reachable[n][level]; 
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());
        while(true){

        string[] firstMultipleInput = Console.ReadLine().TrimEnd().Split(' ');

        int n = Convert.ToInt32(firstMultipleInput[0]);
        
        int k = Convert.ToInt32(firstMultipleInput[1]);

        List<int> arr = Console.ReadLine().TrimEnd().Split(' ').ToList().Select(arrTemp => Convert.ToInt32(arrTemp)).ToList();

        int result = Result.unboundedKnapsack(k, arr);

        textWriter.WriteLine(result);
        textWriter.Flush();
        t--;
        if(t==0)break;
        }
        textWriter.Close();
    }
}
