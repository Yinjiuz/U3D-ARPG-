using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

namespace MyGame
{
    public class TacticalModeManager : MonoBehaviour
    {
        public bool tacticalMode;
        public float slowMotionTime = .005f;
        public Volume slowMotionVolume;
        private GameManager gameManager;
        private CameraManager cameraManager;
        private InputManager inputManager;
        private TurnBasedManager turnBasedManager;
        void Start()
        {
            gameManager = GetComponent<GameManager>();
            cameraManager = GetComponent<CameraManager>();
            inputManager = GetComponent<InputManager>();
            turnBasedManager = GetComponent<TurnBasedManager>();
        }

        public void HandleSwitchMode()
        {
            if(inputManager.ButtonSpace)
            {
                if (gameManager.nowPlayer.stats.canSwitchMode&& !tacticalMode)
                {
                    BeginAction();
                }
                else
                {
                    CancelAction();
                }
                
            }
        }

        public void BeginAction()
        {
            cameraManager.SetAimCamera(true);
            SetTacticalMode(true);
        }

        public void CancelAction()
        {
            cameraManager.SetAimCamera(false);
            SetTacticalMode(false);
        }

        public void SetTacticalMode(bool on)
        {
            //movement.desiredRotationSpeed = on ? 0 : .3f;
            //movement.active = !on;

            tacticalMode = on;
            //movement.enabled = !on;

            if (!on)
            {
                cameraManager.SetAimCamera(false);
            }

            cameraManager.camImpulseSource.m_ImpulseDefinition.m_AmplitudeGain = on ? 0 : 2;

            float time = on ? slowMotionTime : 1;
            Time.timeScale = time;

            //Polish
            DOVirtual.Float(on ? 0 : 1, on ? 1 : 0, .3f, SlowmotionPostProcessing).SetUpdate(true);
            if (on)
            {
                turnBasedManager.EnterTurnBasedMode();
            }
            else
            {
                turnBasedManager.ExitTurnBasedMode();
            }
            
        }

        public void SlowmotionPostProcessing(float x)
        {
            slowMotionVolume.weight = x;
        }
    }

}
