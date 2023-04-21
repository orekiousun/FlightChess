using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NameList {
    public enum UI {
        TipUI = 0,             // 用于开启一段提示
        TitleUI = 1,           // 进入游戏的
        SelectUI = 2,          // 选择关卡
        EndGameUI = 3,         // 退出游戏

        // 关卡内
        StatusUI = 4,          // 用于保存玩家的点数，减法器以及当前回合数
        ExitUI = 5,            // 场景内返回到关卡选择界面
        Round_NormalUI = 6,    // 普通回合
        SelectItemUI = 7,      // 选择使用哪个骰子的界面
        MinusItemUI = 8,       // 对骰子进行减法
    }

    public enum BlockType {
        Normal = 0,
        Rotate = 6,
        Jump = 1,
        Freeze = 2,
        Fire = 3,
        Bonus = 4,
        DirectionChange = 5,

    }

    public enum RoundType {
        Normal = 1,    // 正常回合
        Stop = 2,      // 强制停留一回合
        ForWard = 3,   // 强制前进一回合
    }

    public enum NextBlock {
        NormalTarget = 0,
        JumpTarget = 1,
    }
}
