using UnityEngine;
using System.Collections;
using Assets.scripts;

class enemyScript : MonoBehaviour {

    private GameObject CASTLE;
    public GameObject playerProjectile;
    public GameObject[] drops;
    private GameObject gameCtrl;
    public float dropProbability = 0.1f;

    public float range;
    public float dmg;
    public float attackRate; // seconds between attacks
    public float moveSpeed; // units per second
    public string castleName = "Castle";
    public float hp;
    public int goldWorth;
    public AudioClip attackSound;
    public AudioClip deathSound;
    public float attSoundProb;
    public float dieSoundProb;

    private float lastAttackTime;

	// Use this for initialization
	void Start () {
        lastAttackTime = Time.time;
        CASTLE = GameObject.Find(castleName);
        gameCtrl = GameObject.FindGameObjectWithTag("GameController");
        this.gameObject.AddComponent<AudioSource> ();
        this.GetComponent<AudioSource> ().clip = attackSound;
	}
	
	// Update is called once per frame
	void Update () {
        nextMove();
	}

    void nextMove()//move or attack
    {

        GameObject target = findTarget();
        if(target!= null)
        {
            attack(target);
            return;
        }
        Vector3 castle = CASTLE.transform.position;
        Vector3 me = transform.position;

        if (Vector3.Distance(me, castle) <= range)
        {
            attack(CASTLE);
        }
        else
        {
            float maxDelta = Time.deltaTime * moveSpeed;
            transform.position = Vector3.MoveTowards(me, castle, maxDelta);
        }
        
    }
    
    private GameObject findTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("tower");
        foreach (GameObject e in enemies){
            if (Vector3.Distance(this.transform.position, e.transform.position) <= range) return e;
        }
        return null;
    }

    void attack(GameObject target)
    {
        if(lastAttackTime < Time.time - attackRate)
        {
            float r = Random.value;
            if (r < attSoundProb) {
                this.GetComponent<AudioSource> ().Play ();
            }
            GameObject go = Instantiate(playerProjectile, transform.position, Quaternion.LookRotation(CASTLE.transform.position)) as GameObject;
            go.SendMessage("SetDmg", dmg);
            go.SendMessage("SetEnemy", target);
            // TODO Quaternion q = Quaternion.FromToRotation(Vector3.up, transform.forward);
            //      go.transform.rotation = q * go.transform.rotation;
            
            lastAttackTime = Time.time;
        }
    }

    public void takeDmg(object dmg)
    {
        hp -= (float)dmg;
        if (hp <= 0) die();
    }
    public void takeSlowness(object slowness)
    {
        this.moveSpeed -= (float) slowness;
        if (moveSpeed < 0.1f) moveSpeed = 0.1f;
    }
    private void die()
    {
        if (Random.value<0.1)
        {
            this.GetComponent<AudioSource>().clip = deathSound;
            this.GetComponent<AudioSource>().Play();
        }
        foreach (GameObject drop in drops)
        {       
            float rnd = Random.value;
            
            rnd = Random.value;
            if (rnd < dropProbability / drops.Length) { 
                Instantiate(drop, transform.position, transform.rotation);
            }
        }
        gameCtrl.SendMessage("AddGoldForAKill", goldWorth);
        
        Destroy(gameObject);
    }
}
