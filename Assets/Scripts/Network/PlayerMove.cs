using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour
{
    [SyncVar]
    private Vector3 pos;
    [SyncVar]
    private Quaternion rota;

    //所有轮胎需要更新的数据
    [SyncVar]
    private Quaternion wheelRota1;
    [SyncVar]
    private Quaternion wheelRota2;
    [SyncVar]
    private Quaternion wheelRota3;
    [SyncVar]
    private Quaternion wheelRota4;

    private RCC_WheelCollider[] allWheels;//所有轮胎

    private float updateFrequency;//更新频率

    private void Awake()
    {
        allWheels = GetComponentsInChildren<RCC_WheelCollider>();
        updateFrequency = 3f;
    }

    //private void FixedUpdate()
    //{
    //    if (!isLocalPlayer)
    //    {
    //        transform.position = Vector3.Lerp(transform.position, pos, updateFrequency * Time.fixedDeltaTime);
    //        transform.rotation = Quaternion.Lerp(transform.rotation, rota, updateFrequency * Time.fixedDeltaTime);

    //        //更新轮胎数据
    //        allWheels[0].wheelModel.rotation = Quaternion.Lerp(allWheels[0].wheelModel.rotation, wheelRota1, updateFrequency * Time.fixedDeltaTime);
    //        allWheels[1].wheelModel.rotation = Quaternion.Lerp(allWheels[1].wheelModel.rotation, wheelRota2, updateFrequency * Time.fixedDeltaTime);
    //        allWheels[2].wheelModel.rotation = Quaternion.Lerp(allWheels[2].wheelModel.rotation, wheelRota3, updateFrequency * Time.fixedDeltaTime);
    //        allWheels[3].wheelModel.rotation = Quaternion.Lerp(allWheels[3].wheelModel.rotation, wheelRota4, updateFrequency * Time.fixedDeltaTime);
    //    }
    //}

    private void Update()
    {
        if (isLocalPlayer)
        {
            CmdSendServerPos(transform.position, transform.rotation);
            //发送轮胎数据
            CmdUpdateWheelData(allWheels[0].wheelModel.rotation, allWheels[1].wheelModel.rotation, allWheels[2].wheelModel.rotation, allWheels[3].wheelModel.rotation);
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, pos, updateFrequency * Time.fixedDeltaTime);
            transform.rotation = Quaternion.Lerp(transform.rotation, rota, updateFrequency * Time.fixedDeltaTime);

            //更新轮胎数据
            allWheels[0].wheelModel.rotation = Quaternion.Lerp(allWheels[0].wheelModel.rotation, wheelRota1, updateFrequency * Time.fixedDeltaTime);
            allWheels[1].wheelModel.rotation = Quaternion.Lerp(allWheels[1].wheelModel.rotation, wheelRota2, updateFrequency * Time.fixedDeltaTime);
            allWheels[2].wheelModel.rotation = Quaternion.Lerp(allWheels[2].wheelModel.rotation, wheelRota3, updateFrequency * Time.fixedDeltaTime);
            allWheels[3].wheelModel.rotation = Quaternion.Lerp(allWheels[3].wheelModel.rotation, wheelRota4, updateFrequency * Time.fixedDeltaTime);
        }
    }

    public void InitPosRota(Vector3 varPos,Quaternion varRota)
    {
        CmdSendServerPos(varPos, varRota);
    }

    [Command]
    private void CmdSendServerPos(Vector3 varPos, Quaternion varRota)
    {
        pos = varPos;
        rota = varRota;
    }

    [Command]
    private void CmdUpdateWheelData(Quaternion varRota1,Quaternion varRota2,Quaternion varRota3,Quaternion varRota4)
    {
        wheelRota1 = varRota1;
        wheelRota2 = varRota2;
        wheelRota3 = varRota3;
        wheelRota4 = varRota4;
    }
}
