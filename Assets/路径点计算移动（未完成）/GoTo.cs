using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GoTo
{
    public float speed;
    public float spacing;
    public bool isSanKi = false;

    public void WMove(List<GameObject> objs,Vector3 tar)
    {
        if(isSanKi == false)
        {
            float ori = speed;
            speed = 999;
            Vector3[] a = GetrePos(objs[0].transform.position, objs.Count);
            for (int i = 0; i < objs.Count; i++)
            {
                if(objs[i]==null || a[i]==null)
                {
                    return;
                }
                MoveTO(objs[i], a[i]);
            }
            speed = ori;
            isSanKi = true;
            return;
        }
        if(tar==null)
        {
            return;
        }
        Vector3[] rePos = GetrePos(tar, objs.Count);
        for (int i = 0; i < objs.Count; i++)
        {
            if(objs[i]==null || rePos[i]==null)
            {
                return;
            }
            MoveTO(objs[i], rePos[i]);
        }
    }
    private void MoveTO(GameObject obj,Vector3 tar)
    {
        if(Vector3.Distance(obj.transform.position,tar)<0.01f)
        {
            return;
        }
        obj.transform.position = Vector3.MoveTowards(obj.transform.position, tar, speed * Time.deltaTime);
    }


    private Vector3[] GetrePos(Vector3 tar, int num)
{
    int sideLength = (int)Mathf.Sqrt(num) + 1; // 计算方阵的边长，确保有足够的空间
    Vector3[] positions = new Vector3[num]; // 存储方阵位置点

    // 计算方阵的中心偏移量
    float halfSizeX = (sideLength - 1) * spacing / 2f; // 使用间隔计算半边长
    float halfSizeZ = halfSizeX; // 在 xz 平面上，x 和 z 的间隔是相同的

    float startX = tar.x - halfSizeX;
    float startZ = tar.z - halfSizeZ;

    int index = 0;
    for (int i = 0; i < sideLength; i++)
    {
        for (int j = 0; j < sideLength; j++)
        {
            if (index < num) // 确保不超过所需数量
            {
                // 计算方阵中每个点的位置
                Vector3 pos = new Vector3(startX + j * spacing, tar.y, startZ + i * spacing);
                positions[index] = pos;
                index++;
            }
        }
    }

    return positions;
}

}
