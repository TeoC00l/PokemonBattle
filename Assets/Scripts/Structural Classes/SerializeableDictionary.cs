//@Author: Teodor Tysklind / FutureGames / Teodor.Tysklind@FutureGames.nu

using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable] public class SerializeableDictionary<E> : IManager
{
    private Dictionary<string, E> dictionary = new Dictionary<string, E>();

    public E GetElement(string name)
    {
        return dictionary[name];
    }

    [SerializeField] private KeyValuePairs[] keyValuePairs = default;

    [Serializable] public struct KeyValuePairs
    {
        public string name;
        public E element;
    }

    public void InitializeManager()
    {
        for (int i = 0; i < keyValuePairs.Length; i++)
        {
            dictionary.Add(keyValuePairs[i].name, keyValuePairs[i].element);
        }
    }
}
