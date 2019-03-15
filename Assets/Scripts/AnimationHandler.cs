using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEditor;

public class AnimationHandler : MonoBehaviour {
    public AnimJson AnimData;
    public GameObject BasicPrefab;
    public List<GameObject> SpriteList;
    public float TimeCount;
    public int SpriteDeapth=0;
    public AnimationClip clip;
    public Animation ANim;
    public GameObject Type2;
    public void StartUp(string Pth, int type)
    {
        
        AnimData =AnimJson.CreateFromJSON(Resources.Load<TextAsset>("Anim/TowerJson/" + Pth).ToString());
        Debug.Log(AnimData.actors[0].sprite);
        Debug.Log(AnimData.stageOptions);
        Debug.Log(AnimData.timelines);
        foreach (var item in AnimData.actors)
        {
            foreach (var Stage in AnimData.timelines)
            {
                if (Stage.spriteuid == item.uid)
                {
                    item.TimeLine = Stage.stage;
                }
            }
        }
        foreach (var item in SpriteList)
        {
            Destroy(item);
        }
         GameObject SpriteObject;
        SpriteRenderer Spriteren;
        List<string> names = new List<string>();
        List<int> namessuff = new List<int>();
        foreach (var item in AnimData.actors)
        {
            if (item.type == 1)
            {
                SpriteObject = Instantiate(BasicPrefab, transform);
                Spriteren = SpriteObject.GetComponent<SpriteRenderer>();
                SpriteObject.transform.localPosition += new Vector3(item.Position[0] / 24, -item.Position[1] / 24, 0);
                Spriteren.sortingOrder = StaticObject.LayerCount;
                StaticObject.LayerCount++; 
                SpriteList.Add(SpriteObject);
                Spriteren.enabled = (item.Shown);
                SpriteObject.transform.localScale = new Vector3(item.Scale[0], item.Scale[1], 0);
                Spriteren.sprite = Resources.Load<Sprite>("InGame/" + item.sprite);
                SpriteObject.transform.Rotate(new Vector3(0, 0, -item.Angle));
                for (int q = 0; q < names.Count; q++)
                {
                    if (names[q] == item.sprite)
                    {
                        item.sprite = item.sprite + "(" + namessuff[q] + ")";
                        namessuff[q]++;
                    }
                }
                names.Add(item.sprite);
                namessuff.Add(1);
                SpriteObject.name = item.sprite;

                if (item.Flip == 1)
                    SpriteObject.GetComponent<SpriteRenderer>().flipX = true;
                else if (item.Flip == 2)
                    SpriteObject.GetComponent<SpriteRenderer>().flipY = true;
                else if (item.Flip == 3)
                {
                    SpriteObject.GetComponent<SpriteRenderer>().flipY = true;
                    SpriteObject.GetComponent<SpriteRenderer>().flipX = true;
                }
                if (item.Alignment[0] != 0 || item.Alignment[1] != 0)
                {
                    print(new Vector2(Spriteren.sprite.rect.width / 2, Spriteren.sprite.rect.height / 2));
                    Spriteren.sprite = Sprite.Create(Spriteren.sprite.texture, new Rect(0, 0, Spriteren.sprite.rect.size.x, Spriteren.sprite.rect.size.y), new Vector2(0.5f + item.Alignment[0] / 4f, 0.5f + item.Alignment[1] / 4f));
                }
               
               
                
            }
            else
            {

                SpriteObject = Instantiate(Type2, transform);
                print(SpriteObject);
                SpriteList.Add(SpriteObject);
                SpriteObject.transform.localScale = new Vector3(item.Scale[0], item.Scale[1], 0);
                SpriteObject.name = item.sprite;
                SpriteObject.transform.localPosition += new Vector3(item.Position[0] / 24, -item.Position[1] / 24, 0);
                SpriteObject.transform.Rotate(new Vector3(0, 0, item.Angle));
                SpriteObject.GetComponent<AnimationHandler>().StartUp(item.sprite.Remove(item.sprite.Length - 5, 5), 2);

                

             }
        }
        ANim = GetComponent<Animation>();
        ANim.AddClip( Resources.Load<AnimationClip>("Anim/Tower/" + Pth), "a");
        if (type == 2)
        {
            ANim.wrapMode = WrapMode.Loop;
            ANim.Play("a");
        }

    }
    public void startanimation()
    {
        ANim.Play("a");
    }
    public List<AnimJson.SpriteInfo> GetTimeline(int uid)
    {
        foreach(AnimJson.Timelines tIMELINE in AnimData.timelines)
        {
            

            if (tIMELINE.spriteuid == uid)
            {
                
                return tIMELINE.stage;
            }
        }
        return null;
    }
    public Color32 ConvertFromNKSpaghettiToRGB(ulong NkColour)
    {
        if (NkColour != 0 )
        {
           
            string HexValue = NkColour.ToString("X");
            print(HexValue);
            return new Color(Convert.ToInt32(HexValue.Substring(6, 2), 16)/255f, Convert.ToInt32(HexValue.Substring(4, 2),16)/255f, Convert.ToInt32(HexValue.Substring(2, 2),16)/255f, 1);
        }
        else
        {
            return Color.white;
        }
    }
   
}
