using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class statics :MonoBehaviour {
    public  GameObject CookieManager;
    public GameObject UpgradePopup;
    public CookieManager Cookieeeeeee;
    public GameObject Bloon;
    private void Awake()
    {
        StaticObject.Coookie = CookieManager;
        StaticObject.UpgradePop = UpgradePopup;
        StaticObject.CookieCount = Cookieeeeeee;
        StaticObject.Bloon = Bloon;
    }
}
public static class StaticObject
{
    public static int LayerCount=0;
    private static bool Bool;
    
    public static GameObject Coookie;
    public static GameObject UpgradePop;
    public static CookieManager CookieCount;
    public static GameObject Bloon;
    public static FireManager fireManager;
    
}