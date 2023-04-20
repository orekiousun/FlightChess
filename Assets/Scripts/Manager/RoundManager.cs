using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class RoundManager : LogicModuleBase, IRoundManager {
    public int RoundCount { get; private set; }
    private RoundBase currentRound;
    private RoundType defaultRoundType;
    public RoundType CurrentRoundType {get; set;}
    public RoundType NextRoundType {get; set;}

    // 存储所有的回合类型，需要的时候直接取出来调用即可
    private Dictionary<RoundType, RoundBase> roundDic = new Dictionary<RoundType, RoundBase>();

    public void BeginRound() {
        RoundCount = 1;
        currentRound = roundDic[defaultRoundType];
        CurrentRoundType = defaultRoundType;
        currentRound.OnEnterRound(RoundCount);
    }

    public void EndRound() {
        RoundCount = 0;
        currentRound = null;
    }

    /// <summary>
    /// 将所有的回合类型保存到字典中
    /// </summary>
    private void InitRoundDic() {
        roundDic.Add(RoundType.Normal, new Round_Normal());
    }

    public void ChangeRound(RoundType newRoundType) {
        // Debug.Log("Change Round");
        // 退出上一回合
        currentRound.OnExitRound();
        // 开启新的回合
        currentRound = roundDic[newRoundType];
        CurrentRoundType = newRoundType;
        RoundCount += 1;
        currentRound.OnEnterRound(RoundCount);
        GameMgr.ItemMgr.UpdateStatusTitle(RoundCount);
    }


#region Unity Callback

    public override void Init() {
        defaultRoundType = RoundType.Normal;
        // 将所有的回合类型保存到字典中
        InitRoundDic();
    }

    public override void Update(float deltaTime) {
        if(currentRound != null)
            currentRound.OnUpdateRound(deltaTime);
    }

#endregion
}
