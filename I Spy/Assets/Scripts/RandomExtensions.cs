using System;
using System.Linq;

public static class RandomExtensions
{
    public static void Shuffle<T>(this T[] array)
    {
        Random rnd = new Random();
        array = array.OrderBy(x => rnd.Next()).ToArray();
    }
}