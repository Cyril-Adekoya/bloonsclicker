using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using Newtonsoft;
using System.Linq;
using Assets.Scripts;

public class CookieManager : MonoBehaviour {
    public Text BloonCounterText;
    public double BloonCount;
    public double Division;
    public TowerInfo towers;
    public int MouseMultipler=1;
    private int[] inverse;
  private  int[] inverse2;
    public GameObject Shadow;
    public GameObject Box;
    public GameObject Canvus;
    //New
    public BPSManager BPSman;
    //Old
    // public int RoadSpikeNum;
    //public float RoadSpikeBps;
    public TowerButton[] Buttons;

    public GameObject UpgradePrefab;
    public List<GameObject> UpgradeIcons;

    public Upgrades upgrades = new Upgrades();
    public Text UpgradeCount;
    public int BloonDiff;
    // Use this for initialization
    void Start () {
        Tools tools = new Tools();
        //tools.extractIngamepng(@"Z:\New folder", @"Z:\New folder\DeSpaghetted");
        //tools.Jsoncon("Z:/Json");
        BloonCounterText.text = "0 Bloons";
        BloonCount = 1000;
        Application.targetFrameRate = 60;
        towers = StaticObject.Coookie.GetComponent<TowerManager>().Towers;
        InvokeRepeating("UpgradeCheck", 0f, 1f);
        InvokeRepeating("Blooncheck", 0f, 20f);
        InvokeRepeating("PlaceBox", 0f, 13f);
    }
    public void Blooncheck()
    {
        double Log = Math.Log(BloonCount, 1000);
        if (Log >= (BloonDiff+1)/2)
        {
            BloonDiff++;
        }
        if (BloonDiff > 14)
        {
            CancelInvoke("Blooncheck");
        }
    }
	// Update is called once per frame
	void Update () {
        BloonCounterText.text = NumFormat.NumtoString(BloonCount);
    }
    public void Bloonclick(double CashAmount)
    {
        BloonCount += CashAmount * MouseMultipler ;
        //BloonCount *= 1.8;
    }

    public void UpgradeCheck()
    {
        if (upgrades.upgrades.Count > 0)
        {
            for (short i = 0; i < upgrades.upgrades.Count; i++)
            {
                if (upgrades.upgrades[i].unlockinfo.type != Unlock.Type.Null )
                {


                    switch (upgrades.upgrades[i].unlockinfo.type)
                    {
                        case Unlock.Type.Cash:
                            if (BloonCount >= upgrades.upgrades[i].unlockinfo.Amount) //If it's unlocked, ToDo: Make nicer.
                            {
                                UpgradeIcons.Add(Instantiate(UpgradePrefab, Canvus.transform));
                                UpgradeIcons[UpgradeIcons.Count - 1].GetComponent<UpgradeGo>().UpgradeData = upgrades.upgrades[i];
                                upgrades.upgrades.RemoveAt(i);
                                i--;
                                SortUpgrades();
                            }
                            break;

                    }
                }
                else
                {
                    if (GetTower(upgrades.upgrades[i].unlockinfo.tower).Count >= upgrades.upgrades[i].unlockinfo.Amount) //If it's unlocked, ToDo: Make nicer.
                    {
                        UpgradeIcons.Add(Instantiate(UpgradePrefab, Canvus.transform));
                        UpgradeIcons[UpgradeIcons.Count - 1].GetComponent<UpgradeGo>().UpgradeData = upgrades.upgrades[i];
                        upgrades.upgrades.RemoveAt(i);
                        i--;
                        SortUpgrades();
                    }
                }
            }
        }
    }
    public Tower GetTower(TowerType type)
    {
        foreach (var tower in towers.Towers)
        {
            if (type == tower.Type)
            {
                return tower;
            }
           
        }
        return null;

    }
   public void UpgradeMethod(Upgrade upgrade, GameObject UpgradeIcon)
    {
        foreach (var item in GetComponent<TowerManager>().Towers.Towers)
        {
            if(item.Type == upgrade.TowerType)
            {
                switch (upgrade.action)
                {
                    case Upgrade.Action.Multiply:
                        item.BPSModifer *= upgrade.Amount;
                        UpgradeIcons.Remove(UpgradeIcon);
                        Destroy(UpgradeIcon);
                        BloonCount -= upgrade.Cost;
                        break;
                }
                foreach (var Tower in item.TowersBroughtList)
                {
                    Tower.GetComponent<AnimationHandler>().StartUp(upgrade.Sprite, 1);
                }
                break;
            }
        }
        
                
        
        foreach (var item in Buttons)
        {
            if (item.Thistower.Type == upgrade.TowerType)
            {
                item.transform.GetChild(1).GetComponent<Image>().sprite = Resources.Load<Sprite>("UpgradeIcons/"+upgrade.Avatar);
                break;
            }
        }
        bool potatobool =false;
        
        if (upgrade.Upgradelevel[0] == 3)
        {
            inverse = new int[] { 0, 3 };
            inverse2 = new int[] { 0, 4 };
            potatobool = true;
        }
        else if (upgrade.Upgradelevel[1] == 3)
        {
            inverse =  new int[] { 3, 0 };
            inverse2 = new int[] { 4, 0 };
            potatobool = true;

        }

        if (potatobool)
        {
            for (int j=0; j < upgrades.upgrades.Count; j++)
            {
                if (upgrades.upgrades[j].TowerType == upgrade.TowerType)
                {
                    if (upgrades.upgrades[j].Upgradelevel[0] == inverse2[0])
                    {
                        upgrades.upgrades.RemoveAt(j);
                    }
                }
            }
            for (int i = 0; i < UpgradeIcons.Count; i++)
            {
                
                if (UpgradeIcons[i].GetComponent<UpgradeGo>().UpgradeData.Upgradelevel[0] == inverse[0])
                {
                    Destroy(UpgradeIcons[i]);
                    UpgradeIcons.RemoveAt(i);
                    

                }
            }
        }
        
        SortUpgrades();
      

    }
    public void SortUpgrades()
    {
        float x = 15.3f;
        float y = 4;
        foreach(GameObject upgrade in UpgradeIcons)
        {


            
            upgrade.transform.position = new Vector2(x+Canvus.transform.position.x, y+Canvus.transform.position.y);
            x -= 1.7f;
            if (x <= 9.75f)
            {
                x = 15.3f;
                y -= 1.7f;
            }
            
            
        }
        UpgradeCount.text = UpgradeIcons.Count().ToString();
    }
    public void PlaceBox()
    {
        Box.transform.position = new Vector3(UnityEngine.Random.Range(-13.5f, 13.5f), UnityEngine.Random.Range(-7f, 4f),0);
        Shadow.transform.position = Box.transform.position;
        Box.SetActive(true);
        Shadow.SetActive(true);
        Box.GetComponent<Animation>().Play("supplydrop");
        Shadow.GetComponent<Animation>().Play("shaodw");
    }
}

