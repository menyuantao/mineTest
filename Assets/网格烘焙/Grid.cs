using UnityEngine;

public class Grid : MonoBehaviour
{
    public Vector2Int size; // 网格大小
    public Vector2 gridSize; // 每个格子的大小

    public Vector3 Test;
    public Transform gridBirthPos;

    // 获取格子的中心点位置
    public Vector3Int GetCellCenterPosition(Vector3 cellPosition)
    {
        int x = Mathf.FloorToInt(cellPosition.x * gridSize.x);
        int z = Mathf.FloorToInt(cellPosition.z * gridSize.y);
        if(x>=size.x||z>=size.y)
        {
            Debug.Log("超出范围");
            return new Vector3Int(-999,-999,-999);
        }
        return new Vector3Int(x, (int)Mathf.Floor(gameObject.transform.position.y), z);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(GetCellCenterPosition(Test));
        }
        DrawGrid();
    }

    void DrawGrid()
    {
        // 清除之前的网格线
        Debug.ClearDeveloperConsole();

        // 计算网格的总大小
        Vector3 gridOrigin = gridBirthPos.transform.position; // 网格的起始点，可以根据需要调整
        for (int x = 0; x <= size.x; x++)
        {
            for (int z = 0; z <= size.y; z++)
            {
                // 绘制垂直线
                Debug.DrawLine(
                    new Vector3(gridOrigin.x + x * gridSize.x, gridOrigin.y, gridOrigin.z + z * gridSize.y),
                    new Vector3(gridOrigin.x + x * gridSize.x, gridOrigin.y, gridOrigin.z + gridSize.y),
                    Color.red
                );

                // 绘制水平线
                Debug.DrawLine(
                    new Vector3(gridOrigin.x + x * gridSize.x, gridOrigin.y, gridOrigin.z + z * gridSize.y),
                    new Vector3(gridOrigin.x * gridSize.x, gridOrigin.y, gridOrigin.z + z * gridSize.y),
                    Color.red
                );
            }
        }
    }
}