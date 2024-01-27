using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class BladeBeam : Ability
    {
        private float damage = 10;
        void Start()
        {
            sname = "BladeBeam";
            targetType = TargetType.Enemy;
        }

        protected override void Handleuse()
        {
            stats.ModifyATB(-stats.filledAtbValue);
           
        }

        public override void HandleEffect()
        {
        }
    }
}

