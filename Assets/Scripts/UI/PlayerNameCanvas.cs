using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerNameCanvas : MonoBehaviour
{
    private Transform lookTarget;//朝向目标
    private Transform followTarget;//跟随目标

    /// <summary>
    /// 初始化画布
    /// </summary>
    /// <param name="playerName">玩家名称</param>
    public void InitCanvas(string playerName,Transform varFollow)
    {
        Text txt_Name = GetComponentInChildren<Text>();
        txt_Name.text = playerName;

        followTarget = varFollow;
        lookTarget = GameObject.Find("RCC_Car Camera").transform;
    }

    private void Update()
    {
        if (lookTarget != null)
        {
            transform.LookAt(new Vector3(lookTarget.position.x, transform.position.y, lookTarget.position.z));
        }
        else
        {
            lookTarget = GameObject.Find("RCC_Car Camera").transform;
        }

        if (followTarget != null)
        {
            transform.position = followTarget.position;
        }
    }
}
