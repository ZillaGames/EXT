using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public static class RandomProbabilityExt
{
    public static T GetRandom<T>(IEnumerable<T> itemList, System.Func<T, float> getProb)
    {
        var probList = itemList.Select(getProb).ToArray();

        return Recursive(
            itemList.ToArray(),
            probList,
            0,
            Random.value * probList.Sum());
    }

    static T Recursive<T>(T[] itemList, float[] probabilities, int index, float value)
        => value < 0f 
            ? itemList[index]
            : Recursive(itemList, probabilities, index + 1, value - probabilities[index]);
    
}
