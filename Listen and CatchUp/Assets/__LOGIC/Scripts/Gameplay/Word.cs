using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "New Word", menuName = "Word")]
public class Word:ScriptableObject
{
    public WordValue[] Values;
    public Sprite Image;

    public string In(Language language)
    {
        return Values.FirstOrDefault(x => x.Language == language).Value;
    }
}

[Serializable]
public struct WordValue
{
    public Language Language;
    public string Value;
}

[Serializable]
public enum Language
{
    English,Portuguese
}
