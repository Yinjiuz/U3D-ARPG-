using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.VFX;
using Cinemachine;
using UnityEngine.Rendering;
using DG.Tweening;

namespace MyGame
{


    public class GameManager : MonoBehaviour
    {
        public PlayerManager[] players;
        public  PlayerManager nowPlayer;
        public EnemyManager[] enemyManagers;
        private InputManager inputManager;
        private CameraManager cameraManager;
        private TacticalModeManager tacticalModeManager;
        private FunctionQueueManager aimQueue;
        private TurnBasedManager turnBasedManager;
        private CharacterSwitch characterSwitch;
        private UIManager uIManager;

        private void Awake()
        {
            inputManager= GetComponent<InputManager>();
            players = FindObjectsOfType<PlayerManager>();
            enemyManagers = FindObjectsOfType<EnemyManager>();
            cameraManager = GetComponent<CameraManager>();
            tacticalModeManager = GetComponent<TacticalModeManager>();
            aimQueue = GetComponent<FunctionQueueManager>();
            turnBasedManager = GetComponent<TurnBasedManager>();
            characterSwitch = GetComponent<CharacterSwitch>();
            uIManager = GetComponent<UIManager>();
            foreach (PlayerManager player in players)
            {

                if (player.playerName == "Cloud")
                {
                    nowPlayer = player;
                }
            }
        }
        private void Update()
        {
            float delta = Time.deltaTime;
            inputManager.TickInput(delta);
            tacticalModeManager.HandleSwitchMode();

            foreach (EnemyManager enemyManager in enemyManagers)
            {
                enemyManager.HandleAIUpdate(delta);
            }
            //foreach (PlayerManager player in players)
            //{
            //    if (player != nowPlayer)
            //    {
            //        player.HandleAIUpdate(delta);
            //    }
            //}
            if (!tacticalModeManager.tacticalMode)
            {
                characterSwitch.HandleCharacterSwitch(delta);
                nowPlayer.playerUpdate(delta);
                
            }
            else
            {
                turnBasedManager.TurnBasedModeUpdate(delta);
            }

            if (!nowPlayer.isAiming)
            {
                aimQueue.ExecuteNextFunction();
            }

            uIManager.HandleUpdateUI(delta);
        }    
    }

}
