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
     * Complete the 'redJohn' function below.
     *
     * The function is expected to return an INTEGER.
     * The function accepts INTEGER n as parameter.
     */

    public static bool[] calculated = new bool[41];
    public static int[] table = new int[41];
    
    public static int redJohn(int n)
    {
        for (int i = 0; i < n; i++)
        {
            calculated[i] = false;
            table[i] = 0;
        }
        
        for (int i = 0; i < 40000; i++)
        {
            primes[i] = -1;
            primesGroup[i] = -1;
        }
        
        return countPrime(wall(n));
    }
    
    // Algoritmo para calcular números primos até N (max). O ( log log b)
    static public bool[] MakeSieve(int max)
    {
        // Make an array indicating whether numbers are prime.
        bool[] is_prime = new bool[max + 1];
        for (int i = 2; i <= max; i++) is_prime[i] = true;

        // Cross out multiples.
        for (int i = 2; i <= max; i++)
        {
            // See if i is prime.
            if (is_prime[i])
            {
                // Knock out multiples of i.
                for (int j = i * 2; j <= max; j += i)
                    is_prime[j] = false;
            }
        }
            
        return is_prime;
    }
    
    private static int countPrime(int n)
    {
        var primos = MakeSieve(n);
        int primeCount = 0;
        for (int i = 2; i <= n; i++)
        {
            if (primos[i])
            {
                primeCount++;
            }
        }
        return primeCount;
    }
    
    private static int wall(int n)
    {
        if (n < 0) return 0;
        if (n == 1 || n == 2 || n == 3 || n == 0) return 1;
 
        if (calculated[n] == false)
        {
            table[n] = wall(n - 1) + wall(n -4);
            calculated[n] = true;
        }
        return table[n]; 
    }
}

class Solution
{
    public static void Main(string[] args)
    {
        TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int t = Convert.ToInt32(Console.ReadLine().Trim());

        for (int tItr = 0; tItr < t; tItr++)
        {
            int n = Convert.ToInt32(Console.ReadLine().Trim());

            int result = Result.redJohn(n);

            textWriter.WriteLine(result);
        }

        textWriter.Flush();
        textWriter.Close();
    }
}
