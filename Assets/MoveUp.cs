using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUp : MonoBehaviour {
    public Vector3 Movement = new Vector3(0, 0.06f, 0);
    public int Count;
    public Vector3 UILocation;
    public float speed;
    public const float basespeed = 12;
    public AudioSource Audio;
    public double Cash;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Count < 15)
        {
            transform.position += Movement;
            Count++;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, UILocation, speed * Time.deltaTime);
            speed *= 1.02f;
            if (transform.position == UILocation)
            {
                Audio.Play();
                StaticObject.CookieCount.BloonCount += Cash;
                gameObject.SetActive(false);
               
            }
        }
	}
    private void OnEnable()
    {
        Count = 0;
        speed = basespeed;
        GetComponent<AudioSource>().Play();
    }
}
