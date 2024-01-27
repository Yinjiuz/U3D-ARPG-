using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Hurt : MonoBehaviour
    {
        private AnimatorHandler animatorHandler;
        private Stats stats;
       

        private void Start()
        {
            animatorHandler = GetComponent<AnimatorHandler>();
            stats = GetComponent<Stats>();
        }

        public void GetHurt(float damage)
        {
            stats.TakeDamage(damage);
            animatorHandler.PlayTargetAnimation("Hurt", true);
        }
    }
}

