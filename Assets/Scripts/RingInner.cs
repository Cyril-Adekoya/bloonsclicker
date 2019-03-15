using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RingInner
{
    public ushort size; //Number of towers
    public ushort number; //Ring Number
    public TowerFire[] TowerFireList; //List of child towers
    ushort increment; //Number of towers between projectiles
    ushort iteration = 0; //Tower to fire
    ushort numbera;
    ushort incrementa;
    ushort iterationa;
    public bool ringisfull;

    public void initialize()
    {
        TowerFire[] TowerFireList = new TowerFire[size]; //Wont work in the constructor :( have to do it here
        increment = (ushort)(size / (number + 4)); //Arrays start at 0, not 4. (DEFINITLEY NOT 1)
        incrementa = (ushort)(size / (number + 4)); //Arrays start at 0, not 4. (DEFINITLEY NOT 1)
    }
    public void AnimTowers() //Makes them go pew pew
    {
        for (int i = 0; i < numbera + 4; i++) //Every 4th for first ring, 5th for second, etc.
        {
            if (iterationa >= incrementa)
            {
                iterationa = 0;
            }

            TowerFireList[incrementa * i + iterationa].Animate(); //Can use arrays safely nut
        }
        iterationa++;
    }
    public void firetowers() //Makes them go pew pew
    {
        for (int i = 0; i < number + 4; i++) //Every 4th for first ring, 5th for second, etc.
        {
            if (iteration >= increment)
            {
                iteration = 0;
            }

            TowerFireList[increment * i + iteration].CreateProjectile(); //Can use arrays safely nut
        }
        iteration++;
    }

}
