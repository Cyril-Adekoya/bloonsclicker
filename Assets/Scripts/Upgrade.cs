using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade {
    public string Name;
    public string Description;
    public Action action;
    public Tower tower;
    public double Cost;
    public bool Unlocked;
    public int Amount;
    public Unlock unlockinfo;
    public string Icon;
    public string Avatar;
    public TowerType TowerType;
    public string Quote;
    public int[] Upgradelevel;
    public Upgrade() { } //Constructor
    public string Sprite;


    public enum Action : ushort //Max 15 flags with ushort
    {
        Action = 0, //Don't use this.

        Multiply = 1,
        Example  = 2,
        Example2 = 4,
        Example3 = 8,

    }

    public enum Tower : uint //Max 31 flags with uint
    {
        Tower = 0, //Don't use this

        Mouse = 1,
        Spike = 2,
        Pineapple = 4,

        Dart = 8,
        Tack = 16,
        Sniper = 32,
        Boomerang = 64,
        Ninja = 128,
        Bomb = 256,
        Ice = 512,
        Glue = 1024,
        Boat = 2048,
        Ace = 4096,
        SuperMoney = 8192,
        Wizzard = 16384,
        Village = 32768,
        Farm = 65536,
        Mortar = 131072,
        Dartling = 262114,
        SpikeFactory = 524288,
        Chipper = 1048576,
    }

}
