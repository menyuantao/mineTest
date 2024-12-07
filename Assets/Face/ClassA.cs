using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClassA : MonoBehaviour
{
    IPerson Dog = new MangerFace();
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("狗");Dog.Move();
        }
    }
}