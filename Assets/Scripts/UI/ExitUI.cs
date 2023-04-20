using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using QxFramework.Core;
using System;

public class ExitUI : UIBase {
    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    [ChildValueBind("CancelBtn", nameof(Button.onClick))]
    Action OnCancelButton;

    public override void OnDisplay(object args) {
        OnExitButton = ExitAction;
        OnCancelButton = CancelAction;
    }

    private void ExitAction() {
        ProcedureManager.Instance.ChangeTo<SelectProcedure>();
    }

    private void CancelAction() {
        UIManager.Instance.Close(this);
    }
}