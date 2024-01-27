using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace MyGame
{
    public class TurnBasedManager : MonoBehaviour
    {

        private UIManager uIManager;
        private TacticalModeManager tacticalModeManager;
        private InputManager inputManager;
        private GameManager gameManager;
        private Slot playerSlot;
        private CameraManager cameraManager;

        private int selectedOptionNum;
        private int maxOptionNum;

        private Transform[] enemyList;
        private Transform[] teammateList; 

        
        private void Start()
        {
            uIManager = GetComponent<UIManager>();
            tacticalModeManager = GetComponent<TacticalModeManager>();
            inputManager = GetComponent<InputManager>();
            gameManager = GetComponent<GameManager>();
            cameraManager = GetComponent<CameraManager>();
        }
        public enum TurnStage
        {
            SelectSkill,
            SelectAbility,
            SelectTarget,
        }

        private enum SkillType
        {
            Magic,
            Ability,
            Item
        }

        public TurnStage nowStage;
        private SkillType selectedSkill;
        private Skill.TargetType targetType;
        private int selecedtAbility;
        private int selectedTarger;

       private void ResetTurnStage()
        {
            nowStage = TurnStage.SelectSkill;
        }

        public void EnterTurnBasedMode()
        {
            playerSlot = gameManager.nowPlayer.GetComponent<Slot>();
            uIManager.ShowTacticalMenu(true);
            ResetTurnStage();
            SkillType[] skills = (SkillType[])Enum.GetValues(typeof(SkillType));
            string[] skillNames = new string[skills.Length];
            for (int i = 0; i < skills.Length; i++)
            {
                skillNames[i] = skills[i].ToString();
            }
            UpdateOptions(skillNames);


        }

        private void SelectSkill()
        {

            nowStage = TurnStage.SelectAbility;
            SkillType[] skills = (SkillType[])Enum.GetValues(typeof(SkillType));
            selectedSkill = skills[selectedOptionNum];
            EnterAbilityStage();
        }

        private void BackAbilityStage()
        {
            nowStage = TurnStage.SelectAbility;
            cameraManager.EnableVirtualCamera();
            EnterAbilityStage();
        }

        private void EnterAbilityStage()
        {
            
            if (selectedSkill == SkillType.Ability)
            {
                string[] names = new string[playerSlot.abiltySlot.Count];
                for (int i = 0; i < playerSlot.abiltySlot.Count; i++)
                {
                    names[i] = playerSlot.abiltySlot[i].sname;
                }
                UpdateOptions(names);
            }
            else if (selectedSkill == SkillType.Magic)
            {

                string[] names = new string[playerSlot.magicSlot.Count];
                for (int i = 0; i < playerSlot.magicSlot.Count; i++)
                {
                    names[i] = playerSlot.magicSlot[i].sname;
                }
                UpdateOptions(names);
            }
            else if (selectedSkill == SkillType.Item)
            {
                string[] names = new string[playerSlot.itemSlot.Count];
                for (int i = 0; i < playerSlot.itemSlot.Count; i++)
                {
                    names[i] = playerSlot.itemSlot[i].sname;
                }
                UpdateOptions(names);
            }
        }

        private void SelectAbility()
        {
            nowStage = TurnStage.SelectTarget;
            selecedtAbility = selectedOptionNum;

            if (selectedSkill == SkillType.Ability)
            {
                targetType = playerSlot.abiltySlot[selectedOptionNum].targetType;
            }
            else if (selectedSkill == SkillType.Magic)
            {
                targetType = playerSlot.magicSlot[selectedOptionNum].targetType;

            }
            else if (selectedSkill == SkillType.Item)
            {
                targetType = playerSlot.itemSlot[selectedOptionNum].targetType;
            }

            if (targetType == Skill.TargetType.Enemy)
            {
                EnemyManager[] enemyManagers = FindObjectsOfType<EnemyManager>();
                enemyList = enemyManagers.Select(obj => obj.transform).ToArray();
                string[] names = new string[enemyManagers.Length];
                for (int i = 0; i < enemyManagers.Length; i++)
                {
                    names[i] = enemyManagers[i].playerName;
                }
                UpdateOptions(names);
            }
            else if(targetType == Skill.TargetType.Teammate)
            {
                PlayerManager[] playerManagers = FindObjectsOfType<PlayerManager>();
                teammateList = playerManagers.Select(obj => obj.transform).ToArray();
                string[] names = new string[playerManagers.Length];
                for (int i = 0; i < playerManagers.Length; i++)
                {
                    names[i] = playerManagers[i].playerName;
                }
                UpdateOptions(names);
            }
            else if (targetType == Skill.TargetType.Self)
            {
                SelectTarget();
                return;
            }
            cameraManager.SetVirtualCamera(getTransform());
        }

        private void SelectTarget()
        {

            if (selectedSkill == SkillType.Ability)
            {
                playerSlot.abiltySlot[selecedtAbility].HandleUse(getTransform());
            }
            else if (selectedSkill == SkillType.Magic)
            {
                playerSlot.magicSlot[selecedtAbility].HandleUse(getTransform());

            }
            else if (selectedSkill == SkillType.Item)
            {
                playerSlot.itemSlot[selecedtAbility].HandleUse(getTransform());
            }
            tacticalModeManager.CancelAction();
        }


       

        public void ExitTurnBasedMode()
        {
            uIManager.ShowTacticalMenu(false);
        }


        public void TurnBasedModeUpdate(float delta)
        {
            if (inputManager.scrollMouseDown || inputManager.scrollMouseUp)
            {
                if (inputManager.scrollMouseDown)
                {
                    selectedOptionNum = (selectedOptionNum + 1) % maxOptionNum;
                }
                else if (inputManager.scrollMouseUp)
                {
                    selectedOptionNum = (selectedOptionNum + maxOptionNum - 1) % maxOptionNum;
                }
                uIManager.UpdateSelected(selectedOptionNum);
                if (nowStage == TurnStage.SelectTarget)
                {

                    
                    cameraManager.SetVirtualCamera(getTransform());
                }

            }
            
            if (inputManager.leftMouse)
            {
                if (nowStage == TurnStage.SelectSkill)
                {
                    SelectSkill();
                }
                else if (nowStage == TurnStage.SelectAbility)
                {
                    
                    SelectAbility();
                }
                else if (nowStage == TurnStage.SelectTarget)
                {
                    SelectTarget();
                }
            }
            else if (inputManager.rightMouse)
            {
                if (nowStage == TurnStage.SelectSkill)
                {
                    tacticalModeManager.CancelAction();
                }
                else if (nowStage == TurnStage.SelectAbility)
                {
                    EnterTurnBasedMode();
                }
                else if (nowStage == TurnStage.SelectTarget)
                {
                    BackAbilityStage();
                }
            }

        }
        private void UpdateOptions(string[] names)
        {
            maxOptionNum = names.Length;
            uIManager.UpdateOptions(names);
            selectedOptionNum = 0;
        }

        private Transform getTransform()
        {
            if (targetType == Skill.TargetType.Enemy)
            {
                return enemyList[selectedOptionNum];
            }
            else if (targetType == Skill.TargetType.Teammate)
            {
                return teammateList[selectedOptionNum];
            }
            else
            {
                return null;
            }

        }


    }

}
