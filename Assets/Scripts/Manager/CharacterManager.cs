using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using Cinemachine;

public class CharacterManager : LogicModuleBase, ICharacterManager {
    public PlayerBase Player{ get; private set; }

    private void ChangePlayerCameraConfiner() {

    }

    public void ChangePlayerPosition(Vector2 newPosition) {
        Player.transform.position = newPosition;
    }

#region Unity Callback

    public override void Awake() {
        
    }

    public override void Init() {
        // 新场景加载时，获取到玩家对象
        MessageManager.Instance.Get<SceneMessage>().RegisterHandler(SceneMessage.NewSceneLoaded, (sender, args) => {
            // 获取到Player对象，如果没有获取到，则生成
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player == null) {
                Transform startPos = GameMgr.SceneMgr.CurrentSceneAnchorPoint.transform.Find("StartPos");
                player = ResourceManager.Instance.Instantiate("Prefabs/Character/Player", startPos);
            }
            Player = player.GetComponent<PlayerBase>();
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
