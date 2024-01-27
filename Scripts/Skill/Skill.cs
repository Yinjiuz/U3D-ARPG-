using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Skill : MonoBehaviour
    {
        public string sname;
        protected PlayerManager playerManager;
        protected PlayerAttack playerAttack;
        protected AnimatorHandler animatorHandler;
        protected Stats stats;
       protected Transform target;
        protected VFXAndLightsManager vFXAndLightsManager;

        FunctionQueueManager functionQueueManager;

        

        public enum TargetType
        {
            Enemy,
            Teammate,
            Self
        }

        public TargetType targetType;


        private void Awake()
        {
            functionQueueManager = FindObjectOfType<FunctionQueueManager>();
            playerManager = GetComponent<PlayerManager>();
            playerAttack = GetComponent<PlayerAttack>();
            stats = GetComponent<Stats>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            vFXAndLightsManager = FindObjectOfType<VFXAndLightsManager>();

        }

        protected virtual void Handleuse()
        {

        }

        public virtual void HandleEffect()
        {

        }

        public void HandleUse(Transform t)
        {
            target = t;
            functionQueueManager.AddFunctionToQueue(Handleuse);
        }
    }

}