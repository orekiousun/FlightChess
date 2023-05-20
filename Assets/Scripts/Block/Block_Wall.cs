using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class Block_Wall : BlockBase {
    public float backAngle;
    private bool openFlag = false;
    public override void OnExecuteBlock(int step, BlockDirection direction) {
        type = BlockType.Wall;
        if(step == 0) {  // 说明最后一步到达墙体Block
            openFlag = true;
            nextBlock = nextBlocks[NextBlock.Forward];
            base.OnExecuteBlock(step, direction);
        }
        else if(openFlag) {
            openFlag = false;
            nextBlock = nextBlocks[NextBlock.Forward];
            base.OnExecuteBlock(step, direction);
        }
        else {
            nextBlock = nextBlocks[NextBlock.Back];
            GameMgr.CharacterMgr.ChangePlayerDirection(BlockDirection.Back);
            GameMgr.CharacterMgr.ChangePlayerRotation(backAngle);
            GameMgr.CharacterMgr.ChangePlayerStep(--step);
            GameMgr.CharacterMgr.ChangePlayerPosition(nextBlock.transform.position);      // 移动玩家位置到下一个Block的位置
            GameMgr.CharacterMgr.CurrentBlock = nextBlock;                             // 改变CharacterMgr中的当前Block为下一个Block
        }
    }
}
