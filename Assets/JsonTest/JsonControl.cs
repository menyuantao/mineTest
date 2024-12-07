using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class JsonControl : MonoBehaviour
{
    DateMineJson mineDate = new DateMineJson();
    public string filePath;

    public Button ChangerDate;
    public Button Readbutton;
    public Text T;

    void Start()
    {
        ///指定路径
        filePath = Path.Combine("Assets/Resources", "mineDate.json");
        Debug.Log("初始化路径>>>"+filePath);
        T.text = "score:" + mineDate.Scroe.ToString() +"\n"+ "level:" + mineDate.Level.ToString();

        ChangerDate.onClick.AddListener(()=>{
            Debug.Log("数据更新>>");
            mineDate.Scroe ++;
            mineDate.Level += 2;
            string json = JsonUtility.ToJson(mineDate);
            Debug.Log("序列化数据>>"+json);
            BaoCun(json);
        });

        Readbutton.onClick.AddListener(()=>{
            Debug.Log("反序列化数据>>"+filePath);
            DateMineJson i = ReadDate(filePath);
            Debug.Log("score:"+i.Scroe);
            Debug.Log("level:"+i.Level);
            T.text = "score:" + i.Scroe.ToString()+"\n"+"level:" + i.Level.ToString();
            Debug.Log("结束>>");
        });
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("数据更新>>");
            mineDate.Scroe ++;
            mineDate.Level += 2;
            string json = JsonUtility.ToJson(mineDate);
            Debug.Log("序列化数据>>"+json);
            BaoCun(json);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("反序列化数据>>"+filePath);
            DateMineJson i = ReadDate(filePath);
            Debug.Log("score:"+i.Scroe);
            Debug.Log("level:"+i.Level);
            Debug.Log("结束>>");
        }
    }

    void BaoCun(string js)
    {
        File.WriteAllText(filePath, js);
        Debug.Log("数据写入>>");
    }

    DateMineJson ReadDate(string path)
    {
        string jsonDataFromFile = File.ReadAllText(path);
        DateMineJson loadedData = JsonUtility.FromJson<DateMineJson>(jsonDataFromFile);
        return loadedData;
    }
}
