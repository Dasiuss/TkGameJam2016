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
        float distance = path.x + path.z;//pseudo distance

        Debug.Log(distance);

        if (distance <= range)
        {
            attack();
            return;
        }

        float maxDelta = Time.deltaTime * moveSpeed;

        Debug.Log(path);
        Vector3 shortPath = new Vector3(path.x, 0, path.z);
        if (path.x > maxDelta)
        {
            shortPath.x = path.x * maxDelta / (distance - path.z);
        }
        if (path.z > maxDelta) {
            shortPath.z = path.z * maxDelta / (distance - path.x);
            path = shortPath;
        }
        Debug.Log(path);
        move(shortPath);
    }

    void move(Vector3 step)
    {
        transform.position = transform.position + step;
    }

    Vector3 pathToCastle()
    {
        float xDiff = transform.position.x - CASTLE.transform.position.x;
        float zDiff = transform.position.z - CASTLE.transform.position.z;

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
