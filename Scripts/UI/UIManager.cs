using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

using UnityEngine.EventSystems;

namespace MyGame
{
    public class UIManager : MonoBehaviour
    {

        private GameManager gameManager;
        private CharacterSwitch characterSwitch;
       
        
        public Image test;
        public CanvasGroup tacticalCanvas;
        public CanvasGroup attackCanvas;

        public Transform options;

        public RectTransform targetHealthBlock;
        public RectTransform targetBlock;
        public Slider targetHealthSlider;
        public RectTransform[] CharStatsBlocks;
        public Slider[] healthSliders;
        public Slider[] atbSliders;
        public Image[] atbCompleteLefts;
        public Image[] atbCompleteRights;

        public float duration = 0.5f; 

        public bool canSlider=true;

        private bool lastAim;


        void Start()
        {
            gameManager = GetComponent<GameManager>();
            characterSwitch = GetComponent<CharacterSwitch>();

            InitializeCharStatsBlock();
        }


        public void ShowTacticalMenu(bool on)
        {
            tacticalCanvas.DOFade(on ? 1 : 0, .15f).SetUpdate(true);
            tacticalCanvas.interactable = on;
            attackCanvas.DOFade(on ? 0 : 1, .15f).SetUpdate(true);
            attackCanvas.interactable = !on;
        }

        private void InitializeCharStatsBlock()
        {
            for (int i = 0; i < CharStatsBlocks.Length; i++)
            {
                if (gameManager.players.Length - 1 >= i)
                {
                    CharStatsBlocks[i].gameObject.SetActive(true);
                    CharStatsBlocks[i].GetComponentInChildren<TextMeshProUGUI>().text = gameManager.players[i].playerName;
                    healthSliders[i].DOValue(1, .15f);
                    atbSliders[i].DOValue(0, .15f);
                }
                else
                {
                    CharStatsBlocks[i].gameObject.SetActive(false);
                }

            }
        }

       

        
            public void UpdateOptions(string[] optionName)
        {
            for (int i = 0; i < options.childCount; i++)
            {
                if (optionName.Length - 1 >= i)
                {
                    options.GetChild(i).GetComponent<CanvasGroup>().DOFade(1,0.15f).SetUpdate(true);
                    
                    options.GetChild(i).GetComponentInChildren<TextMeshProUGUI>().text = optionName[i];
                }
                else
                {
                    options.GetChild(i).GetComponent<CanvasGroup>().DOFade(0, 0.15f).SetUpdate(true);
                }
                options.GetChild(i).GetComponent<Button>().enabled = true;


            }

            options.GetChild(0).GetComponent<Button>().enabled = false;
        }

        public void UpdateSelected(int selectedOptionsNum)
        {
            for (int i = 0; i < options.childCount; i++)
            {
                options.GetChild(i).GetComponent<Button>().enabled = true;
            }
            options.GetChild(selectedOptionsNum).GetComponent<Button>().enabled = false;
        }

        public void SlideUp()
        {
            Vector2 firstPosition = CharStatsBlocks[characterSwitch.characterOrder[0]].anchoredPosition;
            for (int i = 0; i < gameManager.players.Length - 1; i++)
            {
                Vector2 targetPosition = CharStatsBlocks[characterSwitch.characterOrder[i + 1]].anchoredPosition;
                CharStatsBlocks[characterSwitch.characterOrder[i]].DOAnchorPos(targetPosition, duration).SetUpdate(true);
            }

            // 最下面的UI元素
            int lastIndex = gameManager.players.Length - 1;
            CharStatsBlocks[characterSwitch.characterOrder[lastIndex]].GetComponent<CanvasGroup>().alpha = 0;
            CharStatsBlocks[characterSwitch.characterOrder[lastIndex]].GetComponent<CanvasGroup>().DOFade(1f, duration).SetUpdate(true);
            CharStatsBlocks[characterSwitch.characterOrder[lastIndex]].anchoredPosition = firstPosition;
            StartCoroutine(slider());
        }
        public void SlideDown()
        {
            Vector2 lastPosition = CharStatsBlocks[characterSwitch.characterOrder[gameManager.players.Length - 1]].anchoredPosition;
            for (int i = gameManager.players.Length-1; i>0  ; i--)
            {
                Vector2 targetPosition = CharStatsBlocks[characterSwitch.characterOrder[i -1]].anchoredPosition;
                CharStatsBlocks[characterSwitch.characterOrder[i]].DOAnchorPos(targetPosition, duration).SetUpdate(true);
            }
            CharStatsBlocks[characterSwitch.characterOrder[0]].GetComponent<CanvasGroup>().alpha = 0;
            CharStatsBlocks[characterSwitch.characterOrder[0]].GetComponent<CanvasGroup>().DOFade(1f, duration);
            CharStatsBlocks[characterSwitch.characterOrder[0]].anchoredPosition = lastPosition;
            StartCoroutine(slider());
        }

        public void HandleUpdateUI(float delta)
        {
            for (int i = 0; i < gameManager.players.Length; i++)
            {
                healthSliders[i].DOValue(gameManager.players[i].stats.currentHealth/ gameManager.players[i].stats.maxHealth, .15f);
                atbSliders[i].DOValue(gameManager.players[i].stats.atbSlider, .15f);

            }

            UpdateAttackBlock();



        }

        private void UpdateAttackBlock()
        {
            Transform targetTransform = gameManager.nowPlayer.playerAttack.GetTargetTransform();
            Vector3 targetPosition = gameManager.nowPlayer.playerAttack.GetTargetPosition();

            Vector3 screenPos = Camera.main.WorldToScreenPoint(targetPosition);
            Vector3 screenPos2 = Camera.main.WorldToScreenPoint(2 * targetPosition - targetTransform.position);


            targetHealthBlock.position = new Vector3(screenPos2.x, screenPos2.y, screenPos2.z);
            targetBlock.position = new Vector3(screenPos.x, screenPos.y, screenPos.z);

            EnemyManager targetEnemy = gameManager.nowPlayer.playerAttack.GetTargetTransform().GetComponent<EnemyManager>();

            targetHealthBlock.GetComponentInChildren<TextMeshProUGUI>().text = targetEnemy.playerName;
            targetHealthSlider.maxValue = targetEnemy.Stats.maxHealth;
            targetHealthSlider.DOValue(targetEnemy.Stats.currentHealth, .15f);

        }

        IEnumerator slider()
        {

            canSlider = false;
            yield return new WaitForSeconds(duration);
            canSlider = true;
        }
        
        public void HandleTargetObjectUpdate()
        {
            //if (aimAtTarget)
            //{
            //    aimCanvas.transform.position = Camera.main.WorldToScreenPoint(gameManager.nowPlayer.playerAttack.targets[gameManager.nowPlayer.playerAttack.targetIndex].position + Vector3.up);
            //}
        }



    }

}
