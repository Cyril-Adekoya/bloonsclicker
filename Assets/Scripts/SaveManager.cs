using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


class SaveManager
{
    public byte[] encrypt(string Savedata)
    {
        //Base64 here
        byte[] savedata = Encoding.UTF8.GetBytes(Savedata);
        Savedata = Convert.ToBase64String(savedata);
        savedata = Encoding.UTF8.GetBytes(Savedata);

        for (int i = 0; i * 16 < savedata.Length; i++)
        {
            byte byteswap; //7 <-> 12, 14 <-> 2

            byteswap = savedata[i * 12];
            savedata[i * 12] = savedata[i * 7];
            savedata[i * 7] = byteswap;

            byteswap = savedata[i * 2];
            savedata[i * 2] = savedata[i * 14];
            savedata[i * 14] = byteswap;

            savedata[i * 16] += 3;
            savedata[i * 3] += 2;
            savedata[i * 7] += 1;

        }

        return savedata;

    }

    public string decrypt(byte[] savedata)
    {
        //Debug.Log(Encoding.UTF8.GetString(savedata));
        //Base64 here
        for (int i = 0; i * 16 < savedata.Length; i++)
        {
            byte byteswap; //7 <-> 12, 14 <-> 2

            byteswap = savedata[i * 12];
            savedata[i * 12] = savedata[i * 7];
            savedata[i * 7] = byteswap;

            byteswap = savedata[i * 2];
            savedata[i * 2] = savedata[i * 14];
            savedata[i * 14] = byteswap;

            savedata[i * 16] -= 3;
            savedata[i * 3] -= 2;
            savedata[i * 7] -= 1;

        }
        
        string Savedata = Encoding.UTF8.GetString(savedata);
        try
        {
            Debug.Log(Convert.FromBase64String(Savedata));
        }
        catch(Exception e)
        {
            Debug.Log(e);
        }
        
        Savedata = Encoding.UTF8.GetString(Convert.FromBase64String(Savedata));
        return Savedata;

    }





}

