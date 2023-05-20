using System.Resources;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public interface ICharacterManager {
    PlayerBase Player{get;}
    BlockBase CurrentBlock{get;set;}

    /// <summary>
    /// 改变玩家当前剩余的步数
    /// </summary>
    void ChangePlayerStep(int step);

    /// <summary>
    /// 改变玩家是前进还是后退
    /// </summary>
    void ChangePlayerDirection(BlockDirection direction);

    /// <summary>
    /// 改变玩家的旋转
    /// </summary>
    void ChangePlayerRotation(float rotation);

    /// <summary>
    /// 改变玩家的位置 -- 即进行移动
    /// </summary>
    void ChangePlayerPosition(Vector2 targetPos);
}
