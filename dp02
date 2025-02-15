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
    
    public static List<long> coins = new List<long>();
    public static long Max = 0;
    public static long[][] memo = new long [31375][];
    public static List<long>[][] his = new List<long> [31375][];
    public static List<long> sol = new List<long>();
    public static long t=0;
    public static long getWays(int n, List<long> c)
    {
        coins = c;
        Max = n;
        int qnt = 0;
        
        // inicializa
        for(int i = 0; i < memo.Length; i++)
        {
            memo[i] = new long[n];
            his[i] = new List<long>[n];
            for(int j = 0; j < memo[i].Length; j++)
            {
                memo[i][j] = 0;
                his[i][j] = new List<long>();
            } 
        } 
        
        // preenche primeira linha tabela
        for(int i = 0; i < c.Count; i++)
        {
            if(n - c.ElementAt(i) >= 0)
            {
                // System.Console.WriteLine($"{0} {n - c.ElementAt(i)}");
                his[0][n - c.ElementAt(i)].Add(c.ElementAt(i));
                memo[0][n - c.ElementAt(i)] = 1;
            } 
        } 
        
        // verifica se na primeira busca existe solucao
        if (finalizou(memo, 0)) return 0;
        printline(memo, 0);
        
        // preenche restante da tabela. Existe N Niveis. Cada nivel e uma lista com o indice dos elementos representando o Troco
        int level = 1;
        while(level > 0)
        {
            for(int change = 0; change < n; change++)
            {
                if(memo[level - 1][change] == 1L)
                {
                    for(int j = 0; j < c.Count; j++)
                    {
                        if(change - c.ElementAt(j) >= 0)
                        {
                            his[level][change - c.ElementAt(j)].Add(c.ElementAt(j));
                            memo[level][change - c.ElementAt(j)] = 1;  
                        }
                    }
                } 
            }
            
            printline(memo, level);
            
            // caso percorreu todas possibilidades, para preenchimento da tabela
            if (finalizou(memo, level)) break;
            
            level++;
        }
        
        //printhis(his);
        for(int j = level-1; j >=0; j--)
        {
            for(int i = 0; i < n; i++)
            {   
                var s = "";
                System.Console.WriteLine($"{j}-{i}");
                for(int k = 0; k < his[j][i].Count; k++)
                {   
                    s+=$"{his[j][i].ElementAt(k)},";
                }
                System.Console.WriteLine($"{s}");
            } 
        }
        
        level--;
        while(level>=0)
        {
            for(int i = 0; i < n; i++)
            {
                if(memo[level][i] == 1)
                {
                    for(int j = 0; j < his[level][i].Count; j++)
                    {   
                        System.Console.WriteLine($"level\tchange\tprev-c\tcoin");
                        System.Console.WriteLine($"{level}\t{i}\t{his[level][i].ElementAt(j)+i}\t{his[level][i].ElementAt(j)}");
                        rec(his, n, level - 1, his[level][i].ElementAt(j));
                    } 
                }
            }
            level--;
        }
        
        return t;
    }
    
    public static void rec(List<long>[][] his, int n, long level, long change, long coin =0)
    {
        System.Console.WriteLine($"level\tchange\tcoin\t");
        //System.Console.WriteLine($"{level}\t{change}\t{coin}");
        if (level < 0 || change >=n)
        {
            if(change == n)
            {
                t++;
            }
            System.Console.WriteLine($"{level}\t{change}\t");
            return;
        }
        
        for(int j = 0; j < his[level][change].Count; j++)
        {   
            System.Console.WriteLine($"{level}\t{change}\t{his[level][change].ElementAt(j)}");
            var el = his[level][change].ElementAt(j);
            his[level][change].RemoveAt(j);
            rec(his, n, level - 1, el+change, el);
        } 
    }
    
    public static bool finalizou(long[][] l, int level)
    {
        for(int change = 0; change < l[level].Length; change++)
        {
            if(l[level][change]==1)
                return false;
        }
        return true;
    }
    
    public static void printline(long[][] l, int level)
    {
        // System.Console.WriteLine($"level {level}");
        var s = "";
        for(int change = 0; change < l[level].Length; change++)
        {
            s+=$"\t{l[level][change]}";
        }
        System.Console.WriteLine(s);
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
