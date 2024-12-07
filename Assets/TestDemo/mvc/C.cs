using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class C : MonoBehaviour
{

    void Start()
    {
        M.num.OnValueChange += add;
    }
    public void add(int value)
    {
        Debug.Log("修改数值");
        Debug.Log(value);
    }
}
