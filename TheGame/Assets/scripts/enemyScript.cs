using UnityEngine;
using System.Collections;
using Assets.scripts;

public class enemyScript : MonoBehaviour {

    public GameObject CASTLE;
    public MsgDispatcher msg = new MsgDispatcher();

    public float range;
    public float dmg;
    public float attackRate; // seconds between attacks
    public float moveSpeed; // units per second

    private float lastAttackTime;

	// Use this for initialization
	void Start () {
        lastAttackTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
        nextMove();
	}

    void nextMove()//move or attack
    {
        Vector3 path = pathToCastle();
        float distance = Mathf.Abs(path.x) + Mathf.Abs(path.z);//pseudo distance
        

        if (distance <= range)
        {
            attack();
            return;
        }

        float maxDelta = Time.deltaTime * moveSpeed;
        
        if (Mathf.Abs(path.x) > maxDelta) {
            path.x = maxDelta * Mathf.Sign(path.x);
        }

        if (Mathf.Abs(path.z) > maxDelta) {
            path.z = maxDelta * Mathf.Sign(path.z);
        }
        move(path);
    }

    void move(Vector3 step)
    {
        step.x += transform.position.x;
        step.y += transform.position.y;
        step.z += transform.position.z;
        transform.position = step;
    }

    Vector3 pathToCastle()
    {
        float xDiff = CASTLE.transform.position.x - transform.position.x;
        float zDiff = CASTLE.transform.position.z - transform.position.z;

        return new Vector3(xDiff, 0, zDiff);
    }

    void attack()
    {
        if(lastAttackTime < Time.time - attackRate)
        {
            msg.damageCastle(dmg);
            lastAttackTime += attackRate;
        }
    }
}
