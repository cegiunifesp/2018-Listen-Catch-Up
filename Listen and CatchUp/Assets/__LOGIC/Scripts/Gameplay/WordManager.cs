using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordManager : SingletonBehaviour<WordManager>
{

    public Word[] WordList;

    private List<Word> _unusedWords = new List<Word>();
    private List<Word> _onGridWords = new  List<Word>();
    private List<Word> _usedWords = new List<Word>();

    private void Awake()
    {
        _unusedWords.AddRange(WordList);
    }

    public Word GetRandomWord()
    {
        if (_unusedWords.Count == 0) return null;
        int random = Random.Range(0, _unusedWords.Count);
        Word result = _unusedWords[random];
        _unusedWords.RemoveAt(random);
        _onGridWords.Add(result);
        _usedWords.Add(result);
        return result;
    }

}
