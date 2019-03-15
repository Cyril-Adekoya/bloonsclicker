using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerUpgraeButtons : MonoBehaviour {
    public GameObject TowerButton;
    public GameObject UpgradeButton;
    public bool TowerMove;
    public Vector3 MoveAmount;
    public int MoveBack=1;
    public Vector3 UpgradeMove;
    public bool Upgra;
    public bool isUpgrade;
	// Use this for initialization
	void Start () {
		
	}

    // Update is called once per frame
    void Update() {
        if (!isUpgrade)
        {
            if (TowerMove)
            {
                if (TowerButton.transform.position.x < -10.5f)
                {
                    TowerButton.transform.position += MoveAmount;
                }
            }

            else
            {
                if (TowerButton.transform.position.x > -18.51)
                {
                    TowerButton.transform.position += MoveAmount * -1;
                }

            }
        }
        else
        {

            if (Upgra)
            {
                if (UpgradeButton.transform.position.x > 0)
                {
                    UpgradeButton.transform.position += UpgradeMove;
                }
            }
            else
            {
                if (UpgradeButton.transform.position.x < 8)
                {
                    UpgradeButton.transform.position += UpgradeMove * -1;
                }
            }
        }
    }
    public void TowerPress()
    {
        TowerMove = !TowerMove;
        MoveBack *= -1;
    }
    public void UpgradePress()
    {
        Upgra = !Upgra;
    }
}
