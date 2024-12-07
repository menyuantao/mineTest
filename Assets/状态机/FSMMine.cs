using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum FSMState
{
    Idel,walk,attack,die
}
public interface IFSMState
{
    void OnEnter();
    void OnExit();
    void OnUpdate();
}
public class FSMMine
{
    private Dictionary<FSMState, IFSMState> mStateDic = new Dictionary<FSMState, IFSMState>();
    private IFSMState mCurrentState;
    private float time;
    public void AddState(FSMState state, IFSMState fsmState)
    {
        Debug.Log("添加状态"+state);
        if (mStateDic.ContainsKey(state))
        {
            Debug.LogError("已经存在该状态");
            return;
        }
        mStateDic.Add(state, fsmState);
    }
    public void ChangeState(FSMState state)
    {
        Debug.Log("切换状态"+state);
        if (mCurrentState!= null)
        {
            mCurrentState.OnExit();
        }
        if (!mStateDic.ContainsKey(state))
        {
            Debug.LogError("不存在该状态");
            return;
        }
        mCurrentState = mStateDic[state];
    }
    public void OnUpdate(float t)
    {
        time += Time.deltaTime * t;
        if(time >= 2)
        {
            if (mCurrentState!= null)
            {
                mCurrentState.OnUpdate();
            }
            time = 0;
        }
    }
}
