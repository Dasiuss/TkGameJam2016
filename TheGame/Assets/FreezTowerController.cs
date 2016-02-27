using UnityEngine;
using System.Collections;
using System.Collections.Generic;

class FreezTowerController : TowerScript {

    public float slowness;

    override public GameObject getEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        List<GameObject> enemiesInRange = new List<GameObject>();
        
        foreach (GameObject e in enemies)
        {
            if (Vector3.Distance(transform.position, e.transform.position) <= range)
            {
                enemiesInRange.Add(e);
            }
        }
        return enemiesInRange[Random.Range(0,enemiesInRange.Count+1)];
    }


    override public void ShootAt(GameObject target)
    {

        GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(target.transform.position)) as GameObject;
        go.SendMessage("SetDmg", damage);
        go.SendMessage("SetEnemy", target);
        go.SendMessage("SetSlowness", slowness);
    }

}
