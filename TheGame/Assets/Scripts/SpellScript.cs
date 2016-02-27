using UnityEngine;

public class SpellScript : MonoBehaviour{
    public string spellName = "anySpell";
    public float startTime;
	// Use this for initialization
	void Start () {
        transform.position = new Vector3(transform.position.x, transform.position.y + 1, transform.position.z);
        startTime = Time.time;
	}

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(5, 1, 2);
        if (startTime + 2 < Time.time) Destroy(gameObject);
    }

    void OnMouseDown() {
        GameObject gameCtrl = GameObject.FindGameObjectWithTag("GameController");
        gameCtrl.SendMessage("addSpell", this.spellName);
        Destroy(gameObject);
    }
}
