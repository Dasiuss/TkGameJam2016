using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    
    private int income = 500;
    private int goldAmount = 1000;
    private Text goldText;
    private Text incomeText;
    private GameObject buttonImage;
    private GameObject spellPanel;
    private GameObject monsterSpawner;
    private bool wave;

    private float spawnEnemiesCallRate = 0.5f;
    private float spawnEnemiesLastCall = 0;

    private float startTime;
    private float seconds;
    private float time;
    private float waveDuration = 10.0f;

    void Start () {
        wave = false;
        incomeText = GameObject.FindWithTag ("IncomeText").GetComponent<Text>();
        incomeText.text = "Income: " + income;
        goldText = GameObject.FindWithTag ("GoldText").GetComponent<Text> ();
        goldText.text = "Gold: " + goldAmount;
        buttonImage = GameObject.FindWithTag ("StartWaveButton");
        spellPanel = GameObject.Find ("SpellPanel");
        spellPanel.gameObject.SetActive (false);
        monsterSpawner = GameObject.Find ("MonsterSpawner");
    }

    void Update () {
        time = Time.time;
        seconds = time - startTime;
        if (seconds > waveDuration && wave) {
            AfterWaveUpdate ();
        }
        if (wave && time - spawnEnemiesLastCall > spawnEnemiesCallRate) {
            spawnEnemiesLastCall = time;
            SpawnEnemies ();
        }
    }
    public void StartWave () {
        buttonImage.gameObject.SetActive (false);
        seconds = 10;
        startTime = Time.time;
        wave = true;
        spellPanel.SetActive (true);
    }

    void AfterWaveUpdate () {
        wave = false;
        goldAmount += income;
        goldText.text = "Gold: " + goldAmount;
        buttonImage.gameObject.SetActive (true);
        spellPanel.gameObject.SetActive (false);
        Debug.Log ("Build phase");
        GameObject [] enemies = GameObject.FindGameObjectsWithTag ("enemy");
        foreach (GameObject e in enemies) {
            Destroy (e);
        };
    }

    void SpawnEnemies () {
        Debug.Log (seconds);
        monsterSpawner.GetComponent<MonsterSpawnerScript> ().SpawnMob ();
        
    }

    void AddGoldForAKill(object gold)
    {
        this.goldAmount += (int) gold;
    }
}