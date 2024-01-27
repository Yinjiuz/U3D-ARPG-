using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGame
{
    public class Ice : Magic
    {
        private float healingAmount = 10;
        // Start is called before the first frame update

        void Start()
        {
            sname = "Ice";
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
