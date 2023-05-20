using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class Block_Normal : BlockBase {
    public override void OnExecuteBlock(int step, BlockDirection direction) {
        type = BlockType.Normal;
        nextBlock = direction == BlockDirection.Forward ? nextBlocks[NextBlock.Forward] : nextBlocks[NextBlock.Back];
        base.OnExecuteBlock(step, direction);
    }
}
