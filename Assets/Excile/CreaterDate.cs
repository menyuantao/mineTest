using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New CreaterDate", menuName = "ScriptableObjects/CreaterDate")]
public class CreaterDate : ScriptableObject
{
    public List<string> ASay;
    public List<string> BSay;
    public int score;
}
