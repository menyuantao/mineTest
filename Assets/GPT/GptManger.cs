using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class GptManger : MonoBehaviour
{
    public string apiEndpoint = "https://api.openai.com/v1/chat/completions"; // 假设的API端点

    void Start()
    {
        StartDialogue("你好");
    }

    // 注意：这个方法现在返回Task
    public async Task StartDialogue(string playerInput)
    {
        string url = $"{apiEndpoint}?input={Uri.EscapeDataString(playerInput)}"; // 对playerInput进行URL编码
        UnityWebRequest request = UnityWebRequest.Get(url);
        /*/*------------*/

        // 发送请求
        request.SendWebRequest(); // 使用await等待请求完成
        await Task.Delay(3000); // 等待1秒，以确保请求完成

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError(request.error);
        }
        else
        {
            // 处理响应
            string response = request.downloadHandler.text;
            Debug.Log(response);
        }
    }
}