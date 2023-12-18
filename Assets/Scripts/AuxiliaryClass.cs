using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System.Reflection;

public static class AuxiliaryClass
{
    private static System.Random rng = new System.Random();

    /// <summary>
    /// Fisher-Yates shuffling algorythm
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="list">The list of T type that's going to be suffled</param>
    public static void Shuffle<T>(this IList<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = rng.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }


    /// <summary>
    /// Changes the value of a Boolean variable randomly
    /// </summary>
    /// <param name="b">Is the boolean parameter that we are using</param>
    /// <param name="seedSize">Indicates how many variables the pool of possibilities will have</param>
    public static void RandomBool(this bool b, int seedSize = 4)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < seedSize; i++)
        {
            list.Add(i % 2);
        }

        list.Shuffle();

        if (list[rng.Next(list.Count())] == 0) b = false;
        else b = true;
    }


    /// <summary>
    /// Generates a new Random boolean value
    /// </summary>
    /// <param name="seedSize">Indicates how many variables the pool of possibilities will have</param>
    /// <returns></returns>
    public static bool RandomBool(int seedSize = 4)
    {
        List<int> list = new List<int>();
        for (int i = 0; i < seedSize; i++)
        {
            list.Add(i % 2);
        }

        list.Shuffle();

        if (list[rng.Next(list.Count())] == 0) return false;
        else return true;
    }




    /// <summary>
    /// Allows the copy of Components via Reflection
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="comp"></param>
    /// <param name="other"></param>
    /// <returns></returns>
    public static T GetCopyOf<T>(this Component comp, T other) where T : Component
    {
        Type type = comp.GetType();
        if (type != other.GetType()) return null; // type mis-match
        BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Default | BindingFlags.DeclaredOnly;
        PropertyInfo[] pinfos = type.GetProperties(flags);
        foreach (var pinfo in pinfos)
        {
            if (pinfo.CanWrite)
            {
                try
                {
                    pinfo.SetValue(comp, pinfo.GetValue(other, null), null);
                }
                catch { } // In case of NotImplementedException being thrown. For some reason specifying that exception didn't seem to catch it, so I didn't catch anything specific.
            }
        }
        FieldInfo[] finfos = type.GetFields(flags);
        foreach (var finfo in finfos)
        {
            finfo.SetValue(comp, finfo.GetValue(other));
        }
        return comp as T;
    }

    /// <summary>
    /// Add Component extensions that allows to copy values from existing Gameobject's component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="go"></param>
    /// <param name="toAdd"></param>
    /// <returns></returns>
    public static T AddComponent<T>(this GameObject go, T toAdd) where T : Component
    {
        return go.AddComponent<T>().GetCopyOf(toAdd) as T;
    }


    public static int CountWords(this string text)
    {
        if (string.IsNullOrWhiteSpace(text))
        {
            return 0;
        }

        string[] words = text.Split(new char[] { ' ', '\t', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return words.Length;
    }

}

