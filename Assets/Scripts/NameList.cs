using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NameList {
    public enum UI {
        TipUI = 0,      // 用于开启一段提示
        StatusUI = 1,   // 用于保存玩家的点数，减法器以及当前回合数
        TitleUI = 2,
        SelectUI = 3,
        EndGameUI = 4,
        ExitUI = 5,
    }

    public enum BlockType {
        Normal = 0,
        Jump = 1,
        Fly = 2,
        Freeze = 3,
        Fire = 4,
        Bonus = 5,
        DirectionChange = 6,
    }
}
