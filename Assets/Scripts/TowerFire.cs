using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TowerFire : MonoBehaviour
{
    public float Cooldown;
    public float FireDelay;
    public float TotalCooldown;
    public double Radius;
    public float time;
    public GameObject ProjectilePrefab;
    public Tower TowerInfo;
    public AnimationHandler Anim;
    // Use this for initialization
    void Start() {
        TotalCooldown = Cooldown + FireDelay;
        time = 0.7f * (Convert.ToSingle(Radius) / 10f);
}

    // Update is called once per frame
    void Update()
    {


    }
    public void CreateProjectile()
    {
        var Pro = Instantiate(ProjectilePrefab, transform);
            Pro.GetComponent<Projectile>().Timer(time);//test time
        Pro.GetComponent<Projectile>().startup(TowerInfo.ProjectileSprite);
    }
    public void Animate()
    {
        Anim.startanimation();
    }
    public void Startup()
    { 

        Anim = GetComponent<AnimationHandler>();
       
        Anim.StartUp(TowerInfo.Sprite, 1);
    }
}
