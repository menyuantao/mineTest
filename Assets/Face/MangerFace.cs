using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public interface IPerson
{
    void Move();
}
public class MangerFace : MonoBehaviour,IPerson
{ 
    public void Move()
    {
        Debug.Log("移动");
    }
}
