using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NameList;

public class PlayerBase : MonoBehaviour {
    public float blockWidth = 1f;
    private Rigidbody2D rb2D;

    private int stepUpdate;
    private float moveInterval;
    private float moveIterator;

    private void Awake() {
        stepUpdate = -1;
        moveInterval = 0.5f;
        rb2D = GetComponent<Rigidbody2D>();
    }

    public void StepForward(int step) {
        stepUpdate = step;
        // if(step >= 0) {
        //     BlockBase currentBlock = GameMgr.CharacterMgr.CurrentBlock;
        //     currentBlock.OnExecuteBlock(step);
        // }
    }

    public void PlayerMove(Vector2 targetPos) {
        // transform.position = targetPos;
        rb2D.MovePosition(targetPos);
    }

    public void PlayerRotate(float rotateAngle) {
        // transform.eulerAngles += new Vector3(0, 0, rotateAngle);
        rb2D.MoveRotation(rotateAngle);
    }

    private void Update() {
        if(stepUpdate >= 0 && moveIterator > moveInterval) {
            moveIterator = 0;
            BlockBase currentBlock = GameMgr.CharacterMgr.CurrentBlock;
            currentBlock.OnExecuteBlock(stepUpdate);
        }
        // else if (stepUpdate < 0) {
        //     moveIterator = 0;
        // }
        else {
            moveIterator += Time.deltaTime;
        }
    }
}
