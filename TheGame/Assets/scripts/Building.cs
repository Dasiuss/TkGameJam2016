using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using System.Collections;


namespace Assets.scripts
{
    abstract class Building : MonoBehaviour
    {
        public float hp;

        public abstract void takeDmg(object dmg);


    }
}
