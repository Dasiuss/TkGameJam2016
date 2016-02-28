using UnityEngine;
using UnityEngine.EventSystems;

public class CastIncomeController : MonoBehaviour, IPointerClickHandler {
    

    public void OnPointerClick (PointerEventData data) {
        GameObject gc = GameObject.FindGameObjectWithTag("GameController");
        gc.SendMessage ("IncIncome", 50);
    }
}
