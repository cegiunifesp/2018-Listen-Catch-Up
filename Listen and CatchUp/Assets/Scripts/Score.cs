using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class Score
{
    private int _score;
    private string _playername;

    public Score()
    {
        _score = 0;
        _playername = "jogador";
    }

    public void IncreseScore()
    {
        _score++;
    }

    public int GetScore()
    {
        return _score;
    }

    public void SetName(string s)
    {
        _playername = s;
    }

    public string GetName()
    {
        return _playername;
    }
}
