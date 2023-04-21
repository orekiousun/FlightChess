using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public class PlayerBase : MonoBehaviour {
    public float blockWidth = 1f;
    private Rigidbody2D rb2D;

    private void Awake() {
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void StepForward(int step) {
        if(step >= 0) {
            BlockBase currentBlock = GameMgr.CharacterMgr.CurrentBlock;
            currentBlock.OnExecuteBlock(step);
        }
    }

    public void PlayerMove(Vector2 targetPos) {
        // transform.position = targetPos;
        rb2D.MovePosition(targetPos);
    }

    public void PlayerRotate(float rotateAngle) {
        // transform.eulerAngles += new Vector3(0, 0, rotateAngle);
        rb2D.MoveRotation(rotateAngle);
    }
}
