using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public interface IRoundManager {
    int RoundCount { get;}

    RoundType CurrentRoundType {get;}
    RoundType NextRoundType {get;}

    /// <summary>
    /// 切换场景时调用，准备开启第一个回合
    /// </summary>
    void BeginRound();

    /// <summary>
    /// 切换场景时调用，结束当前场景，结束所有回合
    /// </summary>
    void EndRound();

    /// <summary>
    /// 改变回合
    /// </summary>
    void ChangeRound();
}
