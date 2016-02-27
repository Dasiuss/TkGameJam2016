using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour
{
    public float speed = 15;

    private Transform target;
    private GameObject enemy;
    private bool targetSetted = false;
    private float dmg;

    void Start()
    {
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
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if (distance < 0.2)
        {
            target.SendMessage("takeDmg", dmg);
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
}
