using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M
{
    public static Fan<int> num = new Fan<int>(){Value = 0};
}

public class Fan<T> where T : IEquatable<T>
{
    private T mValue;
    public T Value{
        get => mValue;
        set{
            if(!mValue.Equals(value))
            {
                mValue = value;
                OnValueChange?.Invoke(mValue);
                Debug.Log("值发生了变化");
            }
        }
    }
    public Action<T> OnValueChange;
}
