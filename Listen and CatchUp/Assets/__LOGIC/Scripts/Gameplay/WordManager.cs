using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordManager : SingletonBehaviour<WordManager>
{

    public Word[] WordList;
    public Word CurrentWord;

    private List<Word> UnusedWords
    {
        get
        {
            if (!_unusedWordsInitialized)
            {
                _unusedWords = new List<Word>(WordList);
                _unusedWordsInitialized = true;
            }
            return _unusedWords;
        }
    }

    private bool _unusedWordsInitialized = false;
    private List<Word> _unusedWords = null;
    private List<Word> _onGridWords = new  List<Word>();
    private List<Word> _usedWords = new List<Word>();

    public Word GetRandomWord()
    {
        if (UnusedWords.Count == 0) return null;
        int random = Random.Range(0, _unusedWords.Count);
        Word result = UnusedWords[random];
        UnusedWords.RemoveAt(random);
        _onGridWords.Add(result);
        _usedWords.Add(result);
        return result;
    }

    public Word GetNewWord()
    {
        if (_onGridWords.Count == 0)
        {
            CurrentWord = null;
            return null;
        }
        int random = Random.Range(0, _onGridWords.Count);
        CurrentWord = _onGridWords[random];
        return CurrentWord;
    }

    public bool ValidateWord(Word word)
    {
        bool result = CurrentWord == word;
        if (result)
        {
            _onGridWords.Remove(word);
            if(GetNewWord() == null)
            {
                GameManager.Instance.EndCampaing();
            }
        }

        return result;
    }

}
