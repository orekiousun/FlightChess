using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;


public class RoundBase {
    public RoundType roundType;
    protected float currentRoundTime = 0f;

    public virtual void OnEnterRound(int roundCount) {
        UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "Round " + roundCount.ToString());
        // 重置回合时间
        currentRoundTime = 0f;
    }

    public virtual void OnUpdateRound(float deltaTime) {

    }

    public virtual void OnExitRound() {
        // UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "Round End");
    }
}
