using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IRoundManager {
    int RoundCount { get;}

    /// <summary>
    /// 切换场景时调用，准备开启第一个回合
    /// </summary>
    void BeginRound();

    /// <summary>
    /// 切换场景时调用，结束当前场景
    /// </summary>
    void EndRound();
}
