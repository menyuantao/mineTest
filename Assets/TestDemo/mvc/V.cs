using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class V : MonoBehaviour
{
    public Text text;
    public Button button;

    void Start()
    {
        button.onClick.AddListener(() =>
        {
            M.num.Value++;
            M.num.OnValueChange += changer;
        });
    }
    void changer(int b)
    {
        text.text = M.num.Value.ToString();
    }
}
