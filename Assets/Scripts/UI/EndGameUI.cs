using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.UI;

public class EndGameUI : UIBase {
    [ChildValueBind("CancelBtn", nameof(Button.onClick))]
    Action OnCancelButton;

    [ChildValueBind("ExitBtn", nameof(Button.onClick))]
    Action OnExitButton;

    public override void OnDisplay(object args) {
        OnCancelButton = CancelAction;
        OnExitButton = ExitAction;
    }

    private void CancelAction() {
        ProcedureManager.Instance.ChangeTo<TitleProcedure>();
    }

    private void ExitAction() {
        Application.Quit();
    }
}
