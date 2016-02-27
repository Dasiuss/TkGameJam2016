using UnityEngine;
using System.Collections;
using Assets.scripts;

class enemyScript : MonoBehaviour {

    public GameObject CASTLE;
    public GameObject playerProjectile;

    public float range;
    public float dmg;
    public float attackRate; // seconds between attacks
    public float moveSpeed; // units per second
    public string castleName = "Castle";

    private float lastAttackTime;

	// Use this for initialization
	void Start () {
        lastAttackTime = Time.time;
        CASTLE = GameObject.Find(castleName);
	}
	
	// Update is called once per frame
	void Update () {
        nextMove();
	}

    void nextMove()//move or attack
    {
        Vector3 castle = CASTLE.transform.position;
        Vector3 me = transform.position;

        if (Vector3.Distance(me, castle) < range)
        {
            attack();
        }
        else
        {
            float maxDelta = Time.deltaTime * moveSpeed;
            transform.position = Vector3.MoveTowards(me, castle, maxDelta);
        }
        
    }
    
    void attack()
    {
        if(lastAttackTime < Time.time - attackRate)
        {
            GameObject go = Instantiate(playerProjectile, transform.position, Quaternion.LookRotation(CASTLE.transform.position)) as GameObject;
            go.SendMessage("setDmg", dmg);
            Quaternion q = Quaternion.FromToRotation(Vector3.up, transform.forward);
            go.transform.rotation = q * go.transform.rotation;
            
            lastAttackTime = Time.time;
        }
    }
}
