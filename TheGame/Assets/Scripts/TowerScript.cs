using UnityEngine;
using System.Collections;

public class TowerScript : MonoBehaviour {

    public float range;
    public float fireRate;
    public int numberOfTargets;
    public float damage;
    public float explosionRadius;
    public GameObject bulletPrefab;

    private bool wave;
    private float lastShot = 0;
    private float fireCooldownleft;
    private GameObject spottedEnemy;
    private Transform turretTransform;

	void Start () {
        turretTransform = this.transform;
        wave = false;
	}
	
	// Update is called once per frame
	void Update () {
        if (wave) {
            GameObject [] enemies = GameObject.FindGameObjectsWithTag ("Enemy");
            GameObject nearestEnemy = null;
            float dist = Mathf.Infinity;
            foreach (GameObject e in enemies) {
                float d = Vector3.Distance (this.transform.position, e.transform.position);
                if (nearestEnemy == null || d < dist) {
                    nearestEnemy = e;
                    dist = d;
                }
            }

            Vector3 dir = nearestEnemy.transform.position - this.transform.position;
            fireCooldownleft = Time.time - lastShot;
            if (fireCooldownleft > fireRate && dir.magnitude <= range) {
                lastShot = Time.time;
                ShootAt (nearestEnemy);
            }
        }
	}

    void ShootAt (GameObject enemy) {
        GameObject bulletGO = (GameObject)Instantiate (bulletPrefab, this.transform.position, this.transform.rotation);
        BulletScript bulletScr = bulletGO.GetComponent<BulletScript> ();
        bulletScr.SendMessage ("SetDmg", damage);
        bulletScr.SendMessage ("SetEnemy",enemy);
    }

    public void StartShooting () {
        wave = true;
    }
}
