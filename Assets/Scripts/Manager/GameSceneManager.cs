using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using UnityEngine.SceneManagement;
using Cinemachine;

public enum SceneMessage {
    WillUnload,
    NewSceneLoaded,
}

public class GameSceneManager : LogicModuleBase, IGameSceneManager {
    private string lastScene;
    public string LastScene => lastScene;

    private string currentScene;
    public string CurrentScene => currentScene;

    private string nullScene = "NullScene";

    public GameObject CurrentSceneAnchorPoint {get; private set;}

    public void ChangeScene(string newScene) {
        // 卸载当前场景
        SceneUnload();
        lastScene = currentScene;
        if(currentScene != nullScene)
            SceneManager.UnloadSceneAsync(LastScene);

        // 加载新场景
        currentScene = newScene;
        SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
        // SceneLoaded();
    }

    public void ReloadCurrentScene() {
        // 卸载当前场景
        SceneUnload();
        lastScene = currentScene;
        if(currentScene != nullScene)
            SceneManager.UnloadSceneAsync(currentScene);
        
        // 重新加载当前场景
        SceneManager.LoadScene(currentScene, LoadSceneMode.Additive);
        // SceneLoaded();
    }

    public void UnloadCurrentScene() {
        // 卸载当前场景，并把当前场景置空
        SceneUnload();
        if(currentScene != nullScene)
            SceneManager.UnloadSceneAsync(LastScene);
        currentScene = nullScene;
    }

    /// <summary>
    /// 卸载场景时调用
    /// </summary>
    private void SceneUnload() {
        MessageManager.Instance.Get<SceneMessage>().DispatchMessage(SceneMessage.WillUnload, this);
    }

    /// <summary>
    /// 加载场景时调用，需要等待场景加载完之后调用
    /// </summary>
    private void SceneLoaded(Scene scene, LoadSceneMode mode) {
        CurrentSceneAnchorPoint = GameObject.FindGameObjectWithTag("SceneAnchorPoint");
        MessageManager.Instance.Get<SceneMessage>().DispatchMessage(SceneMessage.NewSceneLoaded, this);
    }

#region Unity Callback

    public override void Init() {
        currentScene = nullScene;
        SceneManager.sceneLoaded += SceneLoaded;
    }

    public override void Update(float deltaTime) {
        
    }

#endregion
}
