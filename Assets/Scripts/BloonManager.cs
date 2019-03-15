using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class BloonManager : MonoBehaviour
{
    public int Health;
    public SpriteRenderer Sprite;
    public Bloon Type;
    public Bloon Child;
    public GameObject Pop;
    public AudioClip[] PopSounds;
    public AudioClip[] MOABHIT;
    public AudioClip[] MOABDEATH;
    public AudioSource AudioSource;
    private Vector3 BaseScale;
    private Quaternion BaseRotaton;
    public bool RotateandShrink;
    private float Grownum;
    private float rotatenum;
    public bool growandroate;
    public CookieManager CookieManagerObject;
    public UInt64 TotalClicks;
    // Use this for initialization
    void Start()
    {
        PickNewType();
        UpdateBloon();
        Sprite = GetComponent<SpriteRenderer>();
        AudioSource = GetComponent<AudioSource>();
        BaseScale = transform.localScale;
        BaseRotaton = transform.rotation;
        CookieManagerObject = StaticObject.CookieCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (RotateandShrink)
        {
            transform.localScale -= new Vector3(0.02f, 0.02f);
            transform.Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0f, 1f)));
            if (transform.localScale.x < 2.7f)
            {
                RotateandShrink = false;
                Grownum = (3f - transform.localScale.x) / 15;
                rotatenum = (transform.rotation.eulerAngles.z) / 16;
                growandroate = true;
            }
        }
        if (growandroate)
        {
            transform.localScale += new Vector3(Grownum, Grownum);
            transform.Rotate(new Vector3(0, 0, -rotatenum));
            if (transform.localScale.x > 3)
            {
                growandroate = false;
            }
        }
    }
    void UpdateBloon()
    {
        switch (Type)
        {
            case Bloon.Red:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_red");
                Health = 1;
                Child = Bloon.Bloon;
                break;

            case Bloon.Blue:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_blue");
                Health = 1;
                Child = Bloon.Red;
                break;

            case Bloon.Green:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_green");
                Health = 1;
                Child = Bloon.Blue;
                break;

            case Bloon.Yellow:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_yellow");
                Health = 1;
                Child = Bloon.Green;
                break;

            case Bloon.Pink:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_pink");
                Health = 1;
                Child = Bloon.Yellow;
                break;

            case Bloon.Black:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_black");
                Health = 1;
                Child = Bloon.Pink;
                break;

            case Bloon.White:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_white");
                Health = 1;
                Child = Bloon.Pink;
                break;

            case Bloon.Zebra:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_zebra");
                Health = 1;
                if (UnityEngine.Random.value < 0.5f) //50% Chance
                {
                    Child = Bloon.Black;
                }
                else
                {
                    Child = Bloon.White;
                }
                break;

            case Bloon.Lead:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_lead");
                Health = 1;
                Child = Bloon.Black;
                break;

            case Bloon.Rainbow:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_rainbow");
                Health = 1;
                Child = Bloon.Zebra;
                break;

            case Bloon.Ceramic:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/bloon_ceramic");
                Health = 10;
                Child = Bloon.Rainbow;
                break;

            case Bloon.Moab:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/MOAB");
                Health = 75;
                Child = Bloon.Ceramic;
                break;

            case Bloon.BFB:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/BFB");
                Health = 262;
                Child = Bloon.Moab;
                break;

            case Bloon.ZOMG:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/ZOMG");
                Health = 1500;
                Child = Bloon.BFB;
                break;

            case Bloon.DDT:
                GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Textures/Bloons/DDT");
                Health = 122;
                Child = Bloon.Ceramic;
                break;
        }
    }
    public void OnMouseDown()
    {
        RotateandShrink = true;
        Health -= 1;
        transform.localScale = BaseScale;
        transform.rotation = BaseRotaton;
        StaticObject.CookieCount.Bloonclick(1);
        PlaySound();
        TotalClicks++;


        if (Health <= 0)
        {
            Instantiate(Pop, transform).GetComponent<Transform>().Rotate(new Vector3(0, 0, UnityEngine.Random.Range(0, 360)));
            double CashAmount = (Health / 4);
            RotateandShrink = false;
            growandroate = false;
            if (CashAmount > 0.25)
            {
                StaticObject.CookieCount.Bloonclick(CashAmount);
            }

            PickNewType();
            UpdateBloon();
        }
    }

    void PickNewType()
    {
        if (Child != Bloon.Bloon)
        {
            Type = Child;
            UpdateBloon();
            return;
        }
        Array values = Enum.GetValues(typeof(Bloon)); //Stack overflow pt1
        Type = (Bloon)values.GetValue(UnityEngine.Random.Range(1, StaticObject.CookieCount.BloonDiff)); //Stack overflow pt2, if it's not broke, don't fix it.

    }
    public void TowerHit()
    {
        Health -= 1;
        PlaySound();
        if (Health <= 0)
        {
            CookieManagerObject.Bloonclick(1);
            PickNewType();
            UpdateBloon();
        }
    }
    public void PlaySound()
    {
        switch (Type)
        {
            case Bloon.Ceramic:
            case Bloon.DDT:
            case Bloon.Moab:
            case Bloon.BFB:
            case Bloon.ZOMG:
                AudioSource.clip = MOABHIT[UnityEngine.Random.Range(0, MOABHIT.Length)];
                break;
        }
        if (Health <= 0)
        {
            switch (Type)
            {
                case Bloon.Red:
                case Bloon.Blue:
                case Bloon.Green:
                case Bloon.Yellow:
                case Bloon.Pink:
                case Bloon.Black:
                case Bloon.White:
                case Bloon.Zebra:
                case Bloon.Rainbow:
                    AudioSource.clip = PopSounds[UnityEngine.Random.Range(0, 4)];
                    break;
                case Bloon.Moab:
                case Bloon.BFB:
                case Bloon.ZOMG:
                    AudioSource.clip = MOABDEATH[UnityEngine.Random.Range(0, MOABDEATH.Length)];
                    break;
            }
        }

        AudioSource.Play();
    }
    public enum Bloon : uint //Max 31 flags with uint
    {
        Bloon = 0, //Don't use this

        Red = 1,
        Blue = 2,
        Green = 4,
        Yellow = 8,
        Pink = 16,
        Black = 32,
        White = 64,
        Zebra = 128,
        Lead = 256,
        Rainbow = 512,
        Ceramic = 1024,

        Moab = 2048,
        BFB = 4096,
        ZOMG = 8192,
        DDT = 16384,

        //Boss bloons?
    }
}
