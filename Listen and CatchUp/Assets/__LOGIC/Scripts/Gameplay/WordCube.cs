using System;
using UnityEngine;
using UnityEngine.UI;

public class WordCube : Cube<Word>
{

    public SpriteRenderer Image;

    public override void Setup()
    {
        Data = WordManager.Instance.GetRandomWord();
        if(Data == null)
            Destroy(gameObject);
    }

    protected override void OnDataChanged()
    {
        Image.sprite = Data?.Image;
    }
}
