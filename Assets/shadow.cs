using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shadow : MonoBehaviour {

	// Use this for initialization
	void Start () {
       // GetComponent<Animation>().Play("shaodw");
        Invoke("Des", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void Des()
    {
        gameObject.SetActive(false); }
}
