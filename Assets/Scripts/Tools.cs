using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using UnityEngine;
using UnityEditor;
namespace Assets.Scripts
{
    class Tools
    {
        /*public AnimJson jsons = new AnimJson();
        public int NKConstant = 24;
        public bool extractIngamepng(string ingamepngfolderpath, string outputfolder) //ToDo: Make more robust if I feel like it
        {
            //
            string IngamePng = null;
            string IngameXml = null;
            foreach(string file in Directory.GetFiles(ingamepngfolderpath))
            {
                if (file.Contains("InGame"))
                {
                    if (file.Contains(".xml"))
                    {
                        IngameXml = file;
                    }
                    if (file.Contains(".png"))
                    {
                        IngamePng = file;
                    }
                }
            }
            
            Image gayimage = Image.FromFile(IngamePng);
            Bitmap image = new Bitmap(gayimage);
            string[] xml = File.ReadAllLines(IngameXml);

            bool isanimation = false;
            string currentdirectory = outputfolder;
            for (int i = 2; i < xml.Length; i++)
            {
                if (xml[i].Contains("Animation"))
                {
                    //isanimation = !isanimation //Toggle
                    if (!isanimation)
                    {
                        string name = xml[i].Split('=')[1];
                        char[] arr = name.ToCharArray();
                        arr = Array.FindAll<char>(arr, (c => (char.IsLetterOrDigit(c)
                                                              || c == '_')));
                        name = new string(arr);
                        currentdirectory = outputfolder + @"\" + name;
                        isanimation = true;
                    }
                    else
                    {
                        currentdirectory = outputfolder;
                        isanimation = false;
                    }
                    continue;
                }

                string[] cell = xml[i].Split('=');
                //1 = name, 2 = x, 3 = y, 4 = w, 5 = h
                Debug.Log(cell[1]);
                string namezs = cell[1].Split('"')[1];
                int x = int.Parse(cell[2].Split('"')[1]);
                int y = int.Parse(cell[3].Split('"')[1]);
                int w = int.Parse(cell[4].Split('"')[1]);
                int h = int.Parse(cell[5].Split('"')[1]);

               


                if (!Directory.Exists(currentdirectory))
                {
                    Directory.CreateDirectory(currentdirectory);
                }

                Rectangle imagecrop = new Rectangle(x, y, w, h);
              

                Image outputimage = image.Clone(imagecrop, image.PixelFormat);
                Bitmap img = new Bitmap(int.Parse(cell[8].Split('"')[1]), int.Parse(cell[9].Split('"')[1]));
                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(img);
                g.DrawImage(outputimage, new Point(int.Parse(cell[6].Split('"')[1]), int.Parse(cell[7].Split('"')[1])));

               
                img.Save(currentdirectory + @"\" + namezs + ".png");

            }
        

            


            return false;
        }
        public void JsonToAnimation(AnimJson Json, string FileName)
        {
            float stagelen = Json.AnimData.stageOptions.StageLength;
            AnimationClip Clip = new AnimationClip();
            Clip.legacy = true;
            Clip.frameRate = 100f;
            List<String> names= new List<string>();
            List<int> namessuff = new List<int>();
            /*AnimationCurve test2 = new AnimationCurve();
            Keyframe test = new Keyframe();
            test.value = 0;
            test.time = 0;
            test2.AddKey(test);
            test.value = 0;
            test.time = 1;
            test2.AddKey(test);
            test.value = 1;
            test.time = 2;
            test2.AddKey(test);
            test.value = 0;
            test.time = 3;
            test2.AddKey(test);
            Clip.SetCurve("dart_monkey_body", typeof(SpriteRenderer), "m_Enabled", test2);
            AssetDatabase.CreateAsset(Clip, "Assets/Test.anim");
            clip = Clip;*/


