using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerInfo {

    public List<Tower> Towers = new List<Tower>();

    public TowerInfo()
    {
        #region Template
        /*
        Towers.Add(new Tower()
        {
            Name = "",
            Type = TowerType.Tower,
            BPS = 0d,
            Cost = 0d,
            Sprite = "DartMonkey",
            ProjectileSprite = "Dart",
            Cooldown = 1f,
            FireDelay = 0.2f
        });
        */
        #endregion

        #region Towers
        #region DartMonkey
        Towers.Add(new Tower()
        {
            Name = "Dart Monkey",
            Type = TowerType.Dart,
            BPS = 2d,
            Cost = 200d,
            Sprite = "DartMonkey",
            ProjectileSprite = "Dart",
            Description = "Throws a Dart which pops bloons",
            BPSModifer = 1,
            GainsBPSFromOther = false,
            BPSFromTotalClicks=false
            
        });
        #endregion
        #region Tack
        Towers.Add(new Tower()
        {
            Name = "TackTower",
            Type = TowerType.Tack,
            BPS = 2d,
            Cost = 2100d,
            Sprite = "Tack",
            ProjectileSprite = "Tack"
        });
        #endregion
        #endregion
    }
}

