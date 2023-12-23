using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public static class IEnumerableExtensions
{
    private static Random random = new Random();

    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> input)
    {
        T[] inputArray = input.ToArray();
        int randomIndex;
        for(int i  = 0; i < inputArray.Length; i++)
        {
            randomIndex = GetRandomSwapIndex(inputArray, i);
            inputArray = SwapValues(inputArray, i, randomIndex);
        }
        return inputArray;
    }

    private static int GetRandomSwapIndex<T>(T[] array, int index)
    {
        return index + random.Next(array.Length - index);
    }

    private static T[] SwapValues<T>(T[] array, int firstIndex, int secondIndex)
    {
        T firstIndexContent = array[firstIndex];
        array[firstIndex] = array[secondIndex];
        array[secondIndex] = firstIndexContent;
        return array;
    }
}