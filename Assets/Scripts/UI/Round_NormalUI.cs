using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QxFramework.Core;
using System;
using NameList;

public class Round_NormalUI : UIBase {
    [ChildValueBind("ForwardBtn", nameof(Button.onClick))]
    Action OnForwardButton;

    [ChildValueBind("MinusBtn", nameof(Button.onClick))]
    Action OnMinusButton;

    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    public override void OnDisplay(object args) {
        OnForwardButton = ForwardAction;
        OnMinusButton = MinusAction;
        OnExitButton = ExitAction;
    }

    /// <summary>
    /// 选择一个骰子，执行向前的逻辑
    /// </summary>
    private void ForwardAction() {

        UIManager.Instance.Close(this);
    }

    /// <summary>
    /// 选择两个骰子进行减法，获得一个新骰子
    /// </summary>
    private void MinusAction() {
        UIManager.Instance.Close(this);
    }

    /// <summary>
    /// 直接退出当前回合，开启新回合
    /// </summary>
    private void ExitAction() {
        UIManager.Instance.Close(this);
        GameMgr.RoundMgr.ChangeRound(RoundType.Normal);
    }
}