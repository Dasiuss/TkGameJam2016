using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;


namespace Assets.scripts
{
    class Castle : Building
    {
        public override void takeDmg(object dmg)
        {
            Debug.Log("dmg!"+(float)dmg);
            this.hp -= (float) dmg;
            if (hp < 1) Destroy(gameObject);
            Debug.Log("hp: " + hp);
        }
    }
}
