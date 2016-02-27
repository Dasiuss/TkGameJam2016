using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour
{
    public float speed = 15;

    private Transform target;
    private GameObject enemy;
    private bool targetSetted = false;
    private float dmg;
    private float slowness;

    void Start() {
    }

    void Update()
    {

        if (!targetSetted) return;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        float maxDelta = Time.deltaTime * speed;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, maxDelta);

        //Quaternion rot = Quaternion.FromToRotation(transform.position, enemy.transform.position);
        //transform.rotation = rot;

        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < 0.2)
        {
            target.SendMessage("takeDmg", dmg);
            if(slowness>0)
                target.SendMessage("takeSlowness", slowness);
            Destroy(gameObject);
        }
    }

    public void SetEnemy(object t)
    {
        this.enemy = (GameObject)t;
        this.target = enemy.transform;
        targetSetted = true;
    }

    public void SetDmg(object dmg)
    {
        this.dmg = (float)dmg;
    }
    public void SetSlowness(object slowness)
    {
        this.slowness = (float) slowness;
        Debug.Log(this.slowness);
    }
}
