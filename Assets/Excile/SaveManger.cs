using System.Collections;
using System.Collections.Generic;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Math;
using UnityEngine;


public class SaveManger : MonoBehaviour
{
    public static SaveManger instance;
    void Awake()
    {
        instance = this;
    }

    public void Write(string name,object a)
    {
        if(a is int)
        {
            PlayerPrefs.SetInt(name,(int)a);
        }
        else if(a is float)
        {
            PlayerPrefs.SetFloat(name,(float)a);
        }
        else if(a is string)
        {
            PlayerPrefs.SetString(name,(string)a);
        }
        else{
            Debug.Log("没有这个类型");
        }
        PlayerPrefs.Save();
    }
    public int ReadInt(string name)
    {
        if(PlayerPrefs.HasKey(name) == false)
        {
            Debug.Log("没有这个值");
        }
        return PlayerPrefs.GetInt(name);
    }

    public float ReadFloat(string name)
    {
        if(PlayerPrefs.HasKey(name) == false)
        {
            Debug.Log("没有这个值");
        }
        return PlayerPrefs.GetFloat(name);
    }

    public string ReadString(string name)
    {
        if(PlayerPrefs.HasKey(name) == false)
        {
            Debug.Log("没有这个值");
        }
        return PlayerPrefs.GetString(name);
    }
}
