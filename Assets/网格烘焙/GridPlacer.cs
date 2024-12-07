using System;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class GridPlacer : MonoBehaviour
{
    public GameObject objectToPlace; // 要放置的对象
    public Grid grid; // 网格系统
    public Camera cam;
    public Dropdown dropdown;
    public GameObject TestPos;


    void Update()
    {
        if (Input.GetMouseButton(0)) // 鼠标左键点击
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if(Physics.Raycast(ray,out hit))
            {
                if(hit.collider.gameObject.name == "Plane")
                {
                    Vector3 pos = grid.GetCellCenterPosition(hit.point);
                    Debug.Log(pos);
                    TestPos.transform.position = pos;
                    GameObject obj = Instantiate(objectToPlace, pos, Quaternion.identity);
                    Material mat = new Material(Shader.Find("Unlit/Color"));
                    switch(dropdown.value)
                    {
                        case 0:
                            mat.color = Color.red;
                            break;
                        case 1:
                            mat.color = Color.blue;
                            break;
                        case 2:
                            mat.color = Color.yellow;
                            break;
                        case 3:
                            mat.color = Color.black;
                            break;
                    }
                    obj.transform.GetChild(0).GetComponent<MeshRenderer>().material = mat;
                }
            }
        }

        if(Input.GetKeyDown(KeyCode.K))
        {
            CaptureScreenshot();
        }
    }


    public string folderPath = "Assets/网格烘焙"; // 保存截图的文件夹路径

    public void CaptureScreenshot()
    {
        // 确保文件夹存在
        if (!Directory.Exists(folderPath))
        {
            Directory.CreateDirectory(folderPath);
        }

        // 设置截图文件名
        string filePath = Path.Combine(folderPath, $"Screenshot_{DateTime.Now:yyyyMMddHHmmss}.jpg");

        // 截取屏幕并保存为JPG
        ScreenCapture.CaptureScreenshot(filePath);
        Debug.Log($"Screenshot saved to: {filePath}");
    }




}

