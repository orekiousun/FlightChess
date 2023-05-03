using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public class Block_Rotate  : BlockBase {
    public float rotateAngle;
    public override void OnExecuteBlock(int step) {
        type = BlockType.Rotate;
        nextBlock = nextBlocks[NameList.NextBlock.NormalTarget];
        GameMgr.CharacterMgr.Player.PlayerRotate(rotateAngle);
        base.OnExecuteBlock(step);
    }
}
