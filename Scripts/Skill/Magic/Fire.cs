using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Fire : Magic
    {
        private float damage = 10;
        // Start is called before the first frame update

        void Start()
        {
            sname = "Fire";
            targetType = TargetType.Enemy;
        }

        protected override void Handleuse()
        {
            stats.ModifyATB(-stats.filledAtbValue);
            playerAttack.targetIndex = playerAttack.targets.IndexOf(target);
            animatorHandler.PlayTargetAnimation("Fire", true);
            Invoke("Play", 0.75f);
            Invoke("HandleEffect", 0.9f);
            Invoke("Stop", 1.75f);
        }


        private void Play()
        {
            vFXAndLightsManager.PlayParticle(vFXAndLightsManager.fireParticle, target.position);
        }

        private void Stop()
        {
            vFXAndLightsManager.StopParticle(vFXAndLightsManager.fireParticle);
        }
        public override void HandleEffect()
        {
            Hurt hurt = target.GetComponent<Hurt>();
            hurt.GetHurt(damage);
        }
    }

}
