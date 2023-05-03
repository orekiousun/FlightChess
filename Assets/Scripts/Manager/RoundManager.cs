using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class RoundManager : LogicModuleBase, IRoundManager {
    public int RoundCount { get; private set; }
    private RoundBase currentRound;
    private RoundType defaultRoundType;
    public RoundType CurrentRoundType {get; private set;}
    public RoundType NextRoundType {get; private set;}
    private RoundType lastRoundType;

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
        roundDic.Add(RoundType.Stop, new Round_Stop());
        roundDic.Add(RoundType.Forward, new Round_Forward());
    }

    public void ChangeRound() {
        // 检测当前处于的的Block类型，从而获取到下一个Round的类型
        RoundType nextRoundType = RoundType.Normal;
        switch (GameMgr.CharacterMgr.CurrentBlock.type) {
            case BlockType.Stop:
                nextRoundType = RoundType.Stop;
                break;
            case BlockType.Forward:
                nextRoundType = RoundType.Forward;
                break;
            default:
                nextRoundType = RoundType.Normal;
                break;
        }
        lastRoundType = CurrentRoundType;
        if(lastRoundType == nextRoundType) {
            nextRoundType = RoundType.Normal;
        }
        NextRoundType = nextRoundType;

        // Debug.Log("Change Round");
        // 退出上一回合
        currentRound.OnExitRound();
        // 开启新的回合
        currentRound = roundDic[NextRoundType];
        CurrentRoundType = NextRoundType;
        RoundCount += 1;
        currentRound.OnEnterRound(RoundCount);
        // 更新标题
        GameMgr.ItemMgr.UpdateStatusTitle(RoundCount);
    }


#region Unity Callback

    public override void Init() {
        defaultRoundType = RoundType.Normal;
        CurrentRoundType = RoundType.Normal;
        lastRoundType = RoundType.Normal;
        // 将所有的回合类型保存到字典中
        InitRoundDic();
    }

    public override void Update(float deltaTime) {
        if(currentRound != null)
            currentRound.OnUpdateRound(deltaTime);
    }

#endregion
}
