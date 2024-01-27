using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

namespace MyGame
{
    public class CameraManager : MonoBehaviour
    {
        [Header("Cameras")]
        public GameObject gameCam;
        public CinemachineFreeLook freeLookCamera;
        public CinemachineVirtualCamera targetCam;
        public CinemachineImpulseSource camImpulseSource;
        public GameManager gameManager;
        public void SetAimCamera(bool on)
        {
            //if (gameManager.nowPlayer.playerAttack.targets.Count < 1)
            //    return;

            targetCam.LookAt = on ? gameManager.nowPlayer.playerAttack.aimObject : null;
            targetCam.Follow = on ? gameManager.nowPlayer.playerAttack.aimObject : null;
            targetCam.gameObject.SetActive(on);
            targetCam.enabled =false;
            gameManager.nowPlayer.isAiming = on;
        }

        public void setFreeCamera(Transform target)
        {
            freeLookCamera.LookAt = target;
            freeLookCamera.Follow = target;

        }
        public void SetVirtualCamera(Transform target)
        {
            targetCam.enabled = true;
            Transform childTransform = FindChildTransform(target, "opposite");
            targetCam.LookAt = childTransform;
            targetCam.Follow = childTransform;
        }

        public void EnableVirtualCamera()
        {
            targetCam.enabled = false;

        }

        Transform FindChildTransform(Transform parent, string childName)
        {
            foreach (Transform child in parent)
            {
                if (child.name == childName)
                {
                    return child; 
                }
            }
            return null;
        }

        void Start()
        {
            gameManager = GetComponent<GameManager>();
            camImpulseSource = Camera.main.GetComponent<CinemachineImpulseSource>();
        }


    }
}

