using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public class Block_Jump : BlockBase {
    public float jumpRotateAngle;
    public override void OnExecuteBlock(int step, BlockDirection direction) {
        type = BlockType.Jump;
        if(step == 0) {   // 说明最后一步到达跳跃Block
            Debug.Log("执行跳跃逻辑");
            nextBlock = nextBlocks[NameList.NextBlock.Jump];
            GameMgr.CharacterMgr.ChangePlayerStep(--step);
            GameMgr.CharacterMgr.ChangePlayerRotation(jumpRotateAngle);
            GameMgr.CharacterMgr.ChangePlayerPosition(nextBlock.transform.position);      // 移动玩家位置到下一个Block的位置
            GameMgr.CharacterMgr.ChangePlayerDirection(BlockDirection.Forward);
            GameMgr.CharacterMgr.CurrentBlock = nextBlock;   // 改变CharacterMgr中的当前Block为下一个Block
        }
        else {
            nextBlock = direction == BlockDirection.Forward ? nextBlocks[NextBlock.Forward] : nextBlocks[NextBlock.Back];
            base.OnExecuteBlock(step, direction);
        }
    }
}
