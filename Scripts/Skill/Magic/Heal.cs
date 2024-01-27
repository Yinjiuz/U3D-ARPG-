using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Heal : Magic
    {
        private float healingAmount = 10;
        // Start is called before the first frame update

        void Start()
        {
            sname = "Heal";
            targetType = TargetType.Teammate;
        }

        protected override void Handleuse()
        {
            stats.ModifyATB(-stats.filledAtbValue);
            animatorHandler.PlayTargetAnimation("Heal", true);
        }

        public override void HandleEffect()
        {
            vFXAndLightsManager. PlayVFX(vFXAndLightsManager.healVFX,target.position, false);
            vFXAndLightsManager.LightColor(vFXAndLightsManager.groundLight, vFXAndLightsManager.healColor, .5f,target.position);

            Stats stats = target.GetComponent<Stats>();
            stats.TakeDamage(-healingAmount);
        }
    }

}
