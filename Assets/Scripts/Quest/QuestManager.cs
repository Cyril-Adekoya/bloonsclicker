using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestManager : MonoBehaviour {

    public List<Quest> Quests = new List<Quest>
    {
        new Quest(){UnlockMethod=QuestMethods.Cash, Amount = 20d, Reward=Rewards.BPSInstant, RewardAmount = 180},
        new Quest(){UnlockMethod=QuestMethods.Towers, Amount = 2, Reward=Rewards.Cash, RewardAmount = 180, Towertype=TowerType.Dart}
    };
    public Quest CurrentQuest;
    public int QuestIndex=0;
    public TowerManager Towers;
    public CookieManager Cookie;
    public BPSManager BpsManag;
    public BloonManager Bloonmanager;
    public supplydrop SupplyCrate;
    public Text QuestText;
    public Text RewardText;
    public Button ClaimRewardButton;
    public double ValueStore;
    public double ValueNeeded;
    public AudioClip[] Questaudio;
    public AudioSource Audioso;
    public Button QuestCompleteButton;
    public GameObject morevariablesik;
    public bool QuestActive;
    public RewardText rewardText;
    private void Start()
    {
        Audioso=GetComponent<AudioSource>();
        foreach (Quest Quest in Quests)
        {
            if (Quest.UnlockMethod==QuestMethods.Towers)
                Quest.Tower = Towers.RetunTowerType(Quest.Towertype);
        }
        NextQuest();
    }

    public void Update()
    {
        if (QuestActive)
        {
            switch (CurrentQuest.UnlockMethod)
            {
                case QuestMethods.Cash:
                    ValueStore = Cookie.BloonCount - ValueStore;
                    if (ValueStore >= 0d)
                    {
                        ValueNeeded -= ValueStore;
                        ValueStore = Cookie.BloonCount;
                        QuestText.text = "Quest: Make " + ValueNeeded + "Cash";

                        print(ValueStore);
                        if (ValueNeeded <= 0)
                        {
                            print("QUESTCOMPLETE");
                            Audioso.clip = Questaudio[0];
                            Audioso.Play();
                            QuestCompleteButton.gameObject.SetActive(true);
                            morevariablesik.SetActive(false);
                            QuestText.gameObject.SetActive(false);
                            RewardText.gameObject.SetActive(false);
                            QuestActive = false;

                        }
                    }
                    break;
                case QuestMethods.Clicks:
                    ValueStore = Bloonmanager.TotalClicks - ValueStore;
                    if (ValueStore >= 0d)
                    {
                        ValueNeeded -= ValueStore;
                        ValueStore = Bloonmanager.TotalClicks;
                        QuestText.text = "Quest: Click " + ValueNeeded + "More Times";

                        print(ValueStore);
                        if (ValueNeeded <= 0)
                        {
                            print("QUESTCOMPLETE");
                            NextQuest();
                            QuestCompleteButton.gameObject.SetActive(true);
                            morevariablesik.SetActive(false);
                            QuestText.gameObject.SetActive(false);
                            RewardText.gameObject.SetActive(false);
                            QuestActive = false;
                        }
                    }
                    break;
                case QuestMethods.Crates:
                    ValueStore = SupplyCrate.TotalCratesCollected - ValueStore;
                    if (ValueStore >= 0d)
                    {
                        ValueNeeded -= ValueStore;
                        ValueStore = SupplyCrate.TotalCratesCollected;
                        QuestText.text = "Quest: Collect " + ValueNeeded + "More Crates";
                        print(ValueStore);
                        if (ValueNeeded <= 0)
                        {
                            print("QUESTCOMPLETE");
                            NextQuest();
                            QuestCompleteButton.gameObject.SetActive(true);
                            morevariablesik.SetActive(false);
                            QuestText.gameObject.SetActive(false);
                            RewardText.gameObject.SetActive(false);
                            QuestActive = false;
                        }
                    }
                    break;
                case QuestMethods.Towers:
                    ValueStore = CurrentQuest.Tower.Count - ValueStore;
                    if (ValueStore >= 0d)
                    {
                        ValueNeeded -= ValueStore;
                        ValueStore = CurrentQuest.Tower.Count;
                        QuestText.text = "Quest: Buy " + ValueNeeded + " More " + CurrentQuest.Tower.Name + "'s";
                        print(ValueStore);
                        if (ValueNeeded <= 0)
                        {
                            print("QUESTCOMPLETE");
                            NextQuest();
                            QuestCompleteButton.gameObject.SetActive(true);
                            morevariablesik.SetActive(false);
                            QuestText.gameObject.SetActive(false);
                            RewardText.gameObject.SetActive(false);
                            QuestActive = false;
                        }
                    }
                    break;
            }
            switch (CurrentQuest.Reward)
            {
                case Rewards.BPSInstant:
                    RewardText.text = "Reward: x" + CurrentQuest.RewardAmount + " Instant BPS";
                    break;
                case Rewards.ClickMultipler:
                    RewardText.text = "Reward: x" + CurrentQuest.RewardAmount + " Click modifer for 15 seconds";
                    break;
                case Rewards.Cash:
                    RewardText.text = "Reward: " + CurrentQuest.RewardAmount + " Instant Cash";
                    break;
            }
        }

    }
    public void NextQuest()
    {
        
        CurrentQuest = Quests[QuestIndex];
        QuestIndex++;
        switch (CurrentQuest.UnlockMethod)
        {
            case QuestMethods.Cash:
                ValueStore = Cookie.BloonCount;
                break;
            case QuestMethods.Clicks:
                ValueStore = Bloonmanager.TotalClicks;
                break;
            case QuestMethods.Crates:
                ValueStore = SupplyCrate.TotalCratesCollected;
                break;
            case QuestMethods.Towers:
                ValueStore = CurrentQuest.Tower.Count;
                break;
            
        }
        ValueNeeded = CurrentQuest.Amount;
        Audioso.clip = Questaudio[1];
        Audioso.Play();
        QuestCompleteButton.gameObject.SetActive(false);
        morevariablesik.SetActive(true);
        QuestText.gameObject.SetActive(true);
        RewardText.gameObject.SetActive(true);
        QuestActive = true;
    }
    void rewardmanager(Rewards reward, double Amount)
    {
        switch (reward)
        {
            case Rewards.BPSInstant:
                break;

            case Rewards.Cash:
                break;

            case Rewards.ClickMultipler:
                break;

        }
    }
}

