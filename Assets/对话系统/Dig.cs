using UnityEngine;
using UnityEngine.UI;
using Cysharp.Threading.Tasks;

[System.Serializable]
public class Dig
{
    public DigDate digDate;
    public bool digo = true;
    //CHAT
    public void DChat(DigDate digFist,DigDate digSec)
    {
        if(digo)
        {
            DigStart(digFist);
            digo = !digo;
        }
        else
        {
            DigStart(digSec);
            digo = !digo;
        }
    }
    //开始对话
    public void DigStart(DigDate dig)
    {
        DigShow(dig,dig.idex);
        DigNext(dig);
    }
    //选择对话
    public void DigStart(DigDate dig,int idex)
    {
        sectDig(dig,idex);
        dig.idex = 0; 
    }
    //选择对话
    private void sectDig(DigDate dig,int dex)
    {
        if(dex>=digDate.digs.Length)
        {
            Debug.Log("超出最大序号");
            return;
        }
        DigShow(dig,dex);
    }
    //下一个对话
    private void DigNext(DigDate dig)
    {
        dig.idex++;
        if(dig.idex>=dig.digs.Length)
        {
            dig.idex = 0;
        }
    }

    //显示模式S
    public async void DigShow(DigDate dig,int index)
    {
        dig.tex.text = "";
        await DigShowUni(dig,index);
    }

    async UniTask DigShowUni(DigDate dig,int index)
    {
        dig.strName.text = dig.name;
        dig.charaHeader.sprite = dig.sprite;
        foreach (var item in dig.digs[index])
        {
            dig.tex.text += item;
            await UniTask.Delay(100);
        }
    }

    
}
[System.Serializable]
public class DigDate
{
    [Header("名字")]
    public string name;
    [Header("头像")]
    public Sprite sprite;
    [Header("对话")]
    public string[] digs;
    [Header("对话序号")]
    public int idex;
    [Header("对话内容")]
    public Text tex;
    [Header("对话框名字")]
    public Text strName;
    [Header("对话框头像")]
    public Image charaHeader;
}
