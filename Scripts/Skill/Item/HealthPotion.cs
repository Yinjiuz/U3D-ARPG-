using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace MyGame
{
    public class HealthPotion : Item
    {
        private float healingAmount = 10;
        // Start is called before the first frame update
        void Start()
        {
            sname = "Health Potion";
            targetType = TargetType.Self;
        }

        // Update is called once per frame

        protected override void Handleuse()
        {
            stats.ModifyATB(-stats.filledAtbValue);
            animatorHandler.PlayTargetAnimation("HealthPotion", true);
        }

        public override void HandleEffect()
        {
            vFXAndLightsManager.PlayVFX(vFXAndLightsManager.healVFX, playerAttack. transform.position, false);
            vFXAndLightsManager.LightColor(vFXAndLightsManager.groundLight, vFXAndLightsManager.healColor, .5f, playerAttack.transform.position);

            Stats stats = playerAttack.GetComponent<Stats>();
            stats.TakeDamage(-healingAmount);
        }
    }

}
