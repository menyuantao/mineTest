using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC1 : MonoBehaviour
{
    public Dig mdig;

    public void say()
    {
        mdig.DigStart(mdig.digDate);
    }
}
