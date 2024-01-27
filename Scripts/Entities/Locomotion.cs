using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

namespace MyGame
{
    public class Locomotion : MonoBehaviour
    {
        public float speed;
        float ChaseSpeed = 2;
        float PatrolSpeed = 4;
        float s = 2;
        float rotationSpeed = 10;

        //public float detectionRange = 10f;

        public Transform player;

        private float patrolTime = 2f;
        private float patrolTimer = 0f;

        private bool isPatrolling=false;

        private float timer = 0;
        private float time = 0.03f;
        public float duration = 1f;
        AnimatorHandler animatorHandler;
        public new Rigidbody rigidbody;
        AI ai;
        Vector3 normalVector;
        private void Start()
        {
            ai = GetComponent<AI>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            rigidbody = GetComponent<Rigidbody>();
            normalVector = Vector3.up;
        }
        public void Chase(float delta)
        {
            transform.DOLookAt(ai.targets[ai.targetIndex].position, .3f).SetUpdate(true);

            if (speed == PatrolSpeed)
            {
                timer = 0;
            }

            if (speed < ChaseSpeed)
            {
                timer += delta;
                if (timer > time)
                {
                    timer -= time;
                    speed++;
                    if(speed>= ChaseSpeed)
                    {
                        speed = ChaseSpeed;
                    }
                }
            }
            else if (speed > ChaseSpeed)
            {
                timer += delta;
                if (timer > time)
                {
                    timer -= time;
                    speed--;
                    if (speed <= ChaseSpeed)
                    {
                        speed = ChaseSpeed;
                    }
                }
            }
            HandleLocomotion();
        }

        public void Patrol(float delta)
        {
            if (!isPatrolling)
            {
                //int randomDirection = Random.Range(0, 2) * 2 - 1; // -1 »ò 1
                //int randomAngle = Random.Range(0,90);

                Vector3 currentRotation = transform.eulerAngles;
                
                Vector3 targetRotation = currentRotation + new Vector3(0f,90f, 0f);

                transform.DORotate(targetRotation, duration);
                isPatrolling = true;
                patrolTimer = 0f;
            }
            patrolTimer += delta;
 
            if (patrolTimer > patrolTime)
            {
                patrolTimer -= patrolTime;
                isPatrolling = false;


            }

            

            if (speed == ChaseSpeed)
            {
                timer = 0;
            }

            if (speed > PatrolSpeed)
            {
                timer += delta;
                if (timer > time)
                {
                    timer -= time;
                    speed--;

                    if (speed<= PatrolSpeed)
                    {
                        speed = PatrolSpeed;
                    }
                }
            }
            else if(speed < PatrolSpeed)
            {
                timer += delta;
                if (timer > time)
                {
                    timer -= time;
                    speed++;

                    if (speed >= PatrolSpeed)
                    {
                        speed = PatrolSpeed;
                    }
                }
            }
            HandleLocomotion();

        }

        public void Idle(float delta)
        {
            speed = 0;
            HandleLocomotion();
        }

        private void HandleLocomotion()
        {
            Vector3 moveDirection = transform.forward*speed;
            Vector3 projectedVelocity = Vector3.ProjectOnPlane(moveDirection, normalVector);
            rigidbody.velocity = projectedVelocity;
            animatorHandler.UpdateAnimatorValues(speed/s, 0);
        }
    }
}

