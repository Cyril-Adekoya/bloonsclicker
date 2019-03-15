using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Diagnostics;

public class TowerManager : MonoBehaviour {
    public TowerInfo Towers = new TowerInfo();
    public Upgrades est = new Upgrades();
    public GameObject TowerTemplate;
    public GameObject Bloon;
    public float Radius = 7;
    public float angle;
    public float angleincrement;
    public int Counter;
    public int SpriteLayer;
    public int towerindexer;
    public NewsManager News;
    public List<List<GameObject>> TowersLists = new List<List<GameObject>>();
    public int[] Index;
    public FireManager firemanager;

    // Use this for initialization
    void Start() {
        angle = 0;
        angleincrement = 7.5f;
        TowersLists.Add(new List<GameObject>());
        for (int i = 0; i < 10000; i++)
        {
            PlaceTower(TowerType.Dart);
        }
        /*
        for (int i = 0; i < TowersLists.Count; i++)
        {

        }
        

        GetComponent<FireManagerOld>().CreateIndexes();*/
    }
	void Firestuff()
    {

    }
	// Update is called once per frame
	void Update () {
        

    }
    public void PlaceTower(TowerType type)
    {
        GameObject Tower = Instantiate(TowerTemplate);
        
        firemanager.addtower(Tower.GetComponent<TowerFire>());
        Tower.transform.position = new Vector2(Bloon.transform.position.x, Bloon.transform.position.y + Radius);

        if ((Convert.ToSingle(SpriteLayer)/2 == Math.Floor(SpriteLayer / 2f)))
        {
            SpriteLayer++;
        }
        else
        {
            SpriteLayer--;
        }
        Tower.GetComponent<TowerFire>().Radius = Radius;
        Tower.transform.RotateAround(Bloon.transform.position, new Vector3(0, 0, 10), angle);
       
        Tower.transform.Rotate(new Vector3(0, 0, 180));
        TowersLists[towerindexer].Add(Tower);
        //Tower.SetActive(false);
        angle += angleincrement;
        Tower.GetComponent<TowerFire>().TowerInfo = RetunTowerType(type);
        RetunTowerType(type).TowersBroughtList.Add(Tower);
        Tower.GetComponent<TowerFire>().Startup();
        if (angle >= 360)//check if needs to create a new circle
        {

            float OldRadius = Radius;
            Radius += 0.3333f;//increase radius
            angle = 0;

            angleincrement *= OldRadius / Radius;//decrease angle increment so more darts can be placed
            TowersLists.Add(new List<GameObject>());
            SpriteLayer += 2;
            towerindexer++;

            firemanager.outterToInner((ushort)(Mathf.RoundToInt(360 / angleincrement)));

        }
        Counter++;
    }
  /*  public void activatetower(TowerType Type)
    {
        TowersLists[Index[0]][Index[1]].SetActive(true);
        foreach (Tower Tower in Towers.Towers)
        {
            if (Tower.Type == Type)
            {
                TowersLists[Index[0]][Index[1]].GetComponent<TowerFire>().Startup(Tower);
                Tower.Count++;
                if (Tower.Count == 1)
                {
                    News.NewsIndex++;
                }
                break;
            }
        }
        Index[1]++;
        if (Index[1] > TowersLists[Index[0]].Count-1 )
        {
            Index[0]++;
            Index[1] = 0;
        }

        
    }*/
    public Tower RetunTowerType(TowerType Type)
    {
        foreach (Tower Tower in Towers.Towers)
        {
            if (Tower.Type == Type)
            {
                return Tower;
            }
        }
        return null;
    }
   
    public void PickTower(TowerType type) {

       
       /* switch (type)
        {
            case TowerType.Mouse:

                break;

            case TowerType.Spike:

                break;

            case TowerType.Pineapple:

                break;

            case TowerType.Dart:

                break;

            case TowerType.Tack:

                break;

            case TowerType.Sniper:

                break;

            case TowerType.Boomerang://Need to fix boomerand on all towers types

                break;

            case TowerType.Ninja:

                break;

            case TowerType.Bomb:

                break;

            case TowerType.Ice:

                break;

            case TowerType.Glue:

                break;

            case TowerType.Boat:

                break;

            case TowerType.Ace:

                break;

            case TowerType.SuperMoney:

                break;

            case TowerType.Wizzard:

                break;

            case TowerType.Village:

                break;

            case TowerType.Farm:

                break;

            case TowerType.Mortar:

                break;

            case TowerType.Dartling:

                break;

            case TowerType.SpikeFactory:

                break;

            case TowerType.Chipper:

                break;


        }*/

    
        
        
    }
}
 