using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : IFSMState
{
    public void OnEnter()
    {
        Debug.Log("开始空闲....");
    }

    public void OnExit()
    {
        Debug.Log("空闲结束....");
    }

    public void OnUpdate()
    {
        Debug.Log("空闲....");
    }
}
