using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chatNPC : MonoBehaviour
{
    public Dig mdig;
    public GameObject player;

    public void say()
    {
        mdig.DChat(player.GetComponent<A>().mdig.digDate,mdig.digDate);
    }
}
