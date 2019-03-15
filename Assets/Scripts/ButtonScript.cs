using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
public class ButtonScript : MonoBehaviour {
    public double TowerCost;
    public GameObject CookieManager;
    public CookieManager CookieCount;
    private Button Button;
    public Color Red;
    public Color Full;
    public string TowerName;
    // Use this for initialization
    void Start () {
        Button = gameObject.GetComponent<Button>();
        CookieCount = CookieManager.GetComponent<CookieManager>();
        gameObject.GetComponentInChildren<Text>().text = string.Format("{0} : {1}", TowerName, TowerCost);
        Button.interactable=false;
        Button.image.color = Red;
	}
	
	// Update is called once per frame
	void Update () {
        if (CookieCount.BloonCount>=TowerCost-0.1)
        {
            Button.interactable = true;
            Button.image.color = Full;
        }
        else
        {
            Button.interactable = false;
            Button.image.color = Red;
        }
	}
    private void MouseOver()
    {
        
    }
}
