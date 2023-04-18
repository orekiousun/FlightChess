using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QxFramework.Core;
using System;

public class ExitUI : UIBase {
    [ChildValueBind("CancelBtn", nameof(Button.onClick))]
    Action OnCancelButton;

    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    public override void OnDisplay(object args) {
        OnCancelButton += CancelAction;
        OnExitButton += ExitAction;
    }

    private void CancelAction() {
        UIManager.Instance.Close(this);
    }

    private void ExitAction() {
        ProcedureManager.Instance.ChangeTo<SelectProcedure>();
    }
}