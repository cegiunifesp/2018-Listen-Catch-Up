using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public static List<Word> GenerateWords()
    {
        List<Word> list = new List<Word>();

        for(int i = 0; i < 50; i++)
        {
            Word w = new Word();
            w.NameEnglish = "Palavra" + i.ToString();
            list.Add(w);
        }

        return list;
    }
}
