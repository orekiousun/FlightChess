using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;

public class SelectProcedure : ProcedureBase {
    protected override void OnInit() {
        
    }

    protected override void OnEnter(object args) {
        UIManager.Instance.Open(NameList.UI.SelectUI.ToString());
    }

    protected override void OnLeave() {
        UIManager.Instance.Close(NameList.UI.SelectUI.ToString());
    }
}
