using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public GameObject CASTLE;
    
    public float moveSpeed = 4;
    public string castleName = "Castle";

    private float dmg;
    // Use this for initialization
    void Start () {
        CASTLE = GameObject.Find(castleName);
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (CASTLE == null)
        {
            Destroy(gameObject);
            return;
        }
        float maxDelta = Time.deltaTime * moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, CASTLE.transform.position, maxDelta);
        float distance = Vector3.Distance(transform.position, CASTLE.transform.position);
        if(distance < 0.2)
        {
            CASTLE.SendMessage("takeDmg", dmg);
            Destroy(gameObject);
        }
	}

    public void setDmg(object dmg) {
        this.dmg = (float) dmg;
    }
}
