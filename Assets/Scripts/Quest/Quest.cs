using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest {

    public double Amount;
    public QuestMethods UnlockMethod;
    public Tower Tower;
    public Rewards Reward;
    public double RewardAmount;
    public TowerType Towertype = TowerType.Tower;

}
public enum QuestMethods
{
    Cash=0,// get a certain amount of cash
    Clicks=1, // Click the main bloon 100 times
    Crates=2, // Open 20 crates
    Towers=3// have like 5 dartmonkeys
}
public enum Rewards
{
    Cash=0, // does this need an example
    ClickMultipler=1, // 30x cash from clicks for 30 seconds
    BPSInstant=2// Example, 180x your current bps
}