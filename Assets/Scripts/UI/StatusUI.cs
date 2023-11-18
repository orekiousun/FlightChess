using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;
using NameList;

public class StatusUI : UIBase {
    [ChildValueBind("EndRoundBtn", nameof(Button.onClick))]
    private Action OnEndRoundButton;

    private Text roundTitleText;
    public Transform ItemRoot {get; private set;}

    public override void OnDisplay(object args) {
        ItemRoot = Get<GridLayoutGroup>("ItemRoot").transform;
        roundTitleText = Get<Text>("RoundText");
        OnEndRoundButton = EndRoundAction;
    }

    /// <summary>
    /// 从骰子列表中移除
    /// </summary>
    public void RemoveItem(GameObject item) {
        ObjectPool.Recycle(item);
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
