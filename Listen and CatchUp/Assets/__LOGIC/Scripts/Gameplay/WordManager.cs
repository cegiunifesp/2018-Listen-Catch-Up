using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class WordManager : SingletonBehaviour<WordManager>
{
    [Range(-10, 10)]
    public int SpeechSpeed = 0;
    public Word[] WordList;
    public Word CurrentWord;
    public Action OnOutOfWords;

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
    private List<Word> _onGridWords = new List<Word>();
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
        ListenCurrentWord();
        return CurrentWord;
    }

    public bool ValidateWord(Word word)
    {
        bool result = CurrentWord == word;
        if (result)
        {
            _onGridWords.Remove(word);

            if (GetNewWord() == null)
            {
                OnOutOfWords?.Invoke();
            }

        }

        return result;
    }

    public void ResetWords()
    {
        _usedWords.Clear();
        _onGridWords.Clear();
        _unusedWordsInitialized = false;
    }

    public bool IsAllWordsUsed()
    {
        if (UnusedWords.Count == 0)
            return true;
        else return false;
    }

    public void ListenCurrentWord()
    {
        CurrentWord.AudioIn(Language.English).PlayFx();
        //        GetTTS(CurrentWord,clip => clip.PlayFx());
    }

    public void GetTTS(Word word, Action<AudioClip> onFinished)
    {
        TTS.Get(word.In(Language.English), onFinished, SpeechSpeed);
    }

    [ContextMenu("Cache All Words TTS")]
    public void CacheAllWordsTTS()
    {
        Debug.Log("Caching words...");
        int i = 0;
        foreach (var word in WordList)
        {
            GetTTS(word, clip =>
            {
                if (++i == WordList.Length) Debug.Log("Cached all words");
            });
        }
    }
    [ContextMenu("Clear Words TTS Cache")]
    public void ClearAllWordsTTS()
    {
        TTS.ClearCache();
    }

    /*    [ContextMenu("CopyToFolder")]
        private void CopyToFolder()
        {

            string targetFolder = "Assets/_DATA/Sounds/TTS/";

            foreach (var word in WordList)
            {
                word.Values[1].Audio = AssetDatabase.LoadAssetAtPath<AudioClip>(Path.Combine(targetFolder,$"{word.In(Language.English)}.wav"));
                EditorUtility.SetDirty(word);
            }
            AssetDatabase.SaveAssets();
        }*/
}
