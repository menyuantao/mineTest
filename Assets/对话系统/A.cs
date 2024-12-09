using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class A : MonoBehaviour
{
    public Dig mdig;
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                switch(hit.collider.gameObject.name){
                    case "npc1":
                    hit.collider.gameObject.GetComponent<NPC1>().say();
                        break;
                    case "npc2":
                    hit.collider.gameObject.GetComponent<NPC2>().say();
                        break;
                    case "chatNPC":
                        hit.collider.gameObject.GetComponent<chatNPC>().say();
                        break;
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Space))
        {
            mdig.DigStart(mdig.digDate);
        }
    }
}
