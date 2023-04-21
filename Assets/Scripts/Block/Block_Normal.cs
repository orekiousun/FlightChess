using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class Block_Normal : BlockBase {
    public override void OnExecuteBlock(int step) {
        nextBlock = nextBlocks[NameList.NextBlock.NormalTarget];
        base.OnExecuteBlock(step);
    }
}
