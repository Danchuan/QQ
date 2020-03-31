﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainScene : State
{
    public MainScene(GameScene scene) : base(scene.ToString())
    {

    }

    public override void OnStart()
    {
        //UIManager.Instance.ChangePanel(PanelType.None);//不打开界面
        GameManage.playerCanController = false;
    }

    public override void OnEnd()
    {
        GameManage.playerCanController = true;
    }
}
