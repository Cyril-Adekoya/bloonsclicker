using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class NumFormat : MonoBehaviour {
    private static string[] LargeNumberNames = { "thousand", "million", "billion", "trillion", "quadrillion", "quintillion", "sextillion", "septillion", "octillion", "nonillion", "decillion", "undecillion", "duodecillion", "tredecillion", "quattuordecillion", "quindecillion", "sexdecillion", "septendecillion", "octodecillion", "novemdecillion", "vigintillion", "unvigintillion", "duovigintillion", "trevigintillion", "quattuorvigintillion", "quinvigintillion", "sexvigintillion", "septenvigintillion", "octovigintillion", "novemvigintillion", "trigintillion", "untrigintillion", "duotrigintillion", "tretrigintillion", "quattuortrigintillion", "quintrigintillion", "sextrigintillion", "septentrigintillion", "octotrigintillion", "novemtrigintillion", "quadragintillion", "unquadragintillion", "duoquadragintillion", "trequadragintillion", "quattuorquadragintillion", "quinquadragintillion", "sexquadragintillion", "septenquadragintillion", "octoquadragintillion", "novemquadragintillion", "quinquagintillion", "unquinquagintillion", "duoquinquagintillion", "trequinquagintillion", "quattuorquinquagintillion", "quinquinquagintillion", "sexquinquagintillion", "septenquinquagintillion", "octoquinquagintillion", "novemquinquagintillion", "sexagintillion", "unsexagintillion", "duosexagintillion", "tresexagintillion", "quattuorsexagintillion", "quinsexagintillion", "sexsexagintillion", "septensexagintillion", "octosexagintillion", "novemsexagintillion", "septuagintillion", "unseptuagintillion", "duoseptuagintillion", "treseptuagintillion", "quattuorseptuagintillion", "quinseptuagintillion", "sexseptuagintillion", "septenseptuagintillion", "octoseptuagintillion", "novemseptuagintillion", "octogintillion", "unoctogintillion", "duooctogintillion", "treoctogintillion", "quattuoroctogintillion", "quinoctogintillion", "sexoctogintillion", "septenoctogintillion", "octooctogintillion", "novemoctogintillion", "nonagintillion", "unnonagintillion", "duononagintillion", "trenonagintillion", "quattuornonagintillion", "quinnonagintillion", "sexnonagintillion", "septennonagintillion", "octononagintillion", "novemnonagintillion", "centillion" };
    private static double log;
    private static string Suffix;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public static string NumtoString(double BloonCount)
    {
        if (BloonCount > 1000)
        {
            log = Math.Log(BloonCount, 1000d);
            return string.Format("${0:F3} {1}", (BloonCount/ Math.Pow(1000,Math.Floor(log))), LargeNumberNames[Convert.ToInt32(Math.Floor(log)) - 1]);
            
        }
        else {
            return string.Format("${0}", (Math.Floor(BloonCount)));
        }
    }
}
