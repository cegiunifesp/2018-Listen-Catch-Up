using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

    public Text Leveltext;
    public Text Clocktext;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SetLevel(string s)
    {
        Leveltext.text = s;
    }

    public void SetClock(string s)
    {
        Clocktext.text = s;
    }
}
