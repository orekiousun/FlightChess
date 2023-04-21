using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;
using NameList;

public class StatusUI : UIBase {
    [ChildValueBind("EndRoundBtn", nameof(Button.onClick))]
    Action OnEndRoundButton;

    private Dictionary<int, Text> texts = new Dictionary<int, Text>();
    private Text roundTitleText;

    public override void OnDisplay(object args) {
        for (int i = 1; i <= 6; i++) {
            texts.Add(i, Get<Text>("Count" + i.ToString()));
            texts[i].text = "0";
        }
        roundTitleText = Get<Text>("RoundText");
        OnEndRoundButton = EndRoundAction;
    }

    /// <summary>
    /// 更新UI中各个骰子的值
    /// </summary>
    public void UpdateItemTexts(Dictionary<int, int> items) {
        for (int i = 1; i <= 6; i++) {
            texts[i].text = items[i].ToString();
        }
    }

    /// <summary>
    /// 更新标题的值
    /// </summary>
    public void UpdateTitleText(string roundTitle) {
        roundTitleText.text = roundTitle;
    }

    private void EndRoundAction() {
        GameMgr.RoundMgr.ChangeRound();
        UIManager.Instance.Close(NameList.UI.Round_NormalUI.ToString());
        UIManager.Instance.Close(NameList.UI.MinusItemUI.ToString());
        UIManager.Instance.Close(NameList.UI.ExitUI.ToString());
    }
}
