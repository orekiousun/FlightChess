using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public class Block_Rotate  : BlockBase {
    public float backAngle;
    public override void OnExecuteBlock(int step, BlockDirection direction) {
        type = BlockType.Rotate;
        nextBlock = direction == BlockDirection.Forward ? nextBlocks[NextBlock.Forward] : nextBlocks[NextBlock.Back];
        if(direction == BlockDirection.Forward)
            GameMgr.CharacterMgr.ChangePlayerRotation(forwardAngle);
        else
            GameMgr.CharacterMgr.ChangePlayerRotation(backAngle);
        base.OnExecuteBlock(step, direction);
    }
}
