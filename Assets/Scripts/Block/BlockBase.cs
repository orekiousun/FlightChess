using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;
using System;
using Sirenix.OdinInspector;

public class BlockBase : SerializedMonoBehaviour {
    public BlockType type;
    public Dictionary<NextBlock, BlockBase> nextBlocks = new Dictionary<NextBlock, BlockBase>();
    protected BlockBase nextBlock;

    /// <summary>
    /// 执行进入Block时的操作
    /// </summary>
    public virtual void OnExecuteBlock(int step) {
        if(step == 0) {
            GameMgr.CharacterMgr.Player.StepForward(--step);
            return;
        }
        Debug.Log("进入Block：" + this.name);
        GameMgr.CharacterMgr.Player.PlayerMove(nextBlock.transform.position);      // 移动玩家位置到下一个Block的位置
        GameMgr.CharacterMgr.CurrentBlock = nextBlock.GetComponent<BlockBase>();   // 改变CharacterMgr中的当前Block为下一个Block
        GameMgr.CharacterMgr.Player.StepForward(--step);                             // 继续执行前进逻辑
    }
}
