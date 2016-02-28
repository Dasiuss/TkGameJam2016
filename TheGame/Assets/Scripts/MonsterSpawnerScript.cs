using UnityEngine;
using System.Collections;

public class MonsterSpawnerScript : MonoBehaviour {
    Transform monsterSpawner;
    Vector3 center;
    float spawnRadius = 30;
    
    public GameObject mobPrefab;
 
	void Start () {
        monsterSpawner = this.transform;
        center = monsterSpawner.position;
	}

    public void SpawnMob () {
        // monstersPerSeconds - 2 na wiezyczke na sekunde
        int monstersPerSeconds = GameObject.FindGameObjectsWithTag("tower").Length;
        for (int i = 0; i < monstersPerSeconds; i++) {
            Vector3 pos = RandomCircle (center, spawnRadius);
            Quaternion rot = Quaternion.FromToRotation (Vector3.forward, center - pos);
            GameObject e = (GameObject)Instantiate (mobPrefab, pos, rot);
            e.tag = "enemy";
        }
    }

    Vector3 RandomCircle (Vector3 center, float radius) {
        float ang = Random.value * 360;
        Vector3 pos;
        pos.x = center.x + radius * Mathf.Sin (ang * Mathf.Deg2Rad);
        pos.y = center.y;
        pos.z = center.z + radius * Mathf.Cos (ang * Mathf.Deg2Rad);
        return pos;
    }
}
