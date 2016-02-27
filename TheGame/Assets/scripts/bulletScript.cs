using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

   private GameObject target;
    private bool targetSetted = false;


    public float moveSpeed = 4;

    private float dmg;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (!targetSetted) return;

        if (target == null)
        {
            Destroy(gameObject);
            return;
        }
        
        float maxDelta = Time.deltaTime * moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, maxDelta);
        float distance = Vector3.Distance(transform.position, target.transform.position);
        if(distance < 0.2)
        {
            target.SendMessage("takeDmg", dmg);
            Destroy(gameObject);
        }
	}

    public void setDmg(object dmg) {
        this.dmg = (float) dmg;
    }

    public void setTarget(object target) {
        this.target = (GameObject)target;
        targetSetted = true;
    }
}
