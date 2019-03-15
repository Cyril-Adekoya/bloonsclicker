using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pop : MonoBehaviour {
    public byte Alpha;
	// Use this for initialization
	void Start () {
        Alpha = 162;
	}
	
	// Update is called once per frame
	void Update () {
        GetComponent<SpriteRenderer>().color = new Color32(255, 255, 255, Alpha);
        Alpha -= 5;
        if (Alpha < 12)
        {
            Destroy(gameObject);
        }
	}
}
