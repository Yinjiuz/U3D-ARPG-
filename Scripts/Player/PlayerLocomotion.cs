using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class PlayerLocomotion : MonoBehaviour
    {
        PlayerManager playerManager;
        PlayerAttack playerAttack;
        InputManager inputManager;
        Transform cameraObject;

        private bool lastState;
        private float lastMoveAmount;
        private float nowMoveAmount;
        public float SwitchAim;
        public Vector3 moveDirection;
        public Transform myTransform;
        AnimatorHandler animatorHandler;
        FunctionQueueManager aimQueue;
        public new Rigidbody rigidbody;
        //public GameObject normalCamera;

       

        [Header("Movement Stats")]
        [SerializeField]
        float movementSpeed = 5;

        float movementSpeed2 = 3;
        [SerializeField]
        float rotationSpeed = 10;





        Vector3 normalVector;
        Vector3 targetPosition;


        // Start is called before the first frame update
        void Start()
        {
            aimQueue = FindObjectOfType<FunctionQueueManager>();
            playerManager = GetComponent<PlayerManager>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            inputManager = FindObjectOfType<InputManager>();
            playerAttack = GetComponent<PlayerAttack>();
            cameraObject = Camera.main.transform;
            rigidbody = GetComponent<Rigidbody>();
            myTransform = transform;
            normalVector = Vector3.up;
            //ignoreForGroundCheck = ~(1 << 8 | 1 << 11);
            SwitchAim = 0;
            lastState = playerManager.isAnother;
        }


        public void HandleRotation(float delta)
        {
            if (animatorHandler.canRotate == false)
            {
                return;
            }
            Vector3 targetDir = Vector3.zero;
            float moveOverride = inputManager.moveAmount;
            targetDir = cameraObject.forward * inputManager.vertical;
            targetDir += cameraObject.right * inputManager.horizontal;
            targetDir.Normalize();
            targetDir.y = 0;

            if (targetDir == Vector3.zero)
                targetDir = myTransform.forward;

            float rs = rotationSpeed;

            Quaternion tr = Quaternion.LookRotation(targetDir);
            Quaternion targetRotation = Quaternion.Slerp(myTransform.rotation, tr, rs * delta);

            myTransform.rotation = targetRotation;
        }

        public void HandleMovement(float delta)
        {
            
            moveDirection = cameraObject.forward * inputManager.vertical;
            moveDirection += cameraObject.right * inputManager.horizontal;

            moveDirection.Normalize();
            float speed = movementSpeed;
            if (playerManager.isAnother)
            {
                speed =movementSpeed2;
            }

            

            if (inputManager.sprintFlag && (inputManager.vertical != 0 || inputManager.horizontal != 0))
            {
                playerManager.isSpriting = true;
                if (lastMoveAmount != 2)
                {
                    StartCoroutine(LerpNowMoveAmount(nowMoveAmount, 2, 0.2f));
                    lastMoveAmount=2;
                }
                
            }
            else
            {
                if (lastMoveAmount != inputManager.moveAmount)
                {
                    StartCoroutine(LerpNowMoveAmount(nowMoveAmount, inputManager.moveAmount, 0.2f));
                    lastMoveAmount = inputManager.moveAmount;
                }
            }
            moveDirection *= speed*nowMoveAmount;
            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
            rigidbody.velocity = projectedVelocity;

            if(lastState!= playerManager.isAnother)
            {
                StartCoroutine(LerpSwitchAim(SwitchAim, playerManager.isAnother ? 1.0f : 0.0f, 0.5f));
                lastState = playerManager.isAnother;
            }

            animatorHandler.UpdateAnimatorValues(nowMoveAmount, SwitchAim);
            playerManager.isSpriting = false;
        }

        public void idle()
        {
            rigidbody.velocity= new Vector3(0f, 0f, 0f);
            animatorHandler.UpdateAnimatorValues(0, SwitchAim);
        }


        IEnumerator LerpSwitchAim(float startValue, float endValue, float duration)
        {
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                SwitchAim = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
                yield return null;
                elapsedTime += Time.deltaTime;
            }

            SwitchAim = endValue;
        }

        IEnumerator LerpNowMoveAmount(float startValue, float endValue, float duration)
        {
            float elapsedTime = 0.0f;

            while (elapsedTime < duration)
            {
                nowMoveAmount = Mathf.Lerp(startValue, endValue, elapsedTime / duration);
                yield return null;
                elapsedTime += Time.deltaTime;
            }


            nowMoveAmount = endValue;
        }

        public void HandleRolling(float delta)
        {

            if (inputManager.rollFlag)
            {
                aimQueue.AddFunctionToQueue(Rolling);
            }
        }

        private void Rolling()
        {
            playerAttack.resetAttackCount();
            moveDirection = cameraObject.forward * inputManager.vertical;
            moveDirection += cameraObject.right * inputManager.horizontal;
            if (!playerManager.isAnother)
            {
                animatorHandler.PlayTargetAnimation("Rolling_0", true);
            }
            else
            {
                animatorHandler.PlayTargetAnimation("Rolling_1", true);
            }

            moveDirection.y = 0;
            Quaternion rollRotation = Quaternion.LookRotation(moveDirection);
            myTransform.rotation = rollRotation;

        }


    }


}
