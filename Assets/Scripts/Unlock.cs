using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unlock{
    public int Amount;
    public Type type;
    public TowerType tower;

    public Unlock() { } //Constructor


    public enum Type : ushort //15 Max Flags with ushort
    {
        Type = 0, //Don't use this
        Null=1,
        Cash = 2,
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
        Bommerang = 64,
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
