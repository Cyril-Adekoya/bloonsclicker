using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;
using System;

public class FireManager : MonoBehaviour
{
    public TowerManager TowerManager; //You had this here I suppose.
    ushort ringcount = 0; //The current number of rings
    RingOutter outterRing = new RingOutter //The outmost ring, this is seperate because that try catch is slow.
    {
        size = (ushort)(360 / 7.5), //First ring.
        number = 0
    };
    List<RingInner> innerRings = new List<RingInner>(); //Inner rings.

    private void Start()
    {
        outterRing.initialize();
        InvokeRepeating("Anim", 0f, 1f);
        InvokeRepeating("fireRings", 0.7f, 1f); //Fire every 1 second, this is completely tempoary
    }

    void fireRings() //All towers go pew pew here.
    {

        for(int i = 0; i < innerRings.Count; i++)
        {
            innerRings[i].firetowers();
        }

        outterRing.firetowers();
    }
    void Anim() //All towers go pew pew here.
    {

        for (int i = 0; i < innerRings.Count; i++)
        {
            innerRings[i].AnimTowers();
        }

        outterRing.AnimTowers();
    }


    public void outterToInner(ushort numberoftowers) //Increments the rings, Out becomes inner,
    {                                                //Requires numb of towers for ring size.
        RingInner innerRing = new RingInner //Create a new inner
        {
            size = outterRing.size, //Initialization in the constructor
            number = ringcount
        }; //Set the vars of the intter

        innerRing.TowerFireList = new TowerFire[outterRing.TowerFireList.Count]; //Set array length

        for(int i = 0; i < outterRing.TowerFireList.Count; i++) //Foreach towerfire in outer ring
        {
            innerRing.TowerFireList[i] = outterRing.TowerFireList[i]; //Copy the outer ring to the inner ring
        }

        innerRing.initialize(); //Run the startup code
        innerRings.Add(innerRing); //Add outer ring to inner list

        ringcount++; //
        outterRing = new RingOutter //Reset outerring and create new one
        {
            size = numberoftowers,
            number = ringcount
        };
    }

    public void addtower(TowerFire weapontype) //Add tower to outer ring
    {
        outterRing.TowerFireList.Add(weapontype);
    }


}