using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Word", menuName = "Word")]
public class Word:ScriptableObject
{
    public WordValue[] Values;
    public Sprite Image;
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
