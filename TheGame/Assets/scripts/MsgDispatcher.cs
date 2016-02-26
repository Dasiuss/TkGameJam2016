using UnityEngine;
using System.Collections;

namespace Assets.scripts
{
    class MsgDispatcher
    {
       public Building castle;

        public void setCastle(Building castle)
        {
            this.castle = castle;
        }

        public void damageCastle(float dmg)
        {
            castle.takeDmg(dmg);
        }
    }
}