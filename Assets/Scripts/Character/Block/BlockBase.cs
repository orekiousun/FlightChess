using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;
using System;
using Sirenix.OdinInspector;

public class BlockBase : SerializedMonoBehaviour {
    public BlockType type;
    public Dictionary<string, BlockBase> nextBlocks = new Dictionary<string, BlockBase>();

    /// <summary>
    /// 进入Block范围
    /// </summary>
    protected virtual void OnEnterBlock() {
        
    }

    /// <summary>
    /// 退出Block范围
    /// </summary>
    protected virtual void OnExitBlock() {

    }

    protected virtual void ChangeBlock(string blockKey) {
        GameMgr.CharacterMgr.ChangePlayerPosition(nextBlocks[blockKey].transform.position);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        OnEnterBlock();
    }

    private void OnTriggerExit2D(Collider2D other) {
        OnExitBlock();
    }
}
