//using System.Runtime.Intrinsics.X86;

//Day 4: Find Most Frequent Element
//Task:
//Input an integer array.
//• Find the element that appears most frequently.
//• Algorithm: Use a Dictionary to count occurrences of each element.

using System.ComponentModel.DataAnnotations.Schema;

namespace _30dayLAB___CSharp.Day4_Find_Most_Frequent_Element
{
    internal class FindElement
    {
        private Dictionary<int, int> frequencyDict = new Dictionary<int, int>();
        
        public FindElement(int[] arr)
        {
                foreach (int i in arr)
                {
                    if (frequencyDict.ContainsKey(i))
                    {
                        frequencyDict[i]++;
                    }
                    else
                    {
                        frequencyDict.Add(i, 1);
                    }
                }
            int mostFrequent = frequencyDict.OrderByDescending(x => x.Value).First().Key;
            Console.WriteLine("Phần tử xuất hiện nhiều nhất là: " + mostFrequent);
        }
    }
}
