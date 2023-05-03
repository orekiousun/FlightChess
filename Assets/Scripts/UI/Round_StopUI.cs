using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QxFramework.Core;
using System;
using NameList;

public class Round_StopUI : UIBase {
    [ChildValueBind("MinusBtn", nameof(Button.onClick))]
    Action OnMinusButton;

    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    public override void OnDisplay(object args) {
        OnMinusButton = MinusAction;
        OnExitButton = ExitAction;
    }

    /// <summary>
    /// 选择两个骰子进行减法，获得一个新骰子
    /// </summary>
    private void MinusAction() {
        UIManager.Instance.Close(this);
        UIManager.Instance.Open(NameList.UI.MinusItemUI.ToString());
    }

    /// <summary>
    /// 直接退出当前回合，开启新回合
    /// </summary>
    private void ExitAction() {
        UIManager.Instance.Close(this);
        GameMgr.RoundMgr.ChangeRound();
    }
}
