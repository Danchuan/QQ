using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class GamePlayer : NetworkBehaviour
{
    [SyncVar(hook = "UpdateInfo")]
    public PlayerInfo info;//玩家信息

    private PlayerNameCanvas myCanvas;//我的信息画布

    private void Start()
    {
        LobbyManager lob = LobbyManager.singleton as LobbyManager;

        //设置初始位置
        Transform startPoint = lob.GetSpawnPos(info.ID - 1);
        transform.position = startPoint.position;//获取出生点位置
        transform.rotation = startPoint.rotation;//获取出生点旋转角度

        PlayerMove move = GetComponent<PlayerMove>();
        move.InitPosRota(transform.position, transform.rotation);

        gameObject.name = "Player_" + info.ID;

        PlayerNameCanvas canvasPrefab = Resources.Load<PlayerNameCanvas>("Prefabs/PlayerNameCanvas");
        myCanvas = Instantiate<PlayerNameCanvas>(canvasPrefab);
        myCanvas.InitCanvas(info.name, transform.Find("CanvasPoint"));
    }

    public override void OnStartLocalPlayer()                              
    {
        //设置本地玩家初始化信息及显示
        PlayerController playerCon = gameObject.AddComponent<PlayerController>();
        playerCon.InitCar(transform, this);
    }

    public override void OnNetworkDestroy()
    {
        if (myCanvas != null)
        {
            Destroy(myCanvas.gameObject);
        }
    }

    /// <summary>
    /// 更新玩家信息
    /// </summary>
    /// <param name="varInfo">玩家信息</param>
    private void UpdateInfo(PlayerInfo varInfo)
    {
        info = varInfo;
    }
}
