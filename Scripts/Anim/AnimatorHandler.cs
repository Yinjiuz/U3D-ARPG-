using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class AnimatorHandler : MonoBehaviour
    {
        public PlayerManager playerManager;
        public Animator anim;
        //InputHandler inputHandler;
        PlayerLocomotion playerLocomotion;
        int vertical;
        int horizontal;
        public bool canRotate;

        public void Start()
        {
            playerManager = GetComponentInParent<PlayerManager>();
            anim = GetComponent<Animator>();
            //inputHandler = GetComponentInParent<InputHandler>();
            playerLocomotion = GetComponentInParent<PlayerLocomotion>();
            vertical = Animator.StringToHash("Vertical");
            horizontal = Animator.StringToHash("Horizontal");
            CanRotate();
        }

        public void UpdateAnimatorValues(float verticalMovement, float horizontalMovement)
        {
            anim.SetFloat(vertical, verticalMovement);
            anim.SetFloat(horizontal, horizontalMovement);
        }

        public void PlayTargetAnimation(string targetAnim, bool isInterating)
        {
            anim.applyRootMotion = isInterating;
            anim.SetBool("isInenteracting", isInterating);
            anim.CrossFade(targetAnim, 0.2f);
        }

        public void CanRotate()
        {
            canRotate = true;
        }

        public void StopRotation()
        {
            canRotate = false;
        }

        private void OnAnimatorMove()
        {
            if (playerManager == null||playerManager.isAiming == false)
                return;
            float delta = Time.deltaTime;
            playerLocomotion.rigidbody.drag = 0;
            Vector3 deltaPosition = anim.deltaPosition;
            deltaPosition.y = 0;
            Vector3 velcoity = deltaPosition / delta;
            playerLocomotion.rigidbody.velocity = velcoity;

        }
    }
}

