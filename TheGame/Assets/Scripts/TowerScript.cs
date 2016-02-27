using UnityEngine;
using System.Collections;
using Assets.scripts;
using System;

class TowerScript : Building {

    public float range;
    public float fireRate;
    public int numberOfTargets;
    public float damage;
    public float explosionRadius;
    public GameObject bulletPrefab;

    private bool wave;
    private float lastShot = 0;
    private GameObject spottedEnemy;
    private Transform turretTransform;

	void Start () {
        turretTransform = this.transform;
        wave = false;
	}
	
	// Update is called once per frame
	void Update () {
        GameObject [] enemies = GameObject.FindGameObjectsWithTag ("enemy");
        GameObject nearestEnemy = null;
        float dist = Mathf.Infinity;
        foreach (GameObject e in enemies) {
            float d = Vector3.Distance (this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist) {
                nearestEnemy = e;
                dist = d;
            }
        }

        if (nearestEnemy == null) return;
        if (Vector3.Distance(transform.position, nearestEnemy.transform.position) > range) return;//za daleko

        
        float fireCooldownleft = Time.time - lastShot;
        if (fireCooldownleft >= fireRate) {
            lastShot = Time.time;
            ShootAt (nearestEnemy);
        }
	}


    void ShootAt (GameObject target) {

        GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(target.transform.position)) as GameObject;
        go.SendMessage("SetDmg", damage);
        go.SendMessage("SetEnemy", target);
    }
    

    public override void takeDmg(object dmg)
    {
        this.hp -= (float) dmg;
        if (hp <= 0) Destroy(gameObject);
    }
}
