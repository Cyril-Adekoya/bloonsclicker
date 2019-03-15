using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
public class Tower : TowerFire
{
    public string Name;
    public TowerType Type;
    public double BPS;
    public double Cost;
    public string Sprite;
    public string ProjectileSprite;

    public string Description;
    
    public uint Count;//Number of towers brought
    public double BPSModifer;//Modifer from upgrades
    //Special Case Stuff 
   

    public bool GainsBPSFromOther;//for "Gains 5% extra bps from each dart monkey owned" for tack(like Grandmas)
    public List<TowerType> BPSFromOtherTowers;//List of towers its gets it from
    public List<double> BPSFromOtherTowersModifer;//Modifer from each tower

    public bool BPSFromTotalClicks;//Idk Might be a cool upgrade
    public double BPSFromTotalClicksModifer;

    public List<GameObject> TowersBroughtList = new List<GameObject>();



}

public enum TowerType : uint //Max 31 flags with uint
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
