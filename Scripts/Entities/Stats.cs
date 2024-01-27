using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Stats : MonoBehaviour
    {
        public int heathLeavel = 10;
        public int maxHealth;
        public int currentHealth;

        public float atbSlider;
        public float filledAtbValue = 100;
        public float atbAttack = 10;        //攻击恢复能量的多少

        AnimatorHandler animatorHandler;

        private float interval = 0.1f;

        public bool canSwitchMode = false;

        //public HeathBar heathBar;
        //AnimatorHandler animatorHandler;

        private void Start()
        {
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            maxHealth = SetMaxHealthFromHealthLeavel();
            currentHealth = maxHealth;

            atbSlider = 0;

            StartCoroutine(AtbIncrement());
        }

        private int SetMaxHealthFromHealthLeavel()
        {
            maxHealth = heathLeavel * 10;
            return maxHealth;
        }

        public void TakeDamage(float damage)
        {
            currentHealth -= Mathf.RoundToInt(damage);
            if (currentHealth <= 0)
            {
                currentHealth = 0;
                animatorHandler.PlayTargetAnimation("Dead", true);
            }
        }

        public void ModifyATB(float amount)
        {
            atbSlider += amount;
            atbSlider = Mathf.Clamp(atbSlider, 0, (filledAtbValue * 2));
        }

        public void ClearATB()
        {
            atbSlider = 0;
        }

        IEnumerator AtbIncrement()
        {
            while (true)
            {
                yield return new WaitForSeconds(interval);
                ModifyATB(1);
                if (atbSlider >= filledAtbValue)
                {
                    canSwitchMode = true;
                }
                else
                {
                    canSwitchMode = false;
                }
            }
        }
    }

}