using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QxFramework.Core;
using System;
using NameList;

public class Round_ForwardUI : UIBase {
    [ChildValueBind("ForwardBtn", nameof(Button.onClick))]
    Action OnForwardButton;

    public override void OnDisplay(object args) {
        OnForwardButton = ForwardAction;
    }

    /// <summary>
    /// 选择一个骰子，执行向前的逻辑
    /// </summary>
    private void ForwardAction() {
        UIManager.Instance.Close(this);
        UIManager.Instance.Open(NameList.UI.SelectItemUI.ToString());
    }
}
