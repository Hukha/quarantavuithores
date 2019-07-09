using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static Player player;
    public GameObject tourist;
    public Transform touristOrigin;

    public LevelConfig level;

    private RestPlaceController[] restPlaces;
    private const string TOURIST_PREFIX = "TO";
    private const string ENEMY_PREFIX = "EN";

    private int TouristId;
    private int EnemyId;

    void Awake () {
        // player = new Player (5, 100);
        EnemyId = 1;
    }

    void Start () {
        level = GameData.actualLevel.config;
        SetRestPlaces ();
        StartCoroutine (SendTouristWave ());
        StartCoroutine (SendEnemytWave ());
    }

    private IEnumerator SendTouristWave () {
        RestPlaceController restPlaceCon;
        GameObject turistaGo;
        PatternRoute pattern;
        TouristController tourist;
        Tourist touristInfo;
        int range;
        string touristId;
        while (true) {
            range = Random.Range (level.minTouristsPerWave, level.maxTouristsPerWave);
            for (var i = 0; i < range; i++) {
                if (CheckRestPlaces (out restPlaceCon)) {
                    yield return new WaitForSeconds (level.touristSpanSpeed);

                    turistaGo = SpawningPool.CreateFromCache ("TO1");
                    touristId = GetNextTouristIdString ();
                    tourist = turistaGo.GetComponent<TouristController> ();
                    pattern = restPlaceCon.touristComming (tourist);
                    touristInfo = new Tourist (
                        TourisType.Girl,
                        touristId,
                        level.touristSpeed,
                        pattern,
                        restPlaceCon,
                        2
                    );
                    tourist.Init (touristInfo);
                }
            }
            yield return new WaitForSeconds (level.timeBetweenWaves);
        }
    }

    private IEnumerator SendEnemytWave () {
        RestPlaceController restPlaceCon;
        GameObject enemyGo;
        EnemyController enemy;
        PatternRoute pattern;
        Enemy enemyInfo;
        int range;
        while (true) { //TODO Canviar per comprovació de Game Over
            range = Random.Range (level.minEnemiesPerWave, level.maxEnemiesPerWave);
            for (var i = 0; i < range; i++) {
                if (CheckRestPlacesEnemy (out restPlaceCon)) {
                    enemyGo = SpawningPool.CreateFromCache ("EO1");
                    enemy = enemyGo.GetComponent<EnemyController> ();
                    pattern = restPlaceCon.enemyComming (enemy);
                    enemyInfo = new Enemy (
                        GetNextEnemyIdString (),
                        level.enemyHealth,
                        level.enemySpeed,
                        pattern,
                        restPlaceCon,
                        1
                    );
                    enemy.Init (enemyInfo);
                }
                Debug.Log (restPlaceCon);
            }
            yield return new WaitForSeconds (level.timeBetweenEnemyWaves);
        }
    }

    private bool CheckRestPlaces (out RestPlaceController rest) {
        List<RestPlaceController> restPlace = restPlaces.Where (r => r.restPlace.state == RestState.Empty).ToList ();
        rest = restPlace.Count > 0 ? restPlace[Random.Range (0, restPlace.Count - 1)] : null;
        return rest != null;
    }

    private bool CheckRestPlacesEnemy (out RestPlaceController rest) {
        List<RestPlaceController> restPlace = restPlaces.Where (r => r.restPlace.state == RestState.Full && r.restPlace.enemy == null).ToList ();
        rest = restPlace.Count > 0 ? restPlace[Random.Range (0, restPlace.Count - 1)] : null;
        return rest != null;
    }

    private void SetRestPlaces () {
        GameObject[] restGameObjects = GameObject.FindGameObjectsWithTag ("RestPlace");
        Debug.Log ("AAAAAAAAAAAAAAAAAAAAAAAAAAAA");
        restPlaces = restGameObjects.Select (r => r.GetComponent<RestPlaceController> ()).ToArray ();
    }

    private string GetNextTouristIdString () {
        var result = TOURIST_PREFIX + TouristId;
        TouristId++;
        return result;
    }

    private string GetNextEnemyIdString () {
        var result = ENEMY_PREFIX + EnemyId;
        EnemyId++;
        return result;
    }

    public static void ResetLevel () {
        Debug.Log ("Reset Level");
    }
    public static void GoToMenu () {
        Debug.Log ("To Menu");
    }

}