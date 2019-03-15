using System;
using UnityEngine;
using UnityEngine.UI;
public class supplydrop : MonoBehaviour {
    public int Potato;
    public bool IsMousePressed;
    public Image timer;
    public TextMesh TExt;
    public int DeathCounter;
    public UInt64 TotalCratesCollected;
	// Use this for initialization
	void Start () {
        //GetComponent<Animation>().Play("supplydrop");
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0) && IsMousePressed)
        {
            Potato++;
            timer.fillAmount = Potato / 50f;
            if (Potato > 50)
            {
                gameObject.SetActive(false);
                timer.gameObject.SetActive(false);
                TExt.transform.position = transform.position;
                TExt.gameObject.SetActive(true);
                double MONEYS = (StaticObject.CookieCount.GetComponent<BPSManager>().TotalBPSStore+1) * UnityEngine.Random.Range(30, 60);
                TExt.GetComponent<MoveUp>().Cash = MONEYS;
                TExt.text =NumFormat.NumtoString(MONEYS);

                TotalCratesCollected++;
            }
        }
        else
        {
            IsMousePressed = false;
            timer.gameObject.SetActive(false);
            DeathCounter++;
            if (DeathCounter == 600)
            {
                gameObject.SetActive(true);
            }
        }
	}
    private void OnMouseDown()
    {
        IsMousePressed = true;
        Potato = 0;
        DeathCounter = 0;
        timer.gameObject.SetActive(true);
        timer.transform.position = transform.position;
        timer.transform.position += new Vector3(1, 1, 0);
        
    }
    private void OnMouseExit()
    {
        IsMousePressed = false;
    }
    private void OnEnable()
    {
        DeathCounter = 0;
        Potato = 0;
    }
}
