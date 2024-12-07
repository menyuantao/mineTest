using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface mCurrentState
{
    void Say(string str);
}
public class TestIII : MonoBehaviour
{
    mCurrentState A = new MA();
    void Start()
    {
        A.Say("你好");
    }
}

public class MA : mCurrentState
{
    public void Say(string str)
    {
        Debug.Log(str);
    }
}

