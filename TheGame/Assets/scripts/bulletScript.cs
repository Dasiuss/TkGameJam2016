using UnityEngine;
using System.Collections;

public class bulletScript : MonoBehaviour {

    public GameObject CASTLE;
    
    public float moveSpeed = 4;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update ()
    {
        float maxDelta = Time.deltaTime * moveSpeed;
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(0,0,0), maxDelta);
	}
}
