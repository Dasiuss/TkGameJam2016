using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {
    public float speed = 15.0f;
    public Transform target;
    public GameObject enemy;
    public int dmg;

	void Start () {
	
	}
	
	void Update () {
        Vector3 dir = target.position = this.transform.localPosition;
        float distThisFrame = speed * Time.deltaTime;
        if (dir.magnitude <= distThisFrame) {
            DoBulletHit ();
        } else {
            transform.Translate (dir.normalized * distThisFrame, Space.World);
        }
	}

    void DoBulletHit () {
        Destroy (gameObject);
    }

    public void SetEnemy (object t) {
        this.enemy = (GameObject)t;
        this.target = enemy.transform;
    }

    public void SetDMG (object dmg) {
        this.dmg = (int)dmg;
    }
}
