using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class GameProcedure : ProcedureBase {
    protected override void OnInit() {
        
    }

    protected override void OnEnter(object args) {
        GameMgr.SceneMgr.ChangeScene(args.ToString());
        // 这里的开启statusUI放到了ItemManager里面获取到NewSceneLoaded的消息时执行，方便获取实例
        // UIManager.Instance.Open(NameList.UI.StatusUI.ToString());
    }

    protected override void OnLeave() {
        UIManager.Instance.Close(NameList.UI.StatusUI.ToString());
    }
}
