using System.Collections;
using System.Collections.Generic;
using IdleGame.Fsm;
using UnityEngine;
using UnityEngine.UI;

public class People : MonoBehaviour
{
    public FSMMine fsmMine;
    public float walkspeed;
    void Start()
    {
        fsmMine = new FSMMine();
        fsmMine.AddState(FSMState.walk, new walk(walkspeed));
        fsmMine.AddState(FSMState.Idel, new Idle());
        fsmMine.AddState(FSMState.attack, new attack());
        
        fsmMine.ChangeState(FSMState.Idel);

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            fsmMine.ChangeState(FSMState.walk);
        }
        else if(Input.GetKey(KeyCode.W))
        {
            fsmMine.OnUpdate(4);
        }
        else if(Input.GetKeyUp(KeyCode.W))
        {
            fsmMine.ChangeState(FSMState.Idel);
        }
        else
        {
            fsmMine.OnUpdate(4);
        }
    }
}
