using System;
using System.Collections.Generic;

namespace _02._01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

private static Dictionary<string, int> CreateTestData()
{
    Dictionary<string, int> dict = new Dictionary<string, int>()
    {
        {"Accounting", 1},
        {"Marketing", 2},
        {"Operatlons", 3}
    };
    return dict;
}

private static bool FindInList(string searchTerm)
{
    Dictionary<string, int> data = CreateTestData();

    if (data.ContainsKey(searchTerm))
    {
        return true;
    }
    else
    {
        return false;
    }
}
    }
}

