using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MangerPlayer : MonoBehaviour
{
    public GoTo  mgoto = new GoTo();
    public List<GameObject>  list = new List<GameObject>();
    public Transform tar;
    

    void Start()
    {
        list.AddRange(GameObject.FindGameObjectsWithTag("Player"));
    }
    void FixedUpdate()
    {
        mgoto.WMove(list, tar.position);
    }
}
