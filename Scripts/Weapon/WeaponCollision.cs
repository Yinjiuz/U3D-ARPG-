using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


namespace MyGame
{
    public class WeaponCollision : MonoBehaviour
    {
        private Collider damageCollider;
        private PlayerAttack playerAttack;

        private VFXAndLightsManager vfxAndLightsManager;
        private void Awake()
        {
            playerAttack = GetComponentInParent<PlayerAttack>();
            damageCollider = GetComponent<Collider>();
            vfxAndLightsManager = FindObjectOfType<VFXAndLightsManager>();


            damageCollider.gameObject.SetActive(true);
            damageCollider.isTrigger = true;

        }

        public void EnableDAmageCollider()
        {
            damageCollider.enabled = true;
        }

        public void DisableDAmageCollider()
        {
            damageCollider.enabled = false;
        }

        private void OnTriggerEnter(Collider other)
        {
            //if (other.CompareTag("Enemy"))
            //{
            //    if (playerAttack.canDamage)
            //    {
            //        Vector3 targetPosition = playerAttack.GetFrontPosition();
            //        vfxAndLightsManager.PlayVFX(vfxAndLightsManager.sparkVFX, targetPosition, true);
            //        vfxAndLightsManager.LightColor(vfxAndLightsManager.swordLight, vfxAndLightsManager.sparkColor, .1f, targetPosition);

            //        Hurt hurt = other.GetComponent<Hurt>();
            //        hurt.GetHurt(playerAttack.damage);
            //        playerAttack.canDamage = false;
            //        playerAttack.ModifyATB(playerAttack.atbAttack);

            //    }

            //}
        }
    }
}

