using UnityEngine;
using System.Collections;

namespace Assets.scripts
{
    public class MsgDispatcher
    {
        Building castle;

        public void damageCastle(float dmg)
        {
            castle.takeDmg(dmg);
        }
    }
}