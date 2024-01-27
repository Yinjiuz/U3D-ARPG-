using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class CharacterSwitch : MonoBehaviour
    {

        
        private InputManager inputManager;
        private GameManager gameManager;
        private UIManager uiManager;
        private CameraManager cameraManager;


        public int nowPlayerNum;
        private int playerNum;

        public int[] characterOrder;
        void Start()
        {
            gameManager = GetComponent<GameManager>();
            inputManager = GetComponent<InputManager>();
            uiManager = GetComponent<UIManager>();
            cameraManager = GetComponent<CameraManager>();

            playerNum = gameManager.players.Length;
            characterOrder = new int[playerNum];
            for (int _ = 0; _ < playerNum; _++)
            {
                characterOrder[_] = _;
            }
            nowPlayerNum = 0;
            Switch();
            UpdateOrder();


        }

        public void HandleCharacterSwitch(float delta)
        {
            if (uiManager.canSlider&&(inputManager.scrollMouseDown || inputManager.scrollMouseUp))
            {

                if (inputManager.scrollMouseDown)
                {
                    nowPlayerNum = (nowPlayerNum + 1) % playerNum;
                    
                    
                    uiManager.SlideDown();
                }

                else if (inputManager.scrollMouseUp)
                {
                    nowPlayerNum = (nowPlayerNum + playerNum - 1) % playerNum;

                    uiManager.SlideUp();
                }
                UpdateOrder();
                Switch();
            }
           
        }

        private void Switch()
        {
            if (gameManager.nowPlayer.playerLocomotion != null)
            {
                gameManager.nowPlayer.playerLocomotion.idle();
            }
            
            gameManager.nowPlayer = gameManager.players[nowPlayerNum];
            cameraManager.setFreeCamera(gameManager.nowPlayer.transform);
        }

        private void UpdateOrder()
        {
            int __ = 0;
            for (int _ = nowPlayerNum; _ < playerNum; _++)
            {
                characterOrder[__++] = _;
            }

            for (int _ = 0; _ < nowPlayerNum; _++)
            {
                characterOrder[__++] = _;
            }
        }
    }
}

