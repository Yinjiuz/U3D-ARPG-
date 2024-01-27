using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class AI : MonoBehaviour
    {
        public List<Transform> targets;
        public int targetIndex;
        private float targetDistance;

        Locomotion locomotion;
        AnimatorHandler animatorHandler;
        Animator anim;
        public AIType aiType;
        private StateMachine currentState;

        private float detectionRange =1000f;
        private float idleRange = 5f;
        public enum AIType
        {
            Enemy,
            TeamMate
        }
        public enum StateMachine
        {
            idle,
            Chase,
            Patrol,
        }

        

        private void Start()
        {
            locomotion = GetComponent<Locomotion>();
            anim = GetComponentInChildren<Animator>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            currentState = StateMachine.Patrol;
        }

        public void HandleAIUpdate(float delta)
        {
            UpdateState();

            switch (currentState)
            {
                case StateMachine.Chase:
                    locomotion.Chase(delta);
                    break;
                case StateMachine.Patrol:
                    locomotion.Patrol(delta);
                    break;
                case StateMachine.idle:
                    locomotion.Idle(delta);
                    break;

            }
        }

        private void UpdateState()
        {
            if (aiType == AIType.TeamMate)
            {
                currentState = StateMachine.Patrol;
                return;
            }

            FindClosestTransform();
            if (targetDistance > detectionRange)
            {
                currentState = StateMachine.Patrol;
            }
            else if (targetDistance < detectionRange && targetDistance > idleRange)
            {
                currentState = StateMachine.Chase;
            }
            else if(targetDistance< idleRange)
            {
                currentState = StateMachine.idle;
            }
        }

        public void  FindClosestTransform()
        {

            float closestDistance = Mathf.Infinity;
            int closestIndex = -1;

            for (int i = 0; i < targets.Count; i++)
            {
                float distance = Vector3.Distance(transform.position, targets[i].position);

                if (distance < closestDistance)
                {
                    closestDistance = distance;
                    closestIndex = i;
                }
            }

            targetIndex = closestIndex;
            targetDistance = closestDistance;
        }


        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy")&& aiType==AIType.TeamMate|| other.CompareTag("Player") && aiType == AIType.Enemy)
            {
                if (!targets.Contains(other.transform))
                    targets.Add(other.transform);
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Enemy") && aiType == AIType.TeamMate || other.CompareTag("Player") && aiType == AIType.Enemy)
            {
                if (targets.Contains(other.transform))
                    targets.Remove(other.transform);
            }
        }


    }

}
