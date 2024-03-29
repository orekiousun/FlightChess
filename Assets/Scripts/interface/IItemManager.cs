using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItemManager {
    StatusUI statusUI{get;}

    /// <summary>
    /// 添加骰子
    /// </summary>
    void AddItem(int index);

    /// <summary>
    /// 使用(减少)骰子
    /// </summary>
    bool UseItem(int index);

    /// <summary>
    /// 对两个骰子进行减法，获取新的骰子
    /// </summary>
    bool MinusItem(int left, int right);

    /// <summary>
    /// 每回合的抽卡，随机获取一个骰子
    /// </summary>
    void GetItem();

    /// <summary>
    /// 更新StatusUI中的标题
    /// </summary>
    public void UpdateStatusTitle(int roundCount);
}
