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
        GameObject go;

        public override void destroy()
        {
            go.SetActive(false);
        }
    }
}
