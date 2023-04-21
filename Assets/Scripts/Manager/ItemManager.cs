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
        Debug.Log("Add Item: " + index.ToString());
        UpdateStatusUI();
    }

    public bool UseItem(int index) {
        // 判断当前的数量是否大于0，如果大于0就使用，否则报错
        if(items[index] <= 0) {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "个数不足");
            return false;
        }
        items[index]--;
        Debug.Log("Use Item: " + index.ToString());
        UpdateStatusUI();
        return true;
    }

    public bool MinusItem(int left, int right) {
        // 如果减数大于被减数，减法失败
        if(left <= right) {
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "减数不能大于等于被减数");
            return false;
        }
        if(items[left] > 0 && items[right] > 0) {   // 减法成功
            UseItem(left);
            UseItem(right);
            AddItem(left - right);
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "减法成功，获得新的骰子：" + (left - right).ToString());
            // 不需再次更新UI界面，前面已经更新过了
            return true;
        }
        else {                                      // 减法失败
            UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "减法失败，骰子不足");
            return false;
        }
    }

    public void GetItem() {
        int num = Random.Range(1, 7);
        UIManager.Instance.Open(NameList.UI.TipUI.ToString(), args: "获取到新的骰子：" + num.ToString());
        AddItem(num);
    }

    public bool UpdateStatusUI() {
        if(statusUI == null) return false;
        statusUI.UpdateItemTexts(items);
        Debug.Log("更新骰子数为：" + items[1].ToString() + " " + items[2].ToString() + " " + items[3].ToString() + " "
                                + items[4].ToString() + " " + items[5].ToString() + " " + items[6].ToString());
        return true;
    }

    public void UpdateStatusTitle(int roundCount) {
        if(statusUI == null) return;
        string roundTitle = GameMgr.SceneMgr.CurrentScene + " " + "Round " + roundCount.ToString();
        statusUI.UpdateTitleText(roundTitle);
    }

#region Unity Callback

    public override void Init() {
        for (int i = 1; i <= 6; i++) {
            items.Add(i, 0);
        }


        // 旧场景卸载时，关闭所有回合
        MessageManager.Instance.Get<SceneMessage>().RegisterHandler(SceneMessage.WillUnload, (sender, args) => {
            GameMgr.RoundMgr.EndRound();
        });

        MessageManager.Instance.Get<SceneMessage>().RegisterHandler(SceneMessage.NewSceneLoaded, (sender, args) => {
            // 新场景加载时，初始化所有的骰子数量为0
            for (int i = 1; i <= 6; i++) {
                items[i] = 0;
            }

            // 新场景开启时，开始第一个回合
            GameMgr.RoundMgr.BeginRound();

            // 打开StatusUI并更新UI中骰子数量
            statusUI = (StatusUI)(UIManager.Instance.Open(NameList.UI.StatusUI.ToString()));
            UpdateStatusUI();
            UpdateStatusTitle(GameMgr.RoundMgr.RoundCount);
        });
    }

    public override void Update(float deltaTime) {
        
    }

#endregion

}
