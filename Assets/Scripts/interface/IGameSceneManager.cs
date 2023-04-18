using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameSceneManager  {
    
    public GameObject CurrentSceneAnchorPoint { get; }
    string LastScene {get;}
    string CurrentScene {get;}

    /// <summary>
    /// 切换场景 -- 卸载当前场景，加载新场景
    /// </summary>
    void ChangeScene(string newScene);

    /// <summary>
    /// 重载当前场景 -- 用于重新挑战
    /// </summary>
    void ReloadCurrentScene();

    /// <summary>
    /// 只卸载当前场景 -- 用于回到选关界面
    /// </summary>
    void UnloadCurrentScene();
}
