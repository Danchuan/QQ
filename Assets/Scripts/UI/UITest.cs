using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITest : MonoBehaviour
{
    public Text[] allTest;

    public static UITest Instance;

    private int index;

    private void Awake()
    {
        Instance = this;
        index = -1;
    }

    public void Show(string value)
    {
        index++;
        allTest[index].text = value;
    }
}
