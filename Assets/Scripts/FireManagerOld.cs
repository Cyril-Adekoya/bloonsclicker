using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;
public class FireManagerOld : MonoBehaviour {
    public TowerManager TowerManager;
    public List<List<GameObject>> List = new List<List<GameObject>>();
    public List<List<int>> Index = new List<List<int>>();
    public List<List<int>> Index2 = new List<List<int>>();
    public int[] Other;
    public List<TowerFire> Towerstofire = new List<TowerFire>();
    public List<List<TowerFire>> TowerFireList = new List<List<TowerFire>>();
    public int u;
    public int x;
    public List<int> towerspiltman= new List<int>() { 1, 1, 0,  1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0, 1, 1, 0 }; 
	// Use this for initialization
	void Start () {
        
        List = TowerManager.TowersLists;
        

    }
	
	
    public void CreateIndexes()
    {
        List = TowerManager.TowersLists;
        float Counter = 4f;
        for (int i = 0; i < List.Count; i++)
        {
            Index.Add(new List<int>());
            Index2.Add(new List<int>());
            for (int u = 0; u < Counter; u++)
            {
                Index[i].Add(Other[i]);
                Index2[i].Add(Other[i]);
                Other[i] += Convert.ToInt32(Math.Floor(List[i].Count / Counter));
            }
            Counter++;
            
        }
        for (int i = 0; i < List.Count; i++)
        {
            TowerFireList.Add(new List<TowerFire>());
            for (int j = 0; j < List[i].Count; j++)
            {
                if (List[i][j] != null)
                {
                    TowerFireList[i].Add(List[i][j].GetComponent<TowerFire>());
                }
                else
                {
                    TowerFireList[i].Add(null);
                }
            }
        }
    }
    public void Update()
    {
        if (towerspiltman[x] == 1)
        {
            for (int i = 0; i < Index[u].Count; i++)
            {

                if (List[u][Index[u][i]] != null && List[u][Index[u][i]].activeInHierarchy)
                {
                    TowerFireList[u][Index[u][i]].Animate();
                    Towerstofire.Add(TowerFireList[u][Index[u][i]]);
                }
                Index[u][i]++;
                if (Index[u][i] == List[u].Count)
                {
                    Index[u][i] = 0;
                }
                

            }
            u++;
            print(u);
            if (u == Index.Count)
            {

                u = 0;
            }
        }
        x++;
        print(x);
        if (x == towerspiltman.Count)
        {
            x = 0;
            print(Time.time);
            FireTowers();
            
        }
        
        

    }
    public void FireTowers()
    {
        foreach(TowerFire Tower in Towerstofire)
        {
            Tower.CreateProjectile();
        }
        Towerstofire.Clear();

    }
}