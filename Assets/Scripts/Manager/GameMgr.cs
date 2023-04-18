using QxFramework.Utilities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using QxFramework;

/// <summary>
/// 游戏管理器，用于管理之前由MonoSingleton所有逻辑
/// </summary>
public class GameMgr : MonoSingleton<GameMgr> {
    /// <summary>
    /// 所有模块列表
    /// </summary>
    private readonly List<LogicModuleBase> _modules = new List<LogicModuleBase>();

    [SerializeField] private GameSceneManager sceneManager;
    [SerializeField] private CharacterManager characterManager;
    [SerializeField] private EventManager eventManager;
    [SerializeField] private RoundManager roundManager;
    [SerializeField] private ItemManager itemManager;

    public static IGameSceneManager SceneMgr{get; private set;}
    public static ICharacterManager CharacterMgr {get; private set;}
    public static IEventManager EventMgr {get; private set;}
    public static IRoundManager RoundMgr {get; private set;}
    public static IItemManager ItemMgr {get; private set;}

    /// <summary>
    /// 初始化所有模块
    /// </summary>
    public void InitModules() {
        _modules.Clear();
        sceneManager = new GameSceneManager();
        characterManager = new CharacterManager();
        eventManager = new EventManager();
        roundManager = new RoundManager();
        itemManager = new ItemManager();

        SceneMgr = Add<IGameSceneManager>(sceneManager);
        CharacterMgr = Add<ICharacterManager>(characterManager);
        EventMgr = Add<IEventManager>(eventManager);
        RoundMgr = Add<IRoundManager>(roundManager);
        ItemMgr = Add<IItemManager>(itemManager);

        foreach (var module in _modules) {
            module.Awake();
        }
    }

    /// <summary>
    /// 将模块加入_modules模块列表中
    /// </summary>
    private T Add<T>(LogicModuleBase module) {
        _modules.Add(module);
        module.Init();
        return (T)(object)module;
    }

#region Unity Callback

    private void Update() {
        foreach (var module in _modules) {
            module.Update();
        }
    }

    private void FixedUpdate() {
        foreach (var module in _modules) {
            module.FixedUpdate();
        }
    }

    private void OnDestroy() {
        foreach (var module in _modules) {
            module.OnDestroy();
        }
        _modules.Clear();

        sceneManager = null;
        characterManager = null;
        eventManager = null;
        roundManager = null;
        itemManager = null;

        SceneMgr = null;
        CharacterMgr = null;
        EventMgr = null;
        RoundMgr = null;
        ItemMgr = null;
    }

#endregion
}