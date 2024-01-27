using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Cloud1 : Character
    {

        private void Start()
        {
            playerName = "Cloud1";
        }

        public override void HandleUpdate(float delta)
        {
            HandleSwitchState(delta);
        }

        private void HandleSwitchState(float delta)
        {
            if (inputManager.ButtonE)
            {

                playerManager.isAnother = !playerManager.isAnother;
            }
        }
    }

}

