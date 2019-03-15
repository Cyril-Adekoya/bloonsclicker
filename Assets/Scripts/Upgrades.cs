using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Upgrades{

    public List<Upgrade> upgrades = new List<Upgrade>();

    public Upgrades()
    {
        #region Template
        /*
        upgrades.Add(new Upgrade()
        {
            Name = "",
            Description = "",
            tower = Upgrade.Tower.Tower,
            action = Upgrade.Action.Action,
            Amount = 0,
            Cost = 0d,
            Unlocked = false,

            unlockinfo = new Unlock()
            {
                Amount = 0,
                type = Unlock.Type.Type,
                tower = Unlock.Tower.Tower,
            }
        });
        */
        #endregion

        #region DartMonkey
        #region Long Range Darts
        upgrades.Add(new Upgrade()
            {
              Name = "Long Range Darts",
              Description = "Dart Monkeys Pop twice as many bloons per second",
              Quote="More Range = More Pops",
              tower = Upgrade.Tower.Dart,
              TowerType = TowerType.Dart,
              action = Upgrade.Action.Multiply,
              Amount = 2,
              Cost = 1000,
              Unlocked = false,
              Icon= "dart_monkey_longer_range_icon",
              Avatar= "dart_monkey_avatar_increased_range_small",
              Upgradelevel = new int[] { 1, 0 },
              Sprite= "DartMonkeyGreenBandana",
                unlockinfo = new Unlock()
                {
                    Amount = 2,
                    type = Unlock.Type.Null,
                    tower = TowerType.Dart,
                }
            
        });
        #endregion
        #region Sharp Shots
        upgrades.Add(new Upgrade()
        {
            Name = "Sharp Shots",
            Description = "Dart Monkeys Pop twice as many bloons per second",
            Quote = "Sharpened darts allow for hightened poping power",
            tower = Upgrade.Tower.Dart,
            TowerType = TowerType.Dart,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "dart_monkey_sharp_shots_icon",
            Avatar = "dart_monkey_avatar_sharp_shots_small",
            Upgradelevel = new int[] { 0, 1 },
            unlockinfo = new Unlock()
            {
                Amount = 3,
                type = Unlock.Type.Null,
                tower = TowerType.Dart,
            }
        });
        #endregion
        #region Enhanced Eyesight
        upgrades.Add(new Upgrade()
        {
            Name = "Enhanced Eyesight",
            Description = "Dart Monkeys Pop twice as many bloons per second",
            Quote = "Much range, such pops",
            tower = Upgrade.Tower.Dart,
            TowerType = TowerType.Dart,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "dart_monkey_enhanced_eyesight_icon",
            Avatar = "dart_monkey_avatar_enhanced_eyesight_small",
            Upgradelevel = new int[] { 2, 0 },
            unlockinfo = new Unlock()
            {
                Amount = 4,
                type = Unlock.Type.Null,
                tower = TowerType.Dart,
            }
        });
        #endregion
        #region Razor Sharp Shots
        upgrades.Add(new Upgrade()
        {
            Name = "Razor Sharp Shots",
            Description = "Dart Monkeys Pop twice as many bloons per second",
            Quote = "Darts cut though bloons well like a dart though bloons",
            tower = Upgrade.Tower.Dart,
            TowerType = TowerType.Dart,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "dart_monkey_razor_icon",
            Avatar = "dart_monkey_avatar_razor_sharp_small",
            Upgradelevel = new int[] { 0, 2 },
            unlockinfo = new Unlock()
            {
                Amount = 5,
                type = Unlock.Type.Null,
                tower = TowerType.Dart,
            }
        });
        #endregion
        #region Spike-O-Pult
        upgrades.Add(new Upgrade()
        {
            Name = "Spike-O-Pult",
            Description = "Dart Monkeys Pop twice as many bloons per second",
            Quote = "Spiked Balls (LennyFace)",
            tower = Upgrade.Tower.Dart,
            TowerType = TowerType.Dart,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "dart_monkey_spikeopult_icon",
            Avatar = "dart_monkey_avatar_spikeopult_small",
            Upgradelevel = new int[] { 3, 0 },
            unlockinfo = new Unlock()
            {
                Amount = 6,
                type = Unlock.Type.Null,
                tower = TowerType.Dart,
            }
        });
        #endregion
        #region Triple Darts
        upgrades.Add(new Upgrade()
        {
            Name = "Triple Darts",
            Description = "Dart Monkeys Pop twice as many bloons per second",
            Quote = "3x more darts = 2x more bloons :thonk:",
            tower = Upgrade.Tower.Dart,
            TowerType = TowerType.Dart,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "dart_monkey_triple_icon",
            Avatar = "dart_monkey_avatar_triple_shot_small",
            Upgradelevel = new int[] { 0, 3 },
            unlockinfo = new Unlock()
            {
                Amount = 6,
                type = Unlock.Type.Null,
                tower = TowerType.Dart,
            }
        });
        #endregion
        #region Juggernaut
        upgrades.Add(new Upgrade()
        {
            Name = "Juggernaut",
            Description = "Dart Monkeys Pop twice as many bloons per second",
            Quote = "Bigger Balls = Bigger Bloon Destoruction",
            tower = Upgrade.Tower.Dart,
            TowerType = TowerType.Dart,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "dart_monkey_juggernaut_icon",
            Avatar = "dart_monkey_avatar_juggernaut_small",
            Upgradelevel = new int[] { 4, 0 },
            unlockinfo = new Unlock()
            {
                Amount = 7,
                type = Unlock.Type.Null,
                tower = TowerType.Dart,
            }
        });
        #endregion
        #region Super Monkey Fan Club
        upgrades.Add(new Upgrade()
        {
            Name = "Super Monkey Fan Club",
            Description = "Dart Monkeys Pop twice as many bloons per second",
            Quote = "Where do they get those superMonkey clothes noone knows",
            tower = Upgrade.Tower.Dart,
            TowerType = TowerType.Dart,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "dart_monkey_fanclub_icon",
            Avatar = "dart_monkey_avatar_supermonkey_fanclub_small",
            Upgradelevel =new int[] { 0, 4 },
            unlockinfo = new Unlock()
            {
                Amount =7 ,
                type = Unlock.Type.Null,
                tower = TowerType.Dart,
            }
        });
        #endregion
        #endregion
        #region Tack
        #region Faster Shooting
        upgrades.Add(new Upgrade()
        {
            Name = "Faster Shooting",
            Description = "All Tack Shooters Pop twice as many bloons per second",
            Quote = "Fires tacks Faster",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_faster_firing_icon",
            Avatar = "tack_shooter_avatar_faster_shooting_small",
            Upgradelevel = new int[] { 1, 0 },
            unlockinfo = new Unlock()
            {
                Amount = 2,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #region Extra Range Tacks
        upgrades.Add(new Upgrade()
        {
            Name = "Extra Range Tacks",
            Description = "Tack Shooters Pop twice as many bloons per second",
            Quote = "Increased Range Much more pops",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_extra_range_icon",
            Avatar = "tack_shooter_avatar_extra_range_small",
            Upgradelevel = new int[] { 0, 1 },
            unlockinfo = new Unlock()
            {
                Amount = 3,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #region Even Faster Shooting
        upgrades.Add(new Upgrade()
        {
            Name = "Even Faster Shooting",
            Description = "Tack Shooters Pop twice as many bloons per second",
            Quote = "Fires Faster Again",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_even_faster_firing_icon",
            Avatar = "tack_shooter_avatar_even_faster_shooting_small",
            Upgradelevel = new int[] { 2, 0 },
            unlockinfo = new Unlock()
            {
                Amount = 4,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #region Super Range Tacks
        upgrades.Add(new Upgrade()
        {
            Name = "Super Range Tacks",
            Description = "Tack Shooters Pop twice as many bloons per second",
            Quote = "Tack Shooters Gain ***SUPER*** Range",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_super_range_icon",
            Avatar = "tack_shooter_avatar_super_range_small",
            Upgradelevel = new int[] { 0, 2 },
            unlockinfo = new Unlock()
            {
                Amount = 5,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #region Tack Sprayer
        upgrades.Add(new Upgrade()
        {
            Name = "Tack Sprayer",
            Description = "Tack Shooters Pop twice as many bloons per second",
            Quote = "More Tacks = Win",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_sprayer_icon",
            Avatar = "tack_shooter_avatar_sprayer_small",
            Upgradelevel = new int[] { 3, 0 },
            unlockinfo = new Unlock()
            {
                Amount = 6,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #region Blade Shooter
        upgrades.Add(new Upgrade()
        {
            Name = "Blade Shooter",
            Description = "Tack Shooter Pop twice as many bloons per second",
            Quote = "Blades Make Everything better",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_blade_icon",
            Avatar = "tack_shooter_avatar_blade_shooter_small",
            Upgradelevel = new int[] { 0, 3 },
            unlockinfo = new Unlock()
            {
                Amount = 6,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #region Ring Of Fire
        upgrades.Add(new Upgrade()
        {
            Name = "Ring Of Fire",
            Description = "Tack Shooters Pop twice as many bloons per second",
            Quote = "Ring of fire MELTS Though bloons",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_rof_icon",
            Avatar = "tack_shooter_avatar_rof_small",
            Upgradelevel = new int[] { 4, 0 },
            unlockinfo = new Unlock()
            {
                Amount = 7,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #region Blade Maelstrom
        upgrades.Add(new Upgrade()
        {
            Name = "Blade Maelstrom",
            Description = "TackShooters Pop twice as many bloons per second",
            Quote = "Where does the Tack shooter store all those blades",
            tower = Upgrade.Tower.Tack,
            TowerType = TowerType.Tack,
            action = Upgrade.Action.Multiply,
            Amount = 2,
            Cost = 1000,
            Unlocked = false,
            Icon = "tack_shooter_maelstrom_icon",
            Avatar = "tack_shooter_avatar_blade_maelstrom_small",
            Upgradelevel = new int[] { 0, 4 },
            unlockinfo = new Unlock()
            {
                Amount = 7,
                type = Unlock.Type.Null,
                tower = TowerType.Tack,
            }
        });
        #endregion
        #endregion
    }






    /*		// Use this for initialization
        void Start () {

        }
     *	
     *	// Update is called once per frame
        void Update () {

        }*/
}
