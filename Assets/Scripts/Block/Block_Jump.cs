using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public class Block_Jump : BlockBase {
    public float jumpRotateAngle;
    public override void OnExecuteBlock(int step) {
        type = BlockType.Jump;
        if(step == 0) {   // 说明最后一步到达跳跃Block
            Debug.Log("执行跳跃逻辑");
            nextBlock = nextBlocks[NameList.NextBlock.JumpTarget];
            GameMgr.CharacterMgr.Player.StepForward(--step);
            GameMgr.CharacterMgr.Player.PlayerRotate(jumpRotateAngle);
            GameMgr.CharacterMgr.Player.PlayerMove(nextBlock.transform.position);      // 移动玩家位置到下一个Block的位置
            GameMgr.CharacterMgr.CurrentBlock = nextBlock.GetComponent<BlockBase>();   // 改变CharacterMgr中的当前Block为下一个Block
        }
        else {
            nextBlock = nextBlocks[NameList.NextBlock.NormalTarget];
            base.OnExecuteBlock(step);
        }
    }
}
