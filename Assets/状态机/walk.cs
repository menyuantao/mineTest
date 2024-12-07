using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class walk : IFSMState
{
    private float mSpeed;
    public walk(float speed)
    {
        mSpeed = speed;
    }
    public void OnEnter()
    {
        Debug.Log("walk加载。。。");
    }

    public void OnExit()
    {
        Debug.Log("walk卸载。。。");
    }

    public void OnUpdate()
    {
        Debug.Log("walk中。。。");
    }

}
