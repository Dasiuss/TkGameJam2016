using UnityEngine;
using UnityEngine.EventSystems;

public class CastChaosController : MonoBehaviour {

    public void OnPointerClick (PointerEventData data) {
        Debug.Log ("Chaos Casted!");
        GameObject [] enemies;
        enemies = GameObject.FindGameObjectsWithTag ("enemy");
        foreach (GameObject e in enemies) {
            e.SendMessage ("TagEnemy", null);
        }
    }
}
