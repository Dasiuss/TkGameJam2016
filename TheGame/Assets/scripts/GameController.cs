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
    private float spawnEnemiesLastCall = 0.0f;

    private float startTime;
    private float seconds;
    private float time;
    private float waveDuration = 10.0f;

    public GameObject missleTowerPrefab;
    public GameObject freezeTowerPrefab;
    public GameObject sniperTowerPrefab;

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
        SetBuyTowerPanel ();
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

    void SetBuyTowerPanel () {
        Text mthp = GameObject.Find ("MtHP").GetComponent<Text> ();
        Text mtdmg = GameObject.Find ("MtDmg").GetComponent<Text> ();
        Text mtfr = GameObject.Find ("MtFr").GetComponent<Text> ();
        mthp.text = "HP: " + missleTowerPrefab.GetComponent<TowerScript> ().hp;
        mtdmg.text = "Dmg: " + missleTowerPrefab.GetComponent<TowerScript> ().damage;
        mtfr.text = "FR: " + missleTowerPrefab.GetComponent<TowerScript> ().fireRate;


        Text fthp = GameObject.Find ("FtHP").GetComponent<Text> ();
        Text ftdmg = GameObject.Find ("FtDmg").GetComponent<Text> ();
        Text ftfr = GameObject.Find ("FtFr").GetComponent<Text> ();
        fthp.text = "HP: " + freezeTowerPrefab.GetComponent<TowerScript> ().hp;
        ftdmg.text = "Dmg: " + freezeTowerPrefab.GetComponent<TowerScript> ().damage;
        ftfr.text = "FR: " + freezeTowerPrefab.GetComponent<TowerScript> ().fireRate;


        Text sthp = GameObject.Find ("StHP").GetComponent<Text> ();
        Text stdmg = GameObject.Find ("StDmg").GetComponent<Text> ();
        Text stfr = GameObject.Find ("StFr").GetComponent<Text> ();
        sthp.text = "HP: " + sniperTowerPrefab.GetComponent<TowerScript> ().hp;
        stdmg.text = "Dmg: " + sniperTowerPrefab.GetComponent<TowerScript> ().damage;
        stfr.text = "Fr: " + sniperTowerPrefab.GetComponent<TowerScript> ().fireRate;
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

}