            /*foreach (var item in Json.AnimData.Actors)
            {

                if (item.TimeLine != null)
                {
                    AnimationCurve CurveX = new AnimationCurve();
                    AnimationCurve CurveY = new AnimationCurve();
                    AnimationCurve CurveEnabled = new AnimationCurve();
                    Keyframe Key = new Keyframe();
                    #region activate
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {
                            //Activate 
                            Key.inTangent = 1f / 0f;
                            Key.outTangent = 1f / 0f;
                            Key.time = item.TimeLine[i].Time - 0.01f;
                            CurveEnabled.AddKey(Key); Key.value = Convert.ToInt32(item.TimeLine[i].Shown);
                            Key.inTangent = 1f / 0f;
                            Key.outTangent = 1f / 0f;
                            Key.time = item.TimeLine[i].Time;
                            CurveEnabled.AddKey(Key);
                        }
                        else
                        {
                            //Activate
                            Key.value = Convert.ToInt32(item.TimeLine[i].Shown);
                            Key.inTangent = 1f / 0f;
                            Key.outTangent = 1f / 0f;
                            Key.time = item.TimeLine[i].Time;
                            CurveEnabled.AddKey(Key);

                        }
                    }
                    Key.value = Convert.ToInt32(item.TimeLine[item.TimeLine.Count - 1].Shown);
                    Key.inTangent = 1f / 0f;
                    Key.outTangent = 1f / 0f;
                    Key.time = stagelen;
                    CurveEnabled.AddKey(Key);
                    Key.value = Convert.ToInt32(item.TimeLine[0].Shown);
                    Key.inTangent = 1f / 0f;
                    Key.outTangent = 1f / 0f;
                    Key.time = stagelen + 0.01f;
                    CurveEnabled.AddKey(Key);
                    for (int q = 0; q < names.Count; q++)
                    {
                        if(names[q] == item.Sprite)
                        {
                            item.Sprite = item.Sprite + "(" + namessuff[q] + ")";
                            namessuff[q]++;
                        }
                    }
                    names.Add(item.Sprite);
                    namessuff.Add(1);
                    Clip.SetCurve(item.Sprite, typeof(SpriteRenderer), "m_Enabled", CurveEnabled);
                    #endregion
                    #region x axis
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {


                            Key.value = item.TimeLine[i].Position[0]/NKConstant;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = item.TimeLine[i].Position[0] / NKConstant;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = (item.TimeLine[item.TimeLine.Count - 1].Position[0] / NKConstant);
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = item.TimeLine[0].Position[0] / NKConstant;
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key); 
                    Clip.SetCurve(item.Sprite, typeof(Transform), "localPosition.x", CurveX);
                    #endregion
                    #region y axis
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {


                            Key.value = -item.TimeLine[i].Position[1] / NKConstant;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = -item.TimeLine[i].Position[1] / NKConstant;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = -(item.TimeLine[item.TimeLine.Count - 1].Position[1] / NKConstant);
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = -item.TimeLine[0].Position[1]/NKConstant;
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key);
                    Clip.SetCurve(item.Sprite, typeof(Transform), "localPosition.y", CurveX);
                    #endregion
                    #region alpha
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {

                            Key.value = item.TimeLine[i].Alpha;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = item.TimeLine[i].Alpha;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = (item.TimeLine[item.TimeLine.Count - 1].Alpha);
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = item.TimeLine[0].Alpha;
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key); 
                    Clip.SetCurve(item.Sprite, typeof(SpriteRenderer), "m_Color.a", CurveX);
                    #endregion
                    #region red
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {

                            Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[i].Colour).r;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[i].Colour).r;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[item.TimeLine.Count - 1].Colour).r;
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[0].Colour).r;
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key);
                    Clip.SetCurve(item.Sprite, typeof(SpriteRenderer), "m_Color.r", CurveX);
                    #endregion
                    #region green
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {

                            Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[i].Colour).g;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[i].Colour).g;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[item.TimeLine.Count - 1].Colour).g;
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[0].Colour).g;
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key); 
                    Clip.SetCurve(item.Sprite, typeof(SpriteRenderer), "m_Color.g", CurveX);
                    #endregion
                    #region blue
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {

                            Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[i].Colour).b;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[i].Colour).b;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[item.TimeLine.Count - 1].Colour).b;
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = ConvertFromNKSpaghettiToRGB(item.TimeLine[0].Colour).g;
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key); 
                    Clip.SetCurve(item.Sprite, typeof(SpriteRenderer), "m_Color.g", CurveX);
                    #endregion
                    #region x scale
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {


                            Key.value = item.TimeLine[i].Scale[0];
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = item.TimeLine[i].Scale[0];
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = (item.TimeLine[item.TimeLine.Count - 1].Scale[0]);
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = item.TimeLine[0].Scale[0];
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key); 
                    Clip.SetCurve(item.Sprite, typeof(Transform), "localScale.x", CurveX);
                    #endregion
                    #region y scale
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {


                            Key.value = item.TimeLine[i].Scale[1];
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = item.TimeLine[i].Scale[1];
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = (item.TimeLine[item.TimeLine.Count - 1].Scale[1]);
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Key.value = item.TimeLine[0].Scale[0];
                    Key.time = stagelen + 0.01f;
                    CurveX.AddKey(Key); 
                    Clip.SetCurve(item.Sprite, typeof(Transform), "localScale.y", CurveX);
                    #endregion
                    #region rotation
                    CurveX = new AnimationCurve();
                    Key = new Keyframe();
                    for (int i = 0; i < item.TimeLine.Count; i++)
                    {

                        if (i != 0)
                        {

                           
                            Key.value = item.TimeLine[i].Angle*-1f/4f;
                            Key.time = item.TimeLine[i-1].Time +( item.TimeLine[i].Time*(1f/4f));
                            CurveX.AddKey(Key);
                            Key.value = item.TimeLine[i].Angle * -2f/4f;
                            Key.time = item.TimeLine[i - 1].Time + (item.TimeLine[i].Time * (2f / 4f));
                            CurveX.AddKey(Key);
                            Key.value = item.TimeLine[i].Angle * -3f/4f;
                            Key.time = item.TimeLine[i - 1].Time + (item.TimeLine[i].Time * (3f / 4f));
                            CurveX.AddKey(Key);
                            Key.value = item.TimeLine[i].Angle * -1f;
                            Key.time = item.TimeLine[i - 1].Time + (item.TimeLine[i].Time * (4f / 4f));
                            CurveX.AddKey(Key);
                        }
                        else
                        {

                            Key.value = item.TimeLine[i].Angle*-1f;
                            Key.time = item.TimeLine[i].Time;
                            CurveX.AddKey(Key);

                        }
                    }
                    Key.value = -1f*(item.TimeLine[item.TimeLine.Count - 1].Angle);
                    Key.time = stagelen-0.01f;
                    CurveX.AddKey(Key);
                    Key.value = -1f * (item.TimeLine[0].Angle);
                    Key.time = stagelen;
                    CurveX.AddKey(Key);
                    Clip.SetCurve(item.Sprite, typeof(Transform), "localEulerAnglesBaked.z", CurveX);
                    #endregion


                }
            }
            Clip.name = "yug";
           // AssetDatabase.CreateAsset(Clip, "Assets/Resources/Anim/Tower/"+FileName+".anim");
            /*AnimationClip test = new AnimationClip();
            AnimationEvent Test2 = new AnimationEvent();
            AnimationCurve Tes = AnimationCurve.Linear(0.5f, 1f,1f, 9f);
            AnimationCurve Tesa = AnimationCurve.Linear(0.5f, 1f,1f, 0f);
            test.legacy = true;
            test.SetCurve("", typeof(Transform), "localPosition.x", Tes);
            test.SetCurve("BasicSprite", typeof(Transform), "localPosition.x", Tes);
            test.SetCurve("BasicSprite", typeof(SpriteRenderer), "Enabled", Tesa);*/

      /*  }
        public Color32 ConvertFromNKSpaghettiToRGB(ulong NkColour)
        {
           try
            {

                string HexValue = NkColour.ToString("X");
                return new UnityEngine.Color(Convert.ToInt32(HexValue.Substring(6, 2), 16) / 255f, Convert.ToInt32(HexValue.Substring(4, 2), 16) / 255f, Convert.ToInt32(HexValue.Substring(2, 2), 16) / 255f, 1);
            }
            catch
            {
                return UnityEngine.Color.white;
            }
        }
        public void Jsoncon(string Path)
        {
            foreach (string file in Directory.GetFiles(Path))
            {
                if (file.Contains(".json"))
                {
                    string Json = System.IO.File.ReadAllText(file);
                    jsons.ParseJson(Json);
                    JsonToAnimation(jsons, System.IO.Path.GetFileNameWithoutExtension(file));
                    Debug.Log(file);
                }
            }
        }*/
    }
}
