using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject Bloon;
    public float Distance;
    public int Speed;
    public int Test;
    // Use this for initialization
    void Start()
    {
        Bloon = StaticObject.Bloon;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =Vector3.MoveTowards(transform.position, Bloon.transform.position,15f* Time.deltaTime);
    }
    public void startup(string Projectile)
    {
        GetComponent<SpriteRenderer>().sprite=Resources.Load<Sprite>("Projectiles/"+Projectile);
    }
    public void Timer(float time)
    {
        Invoke("Destroy", time);
    }
    public void Destroy()
    {
        Bloon.GetComponent<BloonManager>().TowerHit();
        Destroy(gameObject);   
    }
}
