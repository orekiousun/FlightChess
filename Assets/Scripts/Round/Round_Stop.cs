using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;
using QxFramework.Core;

public class Round_Stop : RoundBase {
    private float getItemTime = 2f;
    private bool getItemFlag = false;

    private bool chooseOperationFlag = false;
    private float chooseOperationTime = 4f;

    public override void OnEnterRound(int roundCount) {
        // Debug.Log("Enter Round_Normal " + currentRoundTime.ToString());
        base.OnEnterRound(roundCount);

        roundType = RoundType.Stop;
        // 初始化值
        getItemFlag = false;
        getItemTime = 2f;
        chooseOperationFlag = false;
        chooseOperationTime = 4f;
    }

    public override void OnUpdateRound(float deltaTime) {
        currentRoundTime += deltaTime;
        if(!getItemFlag && currentRoundTime >= getItemTime) {
            GameMgr.ItemMgr.GetItem();
            getItemFlag = true;
        }
        if(!chooseOperationFlag && currentRoundTime >= chooseOperationTime) {
            UIManager.Instance.Open(UI.Round_StopUI.ToString());
            chooseOperationFlag = true;
        }
    }

    public override void OnExitRound() {
        base.OnExitRound();
    }
}

