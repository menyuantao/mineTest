using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using OfficeOpenXml;
using UnityEngine.UI;

public class ReadMineExe : MonoBehaviour
{
    public List<string> ASay;
    public List<string> BSay;
    int indexA;
    int indexB;
    public CreaterDate mineDate;

    public Text text;
    public InputField input;
    public Button buttonCun;
    public Button buttonDu;

    void Start()
    {
        mineDate.score = SaveManger.instance.ReadInt("01");
        ReadExcel("Assets/Resources/mineTest.xlsx");
        indexA = 0;
        indexB = 1;

        buttonCun.onClick.AddListener(()=>{
            int num = int.Parse(input.text);
            SaveManger.instance.Write("01",num);
            //WriteExcel("Assets/Excile/mineTest.xlsx",num);
        });
        buttonDu.onClick.AddListener(()=>{
            input.text = SaveManger.instance.ReadInt("01").ToString();
            // using (ExcelPackage package = new ExcelPackage(new FileInfo("Assets/Resources/mineTest.xlsx")))
            // {
            //     // 获取第一个工作表
            //     ExcelWorksheet worksheet = package.Workbook.Worksheets[1];
            //     input.text = worksheet.Cells[3,1].Value.ToString();
            // }
        });
    }

    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Space))
        {

            if(indexB == (mineDate.BSay.Count*2)+1)
            {
                indexA = 0;
                indexB = 1;
            }
            if(indexA < indexB)
            {
                Debug.Log("A:" + mineDate.ASay[indexA/2]);
                text.text = "A:" + mineDate.ASay[indexA/2];
                indexA+=2;
            }

            else if(indexB < indexA)
            {
                Debug.Log("B:" + mineDate.BSay[(indexB-1)/2]);
                text.text = "B:" + mineDate.BSay[(indexB-1)/2];
                indexB+=2;
            }

        }
    }

    public void ReadExcel(string filePath)
    {
        // 确保文件存在
        if (File.Exists(filePath))
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                // 获取第一个工作表
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                // 获取工作表的行数和列数
                // int rowCount = worksheet.Dimension.Rows;
                // int colCount = worksheet.Dimension.Columns;

                // // 遍历工作表中的每个单元格
                // for (int row = 1; row <= rowCount; row++)
                // {
                //     for (int col = 1; col <= colCount; col++)
                //     {

                //         // worksheet.Cells[row,col].Value = "999";
                //         // package.Save();
                //         // 读取单元格的值
                //         var cell = worksheet.Cells[row, col];
                //         rowData.Add(cell.Value.ToString());
                        
                //     }
                // }

                for(int i = 1; i <= worksheet.Dimension.Columns; i++){
                    mineDate.ASay.Add(worksheet.Cells[1,i].Value.ToString());
                    mineDate.BSay.Add(worksheet.Cells[2,i].Value.ToString());
                }
            }
        }
        else
        {
            Debug.LogError("找不到 Excel 文件: " + filePath);
        }
    }

    public void WriteExcel(string filePath,int k)
    {
        // 确保文件存在
        if (File.Exists(filePath))
        {
            using (ExcelPackage package = new ExcelPackage(new FileInfo(filePath)))
            {
                // 获取第一个工作表
                ExcelWorksheet worksheet = package.Workbook.Worksheets[1];

                worksheet.Cells[3,1].Value = k;

                package.Save();
            }
        }
        else
        {
            Debug.LogError("找不到 Excel 文件: " + filePath);
        }
    }
}
