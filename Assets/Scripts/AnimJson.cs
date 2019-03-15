using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public struct AnimJson {

        public List<SpriteInfo> actors;
        public List<Timelines> timelines;
        public List<stageoptions> stageOptions;
    [Serializable]
    public class SpriteInfo
        {
            public int[] Alignment;
            public ulong Colour;
            public float Alpha;
            public float Angle;
            public int Flip;
            public float[] Position;
            public float[] Scale;
            public bool Shown;
            public string sprite;
            public int type;
            public int uid;
            public float Time;
            public List<SpriteInfo> TimeLine;
        }
    [Serializable]
    public class stageoptions
        {
            public float StageLength;
        }
    [Serializable]
    public class Timelines
        {
            public int spriteuid;
            public List<SpriteInfo> stage;
        }

    public static AnimJson CreateFromJSON(string jsonString)
    {
        Debug.Log(jsonString);
       return JsonUtility.FromJson<AnimJson>(jsonString);
        
    }
}
