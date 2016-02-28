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
    public int cost;

    private bool wave;
    private float lastShot = 0;
    private GameObject spottedEnemy;
    private Transform turretTransform;
    private Vector3 originalScale;

    private bool movable;
    private float actualDistance;

    void Start () {
        turretTransform = this.transform;
        wave = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (movable)
        {
            transform.position = new Vector3(Input.mousePosition.x / 5 - Screen.width / 10, 0, Input.mousePosition.y / 5 - Screen.height / 10);
            UnityEngine.Cursor.visible = false;
            if (Input.GetButton("Fire1"))
            {
                UnityEngine.Cursor.visible = true;
                movable = false;
                transform.localScale = originalScale;
            }
        }
        GameObject nearestEnemy = getEnemy();

        if (nearestEnemy == null) return;
        
        float fireCooldownleft = Time.time - lastShot;
        if (fireCooldownleft >= fireRate) {
            lastShot = Time.time;
            ShootAt (nearestEnemy);
        }
	}

    virtual public GameObject getEnemy()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("enemy");
        GameObject nearestEnemy = null;
        float dist = Mathf.Infinity;
        foreach (GameObject e in enemies)
        {
            if (Vector3.Distance(transform.position, e.transform.position) > range) continue;
            float d = Vector3.Distance(this.transform.position, e.transform.position);
            if (nearestEnemy == null || d < dist)
            {
                nearestEnemy = e;
                dist = d;
            }
        }
        return nearestEnemy;
    }

    virtual public void ShootAt(GameObject target) {

        GameObject go = Instantiate(bulletPrefab, transform.position, Quaternion.LookRotation(target.transform.position)) as GameObject;

        go.transform.LookAt(target.transform);

        go.SendMessage("SetDmg", damage);
        go.SendMessage("SetEnemy", target);
    }
    

    public override void takeDmg(object dmg)
    {
        this.hp -= (float) dmg;
        if (hp <= 0) Destroy(gameObject);
    }

    public void SetMovable(object m) {
        movable = (bool)m;
        originalScale = transform.localScale;
        transform.localScale = transform.localScale * 2;
    }
}
