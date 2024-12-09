using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManger : MonoBehaviour
{
    public List<GameObject> mEnemyList;

    void Start()
    {
        mEnemyList.AddRange(GameObject.FindGameObjectsWithTag("Enemy"));
    }
}
