using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerButton : MonoBehaviour {
    public TowerType Tower;
    public GameObject Popup;
    public GameObject[] Textarray;
    public GameObject Popupimage;
    public Sprite Avat;
    public TowerInfo Towers;
    public Tower Thistower;
    [TextArea(3, 10)]
    public string QuoteText;
    public Text Counter;
    public Image Image;
    public Text costText;
    // Use this for initialization
    void Start () {
        Towers=StaticObject.Coookie.GetComponent<TowerManager>().Towers;
		foreach(var Towered in Towers.Towers)
        {
            if (Towered.Type == Tower)
            {
                Thistower = Towered;
            }
        }
        costText.text =  NumFormat.NumtoString(Thistower.Cost);
	}
	
	// Update is called once per frame
	void Update () {
        Counter.text = Thistower.Count.ToString();
        if (StaticObject.CookieCount.BloonCount>= Thistower.Cost)
        {
            Image.color = Color.white;
        }
        else
        {
            Image.color = Color.grey;
        }
	}
    public void Click()
    {
        if (StaticObject.CookieCount.BloonCount > Thistower.Cost)
        {
            //StaticObject.CookieCount.GetComponent<TowerManager>().activatetower(Tower);
            StaticObject.CookieCount.GetComponent<TowerManager>().PlaceTower(Tower);
            StaticObject.CookieCount.BloonCount -= Thistower.Cost;
            Thistower.Count++;
            Thistower.Cost *= 1.15f;
            costText.text =  NumFormat.NumtoString(Thistower.Cost);
        }
    
    }
    public void MouseEnter()
    {
        Textarray[0].GetComponent<Text>().text = Thistower.Name;
        Textarray[1].GetComponent<Text>().text = "Cost: $"+Thistower.Cost;
        Textarray[2].GetComponent<Text>().text = "Bloons Per Second: "+Thistower.BPS;
        Textarray[3].GetComponent<Text>().text = Thistower.Description;
        Textarray[4].GetComponent<Text>().text = QuoteText;
        Popup.transform.position = transform.position;
        Popup.transform.position += new Vector3(6.8f, 0, 0);
        Popup.SetActive(true);
    }
    public void MouseExit()
    {
        Popup.SetActive(false);
    }
}
