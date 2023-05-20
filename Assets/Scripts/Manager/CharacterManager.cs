using System.Security.Cryptography.X509Certificates;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using QxFramework.Core;
using Cinemachine;
using NameList;

public class CharacterManager : LogicModuleBase, ICharacterManager {
    public PlayerBase Player { get; private set; }
    public BlockBase CurrentBlock { get; set; }

#region Player
    public void ChangePlayerStep(int step) {
        if(Player == null) return;
        Player.StepForward(step);
    }

    public void ChangePlayerDirection(BlockDirection direction) {
        if(Player == null) return;
        Player.SetBlockDirection(direction);
    }

    public void ChangePlayerRotation(float rotation) {
        if(Player == null) return;
        Player.PlayerRotate(rotation);
    }

    public void ChangePlayerPosition(Vector2 targetPos) {
        if(Player == null) return;
        Player.PlayerMove(targetPos);
    }

#endregion

#region Unity Callback
    public override void Init() {
        // 新场景加载时，获取到玩家对象
        MessageManager.Instance.Get<SceneMessage>().RegisterHandler(SceneMessage.NewSceneLoaded, (sender, args) => {
            // 获取到Player对象，如果没有获取到，则生成
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if(player == null) {
                Transform startPos = GameMgr.SceneMgr.CurrentSceneAnchorPoint.transform.Find("StartPos");
                player = ResourceManager.Instance.Instantiate("Prefabs/Character/Player");
                player.transform.position = startPos.position;
                CurrentBlock = startPos.GetComponent<BlockBase>();
            }
            Player = player.GetComponent<PlayerBase>();
            
            // 更新虚拟相机的跟随对象
            CinemachineVirtualCamera virCamera = GameMgr.SceneMgr.CurrentSceneAnchorPoint.transform.Find("CM vcam").GetComponent<CinemachineVirtualCamera>();
            virCamera.Follow = Player.transform;
        });
    }

    public override void Update(float deltaTime) {

    }

#endregion
}
