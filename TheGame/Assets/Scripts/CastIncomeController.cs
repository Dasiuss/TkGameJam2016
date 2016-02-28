using UnityEngine;
using UnityEngine.EventSystems;

public class CastIncomeController : MonoBehaviour, IPointerClickHandler {
    

    public void OnPointerClick (PointerEventData data) {
        Debug.Log ("CLICK");
        GameObject gc = GameObject.Find ("GameController");
        GameController g = gc.GetComponent<GameController> ();
        g.SendMessage ("IncIncome", 50);
    }
}
