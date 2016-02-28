using UnityEngine;

public class SpellScript : MonoBehaviour{
    public int spellNumber;
    public float startTime;

    private bool gathered = false;

    // Use this for initialization
    void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        startTime = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(5, 1, 2);
        if (gathered)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y+0.5f, transform.position.z);
            if (transform.position.y > 100) Destroy(gameObject);
        }else {
            if (startTime + 3 < Time.time) Destroy(gameObject);
        }
    }

    void OnMouseDown() {
        if (!gathered)
        {
            GameObject gameCtrl = GameObject.FindGameObjectWithTag("GameController");
            gameCtrl.SendMessage("addSpell", this.spellNumber);
            gathered = true;
        }
    }
}
