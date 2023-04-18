using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class RoundManager : LogicModuleBase, IRoundManager {
    public int RoundCount { get; private set; }

    public void BeginRound() {
        RoundCount = 0;
    }

    public void EndRound() {
        RoundCount = 0;
    }

    /// <summary>
    /// 开始新的回合时调用
    /// </summary>
    void OnEnterRound() {
        RoundCount++;
        // UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "Round " + RoundCount.ToString());
    }

    /// <summary>
    /// 退出回合时调用
    /// </summary>
    void OnExitRound() {

    }

#region Unity Callback

    public override void Awake() {

    }

    public override void Init() {
        
    }

    public override void Update() {
        
    }

    public override void FixedUpdate() {
        
    }

    public override void OnDestroy() {
        
    }

#endregion
}
