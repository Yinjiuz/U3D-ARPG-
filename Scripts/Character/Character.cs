using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Character : MonoBehaviour
    {
        public string playerName;
        protected InputManager inputManager;
        protected PlayerManager playerManager;

        private void Awake()
        {
            inputManager = FindObjectOfType<InputManager>();
            playerManager = GetComponent<PlayerManager>();
        }

        public virtual void HandleUpdate(float delta)
        {

        }
    }

}
