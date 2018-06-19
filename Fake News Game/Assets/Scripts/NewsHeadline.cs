using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewsHeadline {
    private string text;
    private string replaceOption1;
    private string replaceOption2;
    private string replaceOption3;
    public int replaceNumber;

    public NewsHeadline(string text, string replaceOption1, string replaceOption2, string replaceOption3)
    {
        this.text = text;
        this.replaceOption1 = replaceOption1;
        this.replaceOption2 = replaceOption2;
        this.replaceOption3 = replaceOption3;
        this.replaceNumber = 0;
    }
	// Use this for initialization
    public string getText()
    {
        return text;
    }
    public void replaceTextPassage1()
    {
        replaceNumber = 1;
    }
    public void replaceTextPassage2()
    {
        replaceNumber = 2;
    }
    public void replaceTextPassage3()
    {
        replaceNumber = 3;
    }
}
