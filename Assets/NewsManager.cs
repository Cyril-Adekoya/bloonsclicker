using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewsManager : MonoBehaviour {
    [TextArea(3, 10)]
    public string[][] NewsPosts = {
        #region No Tower News
        new string[]{ "You are known around the town ",
            "Your Mum liked your post",
            "1 Person knows about your Bloon pops" },
        #endregion
        #region Dart Monkey News
        new string[] { "The Local News Talks about you for 30 seconds",
       "Your dad and Grandma Liked your post",
        "Monkey scientists are worried about the amount of rubber being dropped by bloons",
       "News: a Small group of bloons was sighted at monkeylane" }
        #endregion 
    };
    public int NewsIndex;
    public bool Fadeout;
    public bool Fadein;
    public Text Text;
    public int Index;
    public int OldIndex;
	// Use this for initialization
	void Start () {
        Text = GetComponent<Text>();
        InvokeRepeating("FadeOut", 0, 8f);
	}
    void Update()
    {
        if (Fadeout)
        {
            Text.color = new Color(1, 1, 1, Text.color.a - 0.05f);
            if (Text.color.a <= 0)
            {
                Fadeout = false;
            }
        }
        if (Fadein)
        {
            Text.color = new Color(1, 1, 1, Text.color.a + 0.05f);
            if (Text.color.a >= 1)
            {
                Fadein = false;
            }
        }
    }
    void FadeOut()
    {
        Fadeout = true;
        Invoke("ChangeText", 0.8f);
    }
  
	void ChangeText()
    {
        OldIndex = Index;
        Index= Random.Range(0, NewsPosts[NewsIndex].Length);
        while (OldIndex == Index)
        {
            Index = Random.Range(0, NewsPosts[NewsIndex].Length );
        }
        Text.text = NewsPosts[NewsIndex][Index];
        Fadein = true;
    }
}
