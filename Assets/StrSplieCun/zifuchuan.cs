using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Text;
using UnityEngine;

public class zifuchuan : MonoBehaviour
{

    [Header("名字|ID|数量|")]
    public string str;
    int num;
    public string name;
    public int Number;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            string[] a = str.Split("|");
            num = int.Parse(a[2]);
            num += Number;

            str = a[0]+"|"+a[1]+"|" + num.ToString();

            Adstr adstr = new Adstr{
                Dstr = str};
            string josn = JsonUtility.ToJson(adstr);
            File.WriteAllText(Path.Combine("Assets/StrSplieCun","jsonProMax"),josn);
        }
        if(Input.GetKeyDown(KeyCode.N))
        {
            string[] a = str.Split("|");
            a[0] = name;
            str = a[0]+"|"+a[1]+"|"+a[2];

            Adstr adstr = new Adstr{
                Dstr = str};
            string josn = JsonUtility.ToJson(adstr);
            File.WriteAllText(Path.Combine("Assets/StrSplieCun","jsonProMax"),josn);
        }
    }

}

[Serializable]
public struct Adstr
{
    public string Dstr;
}
