using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class TitleProcedure : ProcedureBase {
    protected override void OnInit() {
        
    }

    protected override void OnEnter(object args) {
        GameMgr.Instance.InitModules();
        UIManager.Instance.Open(NameList.UI.TitleUI.ToString());
    }

    protected override void OnLeave() {
        UIManager.Instance.Close(NameList.UI.TitleUI.ToString());
    }
}
