using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPSManager : MonoBehaviour {
    public TowerInfo Towers;
    public CookieManager Cookie;
    public Tower CurrentTower;
    public double BPSStore;
    public double TotalBPSStore;
    void Start()
    {
        Towers = StaticObject.Coookie.GetComponent<TowerManager>().Towers;
        
        Cookie = StaticObject.CookieCount;
        InvokeRepeating("BPS", 0, 1);
    }
    void BPS()
    {
        TotalBPSStore = 0;
        for (int i = 0; i < Towers.Towers.Count; i++)
        {
            CurrentTower = Towers.Towers[i];
            BPSStore+=CurrentTower.BPS * CurrentTower.Count * CurrentTower.BPSModifer;

            if (CurrentTower.GainsBPSFromOther)
            {
                for(int j=0; j<CurrentTower.BPSFromOtherTowers.Count; j++)
                {
                    Tower TempTower = GetTowerInfo(CurrentTower.BPSFromOtherTowers[j]);
                    BPSStore *= CurrentTower.BPSFromOtherTowersModifer[j];
                }
            }
            Cookie.BloonCount += BPSStore;
            TotalBPSStore += BPSStore;
            BPSStore = 0;
        }
        
    }
    public Tower GetTowerInfo(TowerType TowerType)
    {
        foreach (var item in Towers.Towers)
        {
            if (item.Type == TowerType)
            {
                return item;
            }
        }
        return null;
    }

}

