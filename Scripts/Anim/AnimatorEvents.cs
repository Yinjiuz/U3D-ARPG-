using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class AnimatorEvents : MonoBehaviour
    {
        private PlayerAttack playerAttack;
        private Heal heal;
        private SpinAttack spinAttack;
        private HealthPotion healthPotion;

        private void Start()
        {
            playerAttack = GetComponentInParent<PlayerAttack>();
            heal = GetComponentInParent<Heal>();
            spinAttack = GetComponentInParent<SpinAttack>();
            healthPotion = GetComponentInParent<HealthPotion>();
        }


        public void AttackEvents()
        {
            playerAttack.AttackHit();
        }

        public void HealEvents()
        {
            heal.HandleEffect();
        }


        public void SpinAttackEvents()
        {
            spinAttack.HandleEffect();
        }

        public void HealthPotionEvents()
        {
            healthPotion.HandleEffect();
        }
    }

}
