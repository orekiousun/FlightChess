using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;

public class StatusUI : UIBase {
    private Dictionary<int, Text> texts = new Dictionary<int, Text>();
    private Text roundTitleText;

    public override void OnDisplay(object args) {
        for (int i = 1; i <= 6; i++) {
            texts.Add(i, Get<Text>("Count1"));
            texts[i].text = "0";
        }
        roundTitleText = Get<Text>("RoundText");
    }

    /// <summary>
    /// 更新UI中各个骰子的值，以及标题的值
    /// </summary>
    public void UpdateItemTexts(Dictionary<int, int> items) {
        for (int i = 1; i <= 6; i++) {
            texts[i].text = items[i].ToString();
        }
    }

    public void UpdateTitleText(string roundTitle) {
        roundTitleText.text = roundTitle;
    }

}
