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
        GameObject gc;
        MusicManagerCtrl mm;
        void Start () {
            gc = GameObject.FindWithTag ("GameController");
            mm = gc.GetComponentInChildren<MusicManagerCtrl> ();
        }

        public override void takeDmg(object dmg)
        {
            this.hp -= (float) dmg;
            if (hp < 1) {
                gc.SendMessage ("EndGame");
                mm.SendMessage ("PlayDestroy");
                Destroy (gameObject);
            }
            Debug.Log("hp: " + hp);
        }
    }
}
