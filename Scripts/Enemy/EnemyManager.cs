using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class EnemyManager : MonoBehaviour
    {
        public string playerName;
        public Character character;

        public Stats Stats;
        AI ai;

        private void Start()
        {
            Stats = GetComponent<Stats>();
            character = GetComponent<Character>();
            playerName = character.playerName;
            ai = GetComponent<AI>();
        }
        public void HandleAIUpdate(float delta)
        {
            ai.HandleAIUpdate(delta);
        }

    }

}
