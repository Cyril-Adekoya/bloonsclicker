using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeGo : MonoBehaviour {
    public GameObject UpgradePopup;
    public Upgrade UpgradeData;
    public Text[] UpgradeTexts;
    public CookieManager Cookie;

	// Use this for initialization
	void Start () {
        UpgradePopup = StaticObject.UpgradePop;
        UpgradeTexts = UpgradePopup.GetComponentsInChildren<Text>();
        Cookie = StaticObject.Coookie.GetComponent<CookieManager>();
        transform.GetChild(0).GetComponent<Image>().sprite = Resources.Load<Sprite>("UpgradeIcons/" + UpgradeData.Icon);
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    public void OnMouseEnter()
    {
        
        UpgradeTexts[0].text = UpgradeData.Name;
        UpgradeTexts[1].text = NumFormat.NumtoString(UpgradeData.Cost);
        UpgradeTexts[2].text = UpgradeData.Description;
        UpgradeTexts[3].text = UpgradeData.Quote;
        if (UpgradeData.Cost >= Cookie.BloonCount)
        {
            UpgradePopup.transform.GetChild(0).GetComponent<Image>().color = Color.grey;
            UpgradeTexts[1].color = Color.grey;
        }
        else
        {
            UpgradePopup.transform.GetChild(0).GetComponent<Image>().color = Color.white;
            UpgradeTexts[1].color = Color.white;
        }
        UpgradePopup.SetActive(true);

    }
    public void OnMouseExit()
    {
        UpgradePopup.SetActive(false);
    }
    public void OnMouseDown()
    {
        if (Cookie.BloonCount >= UpgradeData.Cost)
        {
            OnMouseExit();
            StaticObject.Coookie.GetComponent<CookieManager>().UpgradeMethod(UpgradeData, gameObject);
        }
       
    }
}
