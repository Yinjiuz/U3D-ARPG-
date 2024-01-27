using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Cinemachine;

namespace MyGame
{
    public class PlayerAttack : MonoBehaviour
    {
        



        public List<Transform> targets;
        public int targetIndex;
        public Transform aimObject;

        public float rotationDuration=0.15f;
        public Collider objCollider;

        private float attackInputTimer ;
        GameManager gameManager;
        InputManager inputManager;
        CameraManager cameraManager;
        FunctionQueueManager aimQueue;
        AnimatorHandler animatorHandler;
        PlayerLocomotion playerLocomotion;
        PlayerManager playerManager;
        VFXAndLightsManager vfxAndLightsManager;
        Stats stats;

        public Collider swordCollider;

        private int attackCount;
        private bool attackMode;


        private float timer = 0f;
        

        public float damage=10;
        public bool canDamage=false;

        

        // Start is called before the first frame update
        void Start()
        {

            gameManager = FindObjectOfType<GameManager>();
            inputManager = FindObjectOfType<InputManager>();
            cameraManager = FindObjectOfType<CameraManager>();
            aimQueue = FindObjectOfType<FunctionQueueManager>();
            animatorHandler = GetComponentInChildren<AnimatorHandler>();
            playerLocomotion = GetComponent<PlayerLocomotion>();
            stats = GetComponent<Stats>();
            playerManager = GetComponent<PlayerManager>();
            Collider[] colliders = GetComponentsInChildren<Collider>();
            foreach (Collider collider in colliders)
            {
                if (collider.gameObject != gameObject)
                {
                    swordCollider = collider;
                    break;
                }
            }

            //swordCollider.enabled = false;
            vfxAndLightsManager = FindObjectOfType<VFXAndLightsManager>();
            attackCount = 0;
            attackInputTimer = 0f;
            attackMode = playerManager.isAnother;
        }

        public void HandleAttack(float delta)
        {
            if (inputManager.leftMouse)
            {

                aimQueue.AddFunctionToQueue(Attack);
            }

            else if(attackCount != 0)
            {
                attackInputTimer += delta;
                if (attackCount > 3f)
                {
                    resetAttackCount();
                }
            }
        }

        private void Attack()
        {
            playerLocomotion.idle();
            SelectTarget(NearestTargetToCenter());
            aimObject.DOLookAt(targets[targetIndex].position, .3f).SetUpdate(true);
            attackInputTimer = 0;
            canDamage = true;
            //Debug.Log(attackMode);
            int mode=attackMode ? 1 : 0;
            animatorHandler.PlayTargetAnimation($"Attack_{mode}{attackCount}", true);
            attackCount++;
            if (attackCount == 4)
            {
                attackCount = 0;
            }

        }


        public void AttackHit()
        {
            Collider[] hitTargets = Physics.OverlapBox(swordCollider.bounds.center, swordCollider.bounds.extents, swordCollider.transform.rotation);
            //Debug.Log(swordCollider.transform.rotation);
            //Debug.Log(hitTargets.Length);
            foreach (Collider target in hitTargets)
            {
                //Debug.Log(target.tag);
                if (GetComponent<Collider>() is CapsuleCollider&&target.CompareTag("Enemy"))
                {
                    //Debug.Log("daw");
                    Vector3 targetPosition = GetFrontPosition();
                    vfxAndLightsManager.PlayVFX(vfxAndLightsManager.sparkVFX, targetPosition, true);
                    vfxAndLightsManager.LightColor(vfxAndLightsManager.swordLight, vfxAndLightsManager.sparkColor, .1f, targetPosition);

                    Hurt hurt = target.GetComponent<Hurt>();
                    damage = 10;
                    hurt.GetHurt(damage);
                    stats.ModifyATB(stats.atbAttack);
                }
            }
        }


        public void resetAttackCount()
        {
            attackCount = 0;
        }

        public void HandleReset(float delta)
        {
            //if (!targets.Contains(aimObject))
            //{
            //    aimObject = null;
            //}
            if (attackMode != playerManager.isAnother)
            {
                attackMode = playerManager.isAnother;
                resetAttackCount();
            }
        }

        public void MoveTowardsTarget(Transform target)
        {
            if (Vector3.Distance(transform.position, target.position) > 1 && Vector3.Distance(transform.position, target.position) < 10)
            {
                transform.DOMove(TargetOffset(), .5f);
                transform.DOLookAt(targets[targetIndex].position, .2f);
            }
        }

        public Vector3 TargetOffset()
        {
            Vector3 position;
            position = targets[targetIndex].position;
            return Vector3.MoveTowards(position, transform.position, 1.2f);
        }


       

        public void HandleSelectTarget(float delta)
        {
            //if (inputManager.middleMouse != false)
            //{
            //    Debug.Log(inputManager.middleMouse);
            //}
            
            if (inputManager.middleMouse)
            {
                SelectTarget(NearestTargetToCenter());
                StartCoroutine(RotateTowardsEnemyAndPlayer(rotationDuration));
            }
            
        }

