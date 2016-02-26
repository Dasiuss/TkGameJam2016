using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private bool wave;
    private int income = 500;
    private int goldAmount = 1000;
    private Text goldText;
    private Text incomeText;

    void Start () {
        wave = false;
        incomeText = GameObject.FindWithTag ("IncomeText").GetComponent<Text>();
        incomeText.text = "Income: " + income;
        goldText = GameObject.FindWithTag ("GoldText").GetComponent<Text> ();
        goldText.text = "Gold: " + goldAmount;
    }

    public void StartWave () {
        wave = true;
        Debug.Log ("IT WORKS!");
    }

    void AfterWaveUpdate () {
        wave = false;
        goldAmount += income;
    }

}
