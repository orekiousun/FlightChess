using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QxFramework.Core;
using System;
using NameList;

public class SelectItemUI : UIBase {
    [ChildValueBind("ItemBtn1", nameof(Button.onClick))]
    Action OnItemButton1;

    [ChildValueBind("ItemBtn2", nameof(Button.onClick))]
    Action OnItemButton2;

    [ChildValueBind("ItemBtn3", nameof(Button.onClick))]
    Action OnItemButton3;

    [ChildValueBind("ItemBtn4", nameof(Button.onClick))]
    Action OnItemButton4;

    [ChildValueBind("ItemBtn5", nameof(Button.onClick))]
    Action OnItemButton5;

    [ChildValueBind("ItemBtn6", nameof(Button.onClick))]
    Action OnItemButton6;

    public override void OnDisplay(object args) {
        OnItemButton1 = ItemAction1;
        OnItemButton2 = ItemAction2;
        OnItemButton3 = ItemAction3;
        OnItemButton4 = ItemAction4;
        OnItemButton5 = ItemAction5;
        OnItemButton6 = ItemAction6;
    }

    private void ItemAction1() {
        if(GameMgr.ItemMgr.UseItem(1)) {
            GameMgr.CharacterMgr.ChangePlayerStep(1);
            UIManager.Instance.Close(this);
        }
            
    }

    private void ItemAction2() {
        if(GameMgr.ItemMgr.UseItem(2)) {
            GameMgr.CharacterMgr.ChangePlayerStep(2);
            UIManager.Instance.Close(this);
        }
    }

    private void ItemAction3() {
        if(GameMgr.ItemMgr.UseItem(3)) {
            UIManager.Instance.Close(this);
            GameMgr.CharacterMgr.ChangePlayerStep(3);
        }
    }

    private void ItemAction4() {
        if(GameMgr.ItemMgr.UseItem(4)) {
            UIManager.Instance.Close(this);
            GameMgr.CharacterMgr.ChangePlayerStep(4);
        }
            
    }

    private void ItemAction5() {
        if(GameMgr.ItemMgr.UseItem(5)) {
            UIManager.Instance.Close(this);
            GameMgr.CharacterMgr.ChangePlayerStep(5);
        }
    }

    private void ItemAction6() {
        if(GameMgr.ItemMgr.UseItem(6)) {
            UIManager.Instance.Close(this);
            GameMgr.CharacterMgr.ChangePlayerStep(6);
        }
    }
}