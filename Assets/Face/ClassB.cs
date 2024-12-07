using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassB : MonoBehaviour
{
    IPerson Cat = new MangerFace();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.D))
        {
            Debug.Log("猫");Cat.Move();
        }
    }
}