        private void SelectTarget(int index)
        {
            targetIndex = index;
            
        }

        private IEnumerator RotateTowardsEnemyAndPlayer(float duration)
        {
            objCollider = targets[targetIndex].GetComponent<Collider>();

            float objectWidth = targets[targetIndex].localScale.x * GetObjectSizeInDirection(Vector3.right, objCollider);
            float objectHeight = targets[targetIndex].localScale.y * GetObjectSizeInDirection(Vector3.up, objCollider);

            Vector3 targetPosition = targets[targetIndex].position;

            //Debug.Log(objectHeight );
            //Debug.Log(targetPosition.y);
            targetPosition.y -= objectHeight/50;
            targetPosition.x += objectWidth / 50;
            //Debug.Log(targetPosition.y);
            Vector3 directionToEnemy = (targetPosition - aimObject.position).normalized;
            Quaternion lookRotationToEnemy = Quaternion.LookRotation(directionToEnemy, Vector3.up);
            

            float elapsedTime = 0f;
            Vector2 startRotation = new Vector2(cameraManager.freeLookCamera.m_XAxis.Value, cameraManager.freeLookCamera.m_YAxis.Value);

            while (elapsedTime < duration)
            {
                float t = elapsedTime / duration;
                Vector2 targetRotation = new Vector2(
                    Mathf.LerpAngle(startRotation.x, lookRotationToEnemy.eulerAngles.y, t),
                    Mathf.LerpAngle(startRotation.y, lookRotationToEnemy.eulerAngles.x, t)
                );

                float rotationSpeedX = Mathf.Abs((targetRotation.x - cameraManager.freeLookCamera.m_XAxis.Value) / (duration - elapsedTime));
                float rotationSpeedY = Mathf.Abs((targetRotation.y - cameraManager.freeLookCamera.m_YAxis.Value) / (duration - elapsedTime));

                cameraManager.freeLookCamera.m_XAxis.Value = Mathf.MoveTowards(cameraManager.freeLookCamera.m_XAxis.Value, targetRotation.x, Time.deltaTime * rotationSpeedX);
                cameraManager.freeLookCamera.m_YAxis.Value = Mathf.MoveTowards(cameraManager.freeLookCamera.m_YAxis.Value, targetRotation.y, Time.deltaTime * rotationSpeedY);

                elapsedTime += Time.deltaTime;
                yield return null;
            }
        }

        float GetObjectSizeInDirection(Vector3 direction, Collider objectCollider )
        {

            if (objectCollider != null)
            {
                return Vector3.Dot(objectCollider.bounds.size, direction);
            }
            else
            {
                Renderer objectRenderer = GetComponent<Renderer>();
                if (objectRenderer != null)
                {
                    return Vector3.Dot(objectRenderer.bounds.size, direction);
                }
                else
                {
                    return 1.0f;
                }
            }
        }

        private int NearestTargetToCenter()
        {
            float[] distances = new float[targets.Count];

            for (int i = 0; i < targets.Count; i++)
            {
                distances[i] = Vector2.Distance(Camera.main.WorldToScreenPoint(targets[i].position), new Vector2(Screen.width / 2, Screen.height / 2));
            }

            float minDistance = Mathf.Min(distances);
            int index = 0;

            for (int i = 0; i < distances.Length; i++)
            {
                if (minDistance == distances[i])
                    index = i;
            }
            return index;
        }




       

        public Transform GetTargetTransform()
        {
            return targets[targetIndex];
        }

        public Vector3 GetTargetPosition()
        {
            Transform targetTransform = targets[targetIndex];
            Collider objCollider = targetTransform.GetComponent<Collider>();
            float objectHeight = targetTransform.localScale.y * GetObjectSizeInDirection(Vector3.up, objCollider);
            //float objectWidth = targetTransform.localScale.x * GetObjectSizeInDirection(Vector3.right, objCollider);
            
            //float objectLength= targetTransform.localScale.z * GetObjectSizeInDirection(Vector3.forward, objCollider);
            Vector3 targetPosition = targetTransform.position;
            targetPosition.y += objectHeight / 2;
            //targetPosition.x += objectWidth / 2;
            //targetPosition.z += objectLength / 2;
            return targetPosition;

        }

        public Vector3 GetFrontPosition()
        {
            Transform transform = GetComponent<Transform>();
            Vector3 position = transform.position;
            Vector3 offset = new Vector3(0, 1.2f, 1.2f);
            offset.x *= transform.forward.x;
            offset.z *= transform.forward.z;
            Vector3 targetPosition = position + offset;
            return targetPosition;
        } 
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Enemy"))
            {
                if (!targets.Contains(other.transform))
                    targets.Add(other.transform);
            }
        }

        //private void OnTriggerExit(Collider other)
        //{
        //    if (other.CompareTag("Enemy"))
        //    {
        //        if (targets.Contains(other.transform))
        //            targets.Remove(other.transform);
        //    }
        //}

    }

}
