using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class Block_Forward : BlockBase {
    public override void OnExecuteBlock(int step) {
        type = BlockType.Forward;
        nextBlock = nextBlocks[NameList.NextBlock.NormalTarget];
        base.OnExecuteBlock(step);
    }
}
