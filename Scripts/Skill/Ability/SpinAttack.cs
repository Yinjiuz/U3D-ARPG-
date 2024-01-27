using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class SpinAttack : Ability
    {
        private float damage=10;
        void Start()
        {
            sname = "SpinAttack";
            targetType = TargetType.Enemy;
        }

        protected override void Handleuse()
        {
            stats.ModifyATB(-stats.filledAtbValue);
            //Debug.Log(playerAttack.targetIndex);
            playerAttack.targetIndex = playerAttack.targets.IndexOf(target);
            //Debug.Log(playerAttack.targetIndex);

            playerAttack. MoveTowardsTarget(target);
            animatorHandler.PlayTargetAnimation("SpinAttack", true);
            Vector3 targetPosition = playerAttack.GetFrontPosition();
            vFXAndLightsManager.PlayVFX(vFXAndLightsManager.abilityVFX, targetPosition, true);
            vFXAndLightsManager.LightColor(vFXAndLightsManager.groundLight, vFXAndLightsManager.abilityColot, .3f, targetPosition);
        }

        public override void HandleEffect()
        {
            
            Vector3 targetPosition = playerAttack. GetFrontPosition();
            vFXAndLightsManager.LightColor(vFXAndLightsManager.swordLight, vFXAndLightsManager.sparkColor, .1f, targetPosition);
            Hurt hurt = target.GetComponent<Hurt>();
            hurt.GetHurt(damage);
        }


    }

}
