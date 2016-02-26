using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

    public GameObject CASTLE;
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

        if (distance <= range)
        {
            attack();
            return;
        }

        float maxDelta = Time.deltaTime * moveSpeed;

        if (distance > maxDelta)
        {
            Vector3 shortPath = new Vector3();
            shortPath.x = path.x * maxDelta / (distance - path.z);
            shortPath.z = path.z * maxDelta / (distance - path.x);
            path = shortPath;
        }
        move(path);
    }

    void move(Vector3 step)
    {
        transform.position = transform.position + step;
    }

    Vector3 pathToCastle()
    {
        float xDiff = transform.position.x - CASTLE.transform.position.x;
        float zDiff = transform.position.y - CASTLE.transform.position.y;

        return new Vector3(xDiff, 0, zDiff);
    }

    void attack()
    {
        if(lastAttackTime < Time.time - attackRate)
        {
            //CASTLE.takeDmg(dmg);
            lastAttackTime += attackRate;
        }
    }
}
