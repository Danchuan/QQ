using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 测试玩家
/// </summary>
public class PlayerController : MonoBehaviour
{
    [HideInInspector]
    public GameObject carCamera;//摄像机

    public void InitCar(Transform varParent,GamePlayer player)
    {
        carCamera = GameObject.FindObjectOfType<RCC_Camera>().gameObject;
        carCamera.SetActive(false);

        RCC_EnterExitCar rccCar = gameObject.AddComponent<RCC_EnterExitCar>();
        rccCar.SetCarCamera(carCamera);

        GameObject ob = new GameObject("Player");
        gameObject.SendMessage("Act", ob, SendMessageOptions.DontRequireReceiver);
    }
}
