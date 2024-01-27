using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class PlayerManager : MonoBehaviour
    {

        public string playerName ;
        public Character character;
        InputManager inputManager;
        //CameraHandler cameraHandler;
        Animator anim;
        AnimatorHandler animatorHandler;
        public PlayerLocomotion playerLocomotion;
        AI ai;
        public Stats stats;
        public FunctionQueueManager functionQueueManager;
        public PlayerAttack playerAttack;
        

        public bool isAiming;
        public bool usingAbility;
        public bool isSpriting;
        public bool isAnother;

       

        private void Start()
        {
            
            isAiming = false;
            usingAbility = false;
            isSpriting = false;
            isAnother = false;
            inputManager = FindObjectOfType< InputManager> ();
            anim = GetComponentInChildren<Animator>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            playerAttack = GetComponent<PlayerAttack>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            stats= GetComponent<Stats>();
            character = GetComponent<Character>();
            ai = GetComponent<AI>();
            playerName = character.playerName;
        }

        private void Update()
        {

        }



        private void FixedUpdate()
        {
            //float delta = Time.fixedDeltaTime;

            //if (cameraHandler != null)
            //{
            //    cameraHandler.FollowTarget(delta);
            //    //cameraHandler.HandleCameraRotation(delta, mouseX, mouseY);

            //}
        }

        private void LateUpdate()
        {
            //isInteracting = anim.GetBool("isInenteracting");
            ////isSpriting = inputHandler.b_input;

            //if (isInair)
            //{
            //    playerLocomotion.inAirTimer = playerLocomotion.inAirTimer + Time.deltaTime;
            //}

        }

        public void playerUpdate(float delta)
        {
            isAiming=  anim.GetBool("isInenteracting");
            character.HandleUpdate(delta);


            if (!isAiming)
            {
                playerLocomotion.HandleMovement(delta);
                playerLocomotion.HandleRotation(delta);
            }
            
            playerLocomotion.HandleRolling(delta);
            playerAttack.HandleReset(delta);
            playerAttack.HandleSelectTarget(delta);
            playerAttack.HandleAttack(delta);
            //playerAttack.HandleAtbIncrement(delta);

            //playerLocomotion.HandleFalling(delta);
        }

        
        IEnumerator AbilityCooldown()
        {
            usingAbility = true;
            yield return new WaitForSeconds(2f);
            usingAbility = false;
        }

        public void HandleAIUpdate(float delta)
        {
            ai.HandleAIUpdate(delta);
        }
    }
}