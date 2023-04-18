using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using NameList;

public class ItemManager : LogicModuleBase, IItemManager {
    private Dictionary<int, int> items = new Dictionary<int, int>();   // 保存已有的骰子数量

    private StatusUI statusUI;

    public void AddItem(int index) {
        items[index]++;
    }

    public bool UseItem(int index) {
        // 判断当前的数量是否大于0，如果大于0就使用，否则报错
        if(items[index] <= 0) {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "个数不足");
            return false;
        }
        items[index]--;
        UpdateStatusUI();
        return true;
    }

    public bool MinusItem(int left, int right) {
        // 如果减数大于被减数，减法失败
        if(left < right) {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "减数不能大于被减数");
            return false;
        }
        bool leftUse = UseItem(left);
        bool rightUse = UseItem(right);
        // 减法成功
        if(leftUse && rightUse) {
            AddItem(left - right);
            UpdateStatusUI();   // 成功之后更新UI界面
            return true;
        }
        // 减法失败，回退，不更新UI
        else {
            if(!leftUse) AddItem(left);
            if(!rightUse) AddItem(right);
            return false;
        }
    }

    private bool UpdateStatusUI() {
        if(statusUI == null) return false;
        statusUI.UpdateItemTexts(items);
        return true;
    }

#region Unity Callback

    public override void Awake() {
        
    }

    public override void Init() {
        for (int i = 1; i <= 6; i++) {
            items.Add(i, 0);
        }
        MessageManager.Instance.Get<SceneMessage>().RegisterHandler(SceneMessage.NewSceneLoaded, (sender, args) => {
            // 新场景加载时，初始化所有的骰子数量为0
            for (int i = 1; i <= 6; i++) {
                items[i] = 0;
            }
            // 打开StatusUI并更新UI中骰子数量
            statusUI = (StatusUI)(UIManager.Instance.Open(NameList.UI.StatusUI.ToString()));
            UpdateStatusUI();

            // 更新UI中标题的样式
            string roundTitle = GameMgr.SceneMgr.CurrentScene + " " + "Round " + GameMgr.RoundMgr.RoundCount.ToString();
            statusUI.UpdateTitleText(roundTitle);
        });
    }

    public override void Update() {
        
    }

    public override void FixedUpdate() {
        
    }

    public override void OnDestroy() {
        
    }

#endregion

}
