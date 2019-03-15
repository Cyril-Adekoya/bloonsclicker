using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class towerslide : MonoBehaviour {
    public Scrollbar Scroll;
    public Transform[] TowersButtons;
    public float oldvalue;
    public float newvalue;
    // Use this for initialization
    void Start()
    {
        Scroll = GetComponent<Scrollbar>();
    }
	// Update is called once per frame
	void Update () {
        newvalue = Scroll.value; 
        if ((newvalue - oldvalue != 0))
        {
            foreach(Transform butt in TowersButtons)
            {
                butt.position += new Vector3(0,  (10*( newvalue - oldvalue)),0);
            }
        }
        oldvalue = newvalue;
    }
    
}
