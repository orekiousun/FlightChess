using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;
using System;
using NameList;

public class TitleUI : UIBase {
    [ChildValueBind("EnterBtn", nameof(Button.onClick))]
    Action OnEnterButton;

    [ChildValueBind("SelectBtn", nameof(Button.onClick))]
    Action OnSelectButton;

    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    public override void OnDisplay(object args) {
        OnEnterButton = EnterAction;
        OnSelectButton = SelectAction;
        OnExitButton = ExitAction;
        // CommitValue();
    }

    private void EnterAction() {
        ProcedureManager.Instance.ChangeTo<GameProcedure>(args: "Scene1");
    }

    private void SelectAction() {
        ProcedureManager.Instance.ChangeTo<SelectProcedure>();
    }

    private void ExitAction() {
        
    }

}
