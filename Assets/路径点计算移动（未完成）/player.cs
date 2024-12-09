using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<GameObject> enemyList;
    Transform pare;
    void Start()
    {
        pare = transform.parent;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag=="Enemy")
        {
            enemyList.Add(other.gameObject);
            Destroy(enemyList[0]);
            Destroy(this.gameObject);
        }
    }

    void OnDestroy()
    {
        pare.GetComponent<MangerPlayer>().list.RemoveAt(pare.GetComponent<MangerPlayer>().list.IndexOf(this.gameObject));
        if(enemyList.Count>0)
        {
            enemyList.Clear();
        }
    }
}
