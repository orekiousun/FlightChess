using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QxFramework.Core;
using System;
using NameList;

public class MinusItemUI : UIBase {
    [ChildValueBind("ItemBtn1", nameof(Button.onClick))] Action OnItemButton1;

    [ChildValueBind("ItemBtn2", nameof(Button.onClick))] Action OnItemButton2;

    [ChildValueBind("ItemBtn3", nameof(Button.onClick))] Action OnItemButton3;

    [ChildValueBind("ItemBtn4", nameof(Button.onClick))] Action OnItemButton4;

    [ChildValueBind("ItemBtn5", nameof(Button.onClick))] Action OnItemButton5;

    [ChildValueBind("ItemBtn6", nameof(Button.onClick))] Action OnItemButton6;

    [ChildValueBind("MinusBtn", nameof(Button.onClick))] Action OnMinusButton;

    [ChildValueBind("ClearBtn", nameof(Button.onClick))] Action OnClearButton;

    private Text num1;
    private int numInt1;
    private Text num2;
    private int numInt2;
    private int numsCount = 0;

    public override void OnDisplay(object args) {
        OnItemButton1 = ItemAction1;
        OnItemButton2 = ItemAction2;
        OnItemButton3 = ItemAction3;
        OnItemButton4 = ItemAction4;
        OnItemButton5 = ItemAction5;
        OnItemButton6 = ItemAction6;
        OnMinusButton = MinusAction;
        OnClearButton = ClearAction;
        num1 = Get<Text>("Num1");
        numInt1 = 0;
        num2 = Get<Text>("Num2");
        numInt2 = 0;
        numsCount = 0;
    }

    private void ItemAction1() {
        if(numsCount == 0) {
            num1.text = "1";
            numInt1 = 1;
            numsCount++;
        }
        else if(numsCount == 1) {
            num2.text = "1";
            numInt2 = 1;
            numsCount++;
        }
        else {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args:"无效操作");
        }
    }

    private void ItemAction2() {
        if(numsCount == 0) {
            num1.text = "2";
            numInt1 = 2;
            numsCount++;
        }
        else if(numsCount == 1) {
            num2.text = "2";
            numInt2 = 2;
            numsCount++;
        }
        else {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args:"无效操作");
        }
    }

    private void ItemAction3() {
        if(numsCount == 0) {
            num1.text = "3";
            numInt1 = 3;
            numsCount++;
        }
        else if(numsCount == 1) {
            num2.text = "3";
            numInt2 = 3;
            numsCount++;
        }
        else {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args:"无效操作");
        }
    }

    private void ItemAction4() {
        if(numsCount == 0) {
            num1.text = "4";
            numInt1 = 4;
            numsCount++;
        }
        else if(numsCount == 1) {
            num2.text = "4";
            numInt2 = 4;
            numsCount++;
        }
        else {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args:"无效操作");
        }
    }

    private void ItemAction5() {
        if(numsCount == 0) {
            num1.text = "5";
            numInt1 = 5;
            numsCount++;
        }
        else if(numsCount == 1) {
            num2.text = "5";
            numInt2 = 5;
            numsCount++;
        }
        else {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args:"无效操作");
        }
    }

    private void ItemAction6() {
        if(numsCount == 0) {
            num1.text = "6";
            numInt1 = 6;
            numsCount++;
        }
        else if(numsCount == 1) {
            num2.text = "6";
            numInt2 = 6;
            numsCount++;
        }
        else {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args:"无效操作");
        }
    }

    private void MinusAction() {
        if(numsCount < 2) {   // 如果填入的数字个数不足，触发提示
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "减数数量不足");
            return;
        }
        if(GameMgr.ItemMgr.MinusItem(numInt1, numInt2)) {   // 如果减法执行成功，更新文本值，设置当前回合不能继续减法
            UIManager.Instance.Close(this);
        }
        // 无论减法是否执行成功，都清空输入栏
        OnClearButton();

    }

    private void ClearAction() {
        num1.text = "0";
        num2.text = "0";
        numsCount = 0;
    }
}
