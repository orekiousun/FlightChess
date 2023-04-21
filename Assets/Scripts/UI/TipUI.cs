using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;

public class TipUI : UIBase {
    private float lastTime;
    public override void OnDisplay(object args) {
        Get<Text>("Text").text = (string)args;
        lastTime = 1.2f;
    }

    public void SetTime(float time) {
        lastTime = time;
    }

    public override void OnUpdate() {
        if (lastTime > 0) {
            lastTime -= Time.deltaTime;
            if(lastTime <= 0) {
                UIManager.Instance.Close(this);
            }
        }
    }

    protected override void OnClose() {
        base.OnClose();
        UIManager.Instance.Close(this);
    }
}
